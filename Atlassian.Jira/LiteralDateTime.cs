using System;

namespace Atlassian.Jira
{
    /// <summary>
    /// Force a DateTime field to use a string provided as the JQL query value.
    /// </summary>
    public class LiteralDateTime
    {
        private readonly string _dateTimeString;

        public LiteralDateTime(string dateTimeString)
        {
            _dateTimeString = dateTimeString;
        }

        public override string ToString()
        {
            return _dateTimeString;
        }

        public static bool operator ==(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator !=(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator >(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator <(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator >=(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator <=(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator ==(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator !=(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator >(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator <(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator >=(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator <=(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is LiteralDateTime literalDateTime)
            {
                return _dateTimeString == literalDateTime._dateTimeString;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _dateTimeString != null ? _dateTimeString.GetHashCode() : 0;
        }
    }
}
