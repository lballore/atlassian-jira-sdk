namespace Atlassian.Jira
{
    /// <summary>
    /// Force a CustomField comparison to use the exact match JQL operator.
    /// </summary>
    public class LiteralMatch
    {
        private readonly string _value;

        public LiteralMatch(string value)
        {
            this._value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public static bool operator ==(ComparableString comparable, LiteralMatch literal)
        {
            if (comparable is null)
            {
                return literal == null;
            }
            else
            {
                return comparable.Value == literal._value;
            }
        }

        public static bool operator !=(ComparableString comparable, LiteralMatch literal)
        {
            if (comparable is null)
            {
                return literal != null;
            }
            else
            {
                return comparable.Value != literal._value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is LiteralMatch literal)
            {
                return _value == literal._value;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _value != null ? _value.GetHashCode() : 0;
        }
    }
}
