namespace ConnectionPoc
{
    public class Signal
    {
        public MessageId Id { get; set; }
        public string ParameterValue { get; set; }
        public string VariableValue { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, ParameterValue: {ParameterValue}, VariableValue: {VariableValue}";
        }
    }
}