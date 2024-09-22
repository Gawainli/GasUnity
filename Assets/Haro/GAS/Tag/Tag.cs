using System;
using System.Collections.Generic;
using System.Linq;

namespace Haro.GAS
{
    public struct Tag : IEquatable<Tag>
    {

        private readonly Dictionary<int, int> _hashedTags;
        private readonly string _str;

        private Tag(string tagText)
        {
            if (string.IsNullOrEmpty(tagText))
            {
                throw new ArgumentException($"{nameof(tagText)} is null or empty.");
            }

            var tags = tagText.Split('.').Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();
            _hashedTags = new Dictionary<int, int>(tags.Length);
            
            for (int i = 0; i < tags.Length; i++)
            {
                _hashedTags[i] = GetHash(tags[i]);
            }

            _str = tagText;
        }

        public bool Match(in Tag other)
        {
            var minLength = Math.Min(_hashedTags.Count, other._hashedTags.Count);

            for (var i = 0; i < minLength; i++)
            {
                if (!_hashedTags.TryGetValue(i, out var selfHash) || selfHash != other._hashedTags[i])
                {
                    return false;
                }
            }

            return _hashedTags.Count <= other._hashedTags.Count;
        }

        public override string ToString()
        {
            return _str;
        }

        public bool Equals(Tag other)
        {
            if (_hashedTags.Count != other._hashedTags.Count)
            {
                return false;
            }

            foreach (var pair in _hashedTags)
            {
                if (!other._hashedTags.TryGetValue(pair.Key, out int otherHash) || pair.Value != otherHash)
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

        #region Create Function

        private static int GetHash(string input)
        {
            if (TagCollection.HashCache.TryGetValue(input, out var hash))
            {
                return hash;
            }
            
            hash = input.GetHashCode();
            TagCollection.HashCache[input] = hash;
            return hash;
        }

        public static Tag Create(in string tagText)
        {
            return new Tag(tagText);
        }

        #endregion
    }
}