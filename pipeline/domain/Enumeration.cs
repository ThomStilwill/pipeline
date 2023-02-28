using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using pipeline.helpers;

namespace pipeline.domain
{
    // Based loosely on:
    // https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/

    public class Enumeration
    {
        protected readonly string _value;
        protected readonly string _display;
        public Enumeration() { }

        public Enumeration(string value, string display)
        {
            _value = value;
            _display = display;
        }
        
        public string Value => _value;

        public string Display => _display;

        public override string ToString()
        {
            return Display;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static IEnumerable<T> GetAll<T>() where T: Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            //var fields = type.GetFields();

            foreach (var info in fields)
            {
                var instance = new T();

                if (info.GetValue(instance) is T locatedValue)
                {
                    yield return locatedValue;
                }
            }
        }

        public static T FromValue<T>(string value) where T : Enumeration, new()
        {
            return parse<T, string>(value, "display", item => item.Value == value);
        }

        public static T FromDisplay<T>(string display) where T : Enumeration, new()
        {
            return parse<T, string>(display, "display", item => item.Display == display);
        }
       
        protected static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T: Enumeration, new()
        {
            var enumerations = GetAll<T>();
            var matchingItem = enumerations.FirstOrDefault(predicate);
            if (matchingItem != null) return matchingItem;

            var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
            throw new ApplicationException(message);
        }
    }

    public class Enumeration<TKey> : Enumeration, IComparable where TKey: new()
    {
        protected TKey _key;
        public TKey Key => _key;

        protected Enumeration() { }
        protected Enumeration(TKey key):this(key, key.ToString(), key.ToString().PascalCaseToWords()) { }
        protected Enumeration(TKey key,string value):this(key,value,key.ToString().PascalCaseToWords()) { }
        protected Enumeration(TKey key,string value, string display) : base(value,display)
        {
            _key = key;
        }
      
        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration<TKey>;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = _value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration<TKey>)other).Value);
        }

        public static T FromKey<T>(TKey key) where T : Enumeration<TKey>, new()
        {
            return parse<T, TKey>(key, "key", item => item.Key.Equals(key));
        }
    }
}
