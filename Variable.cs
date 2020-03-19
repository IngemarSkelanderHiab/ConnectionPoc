namespace ConnectionPoc
{
    public class Variable
    {
        public MessageId Id { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Value: {Value}";
        }
    }
}