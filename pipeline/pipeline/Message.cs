namespace pipeline.pipeline
{
    internal class Message
    {

        public enum OpSeverity
        {
            Info,
            Warning,
            Failure
        }

        public Message(string description, OpSeverity severity = OpSeverity.Info)
        {
            Severity = severity;
            Description = description;
        }

        public string Description { get; set; }
        public OpSeverity Severity { get; set; }
    }
}
