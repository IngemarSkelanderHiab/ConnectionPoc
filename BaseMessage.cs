using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionPoc
{
    public abstract class BaseMessage
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Value: {Value}";
        }
    }
}
