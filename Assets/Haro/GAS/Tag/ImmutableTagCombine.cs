using System.Collections.Generic;
using System.Text;

namespace Haro.GAS
{
    public class ImmutableTagCombine : ITagCombine
    {
        private readonly Tag[] _tags;

        public ImmutableTagCombine(params Tag[] tags)
        {
            _tags = tags;
        }

        public IReadOnlyList<Tag> GetTags()
        {
            return _tags;
        }

        public int Count()
        {
            return _tags.Length;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append('[');
            for (int i = 0; i < _tags.Length; i++)
            {
                sb.Append(_tags[i].ToString());
                if (i < _tags.Length - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append(']');

            return sb.ToString();
        }
    }
}