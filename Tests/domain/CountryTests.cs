using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using pipeline.domain;

namespace Tests.domain
{
    internal class CountryTests
    {
        [Test]
        public void GetAllWithCountryReturnsAllCountries()
        {
            //Arrange
            
            //Act
            var countries = Enumeration.GetAll<Country>();
            foreach (var country in countries)
            {
                Console.WriteLine(country.ToString());
            }

            //Assert
            countries.Count().Should().Be(4);
        }

        [Test]
        public void FromValue_WithCountry_ReturnsCountry()
        {
            //Arrange
            var countryValue = "US";

            //Act
            var country = Enumeration.FromValue<Country>(countryValue);

            //Assert
            country.Value.Should().Be(countryValue);
        }
        
        [Test]
        public void FromDisplayName_WithCountry_ReturnsCountry()
        {
            //Arrange
            var countryValue = "United States";

            //Act
            var country = Enumeration.FromDisplay<Country>(countryValue);

            //Assert
            country.Display.Should().Be(countryValue);
        }

        [Test]
        public void FromKey_WithCountry_ReturnsCountry()
        {
            //Arrange
            var countryKey = Country.Keys.UnitedStates;

            //Act
            var country = Country.FromKey<Country>(countryKey);

            //Assert
            country.Key.Should().Be(countryKey);
        }
        
        [Test]
        public void FromKey_WithCountryUK_ReturnsDisplay()
        {
            //Arrange
            var countryKey = Country.Keys.UnitedKingdom;
            var countryName = "Great Britain";

            //Act
            var country = Country.FromKey<Country>(countryKey);

            //Assert
            country.Display.Should().Be(countryName);
        }
    }
}
