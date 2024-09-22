using System.Collections.Generic;

namespace Haro.GAS
{
    public static class TagCollection
    {
        public static readonly List<string> TagTexts = new List<string>();
        public static readonly Dictionary<string, int> HashCache = new Dictionary<string, int>();

        public static bool AddTagText(string tagText)
        {
            if (string.IsNullOrEmpty(tagText))
            {
                return false;
            }

            if (TagTexts.Contains(tagText))
            {
                return false;
            }

            TagTexts.Add(tagText);

            var parts = tagText.Split('.');
            foreach (var text in parts)
            {
                HashCache.TryAdd(text, text.GetHashCode());
            }

            return true;
        }

        public static void LoadConfig(TagConfig cfg)
        {
            foreach (var tagText in cfg.tagTexts)
            {
                AddTagText(tagText);
            }
        }
        
        public static void Clear()
        {
            TagTexts.Clear();
            HashCache.Clear();
        }
    }
}