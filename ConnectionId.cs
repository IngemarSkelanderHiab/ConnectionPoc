using System;

namespace ConnectionPoc
{
    public sealed class ConnectionId
    {
        private readonly Guid _value = Guid.NewGuid();

        private ConnectionId() { }

        private bool Equals(ConnectionId other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ConnectionId)obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(ConnectionId a, ConnectionId b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a == null || b == null)
                return false;

            return a._value == b._value;
        }

        public static bool operator !=(ConnectionId a, ConnectionId b)
        {
            return !(a == b);
        }

        public static ConnectionId Create()
        {
            return new ConnectionId();
        }
    }
}
