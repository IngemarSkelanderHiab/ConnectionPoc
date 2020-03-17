namespace ConnectionPoc
{
    public class Parameter
    {
        public MessageId Id { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Value: {Value}";
        }
    }
}