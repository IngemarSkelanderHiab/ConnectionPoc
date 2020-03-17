using System;

namespace ConnectionPoc
{
    public sealed class MessageId
    {
        private readonly Guid _value = Guid.NewGuid();

        private MessageId() { }

        private bool Equals(MessageId other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((MessageId) obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(MessageId a, MessageId b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a == null || b == null)
                return false;

            return a._value == b._value;
        }

        public static bool operator !=(MessageId a, MessageId b)
        {
            return !(a == b);
        }

        public static MessageId Create()
        {
            return new MessageId();
        }
    }
}