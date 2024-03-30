using System.Collections.Generic;

namespace Haro.GAS
{
    public interface ITagCombine
    {
        IReadOnlyList<Tag> GetTags();
        int Count();

        bool HasMatchTag(in Tag other)
        {
            var tags = GetTags();
            for (int i = 0; i < tags.Count; i++)
            {
                if (tags[i].Match(other))
                {
                    return true;
                }
            }

            return false;
        }

        bool HasMatchAllOtherTag<T>(T other) where T : ITagCombine
        {
            var otherTags = other.GetTags();
            for (int i = 0; i < otherTags.Count; i++)
            {
                if (!HasMatchTag(otherTags[i]))
                {
                    return false;
                }
            }

            return true;
        }

        bool HasEqualTag<T>(T other) where T : ITagCombine
        {
            var tags = GetTags();
            var otherTags = other.GetTags();
            for (int i = 0; i < tags.Count; i++)
            {
                for (int j = 0; j < otherTags.Count; j++)
                {
                    if (tags[i].Equals(otherTags[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}