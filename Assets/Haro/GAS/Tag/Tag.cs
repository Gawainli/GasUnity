using System;
using System.Text;

namespace Haro.GAS
{
    public struct Tag : IEquatable<Tag>
    {
        private readonly string[] _strTags;
        private string _str;

        private Tag(string[] strTags)
        {
            _strTags = strTags;
            var sb = new StringBuilder();
            for (int i = 0; i < _strTags.Length; i++)
            {
                sb.Append(_strTags[i]);
                if (i < _strTags.Length - 1)
                {
                    sb.Append(".");
                }
            }
            _str = sb.ToString();
        }

        public static Tag Create(in string tagText)
        {
            if (string.IsNullOrEmpty(tagText))
            {
                throw new ArgumentException($"{tagText} is null or empty.");
            }

            return new Tag(tagText.Split('.'));
        }

        public bool Match(in Tag other)
        {
            for (int i = 0; i < Math.Min(_strTags.Length, other._strTags.Length); i++)
            {
                if (_strTags[i] != other._strTags[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return _str;
        }

        public bool Equals(Tag other)
        {
            if (_strTags == null || other._strTags == null)
            {
                return false;
            }

            if (_strTags.Length != other._strTags.Length)
            {
                return false;
            }

            for (int i = 0; i < _strTags.Length; i++)
            {
                if (_strTags[i] != other._strTags[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Tag other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _str.GetHashCode();
        }

        public static bool operator ==(Tag left, Tag right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Tag left, Tag right)
        {
            return !left.Equals(right);
        }
    }
}