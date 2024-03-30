using System.Collections.Generic;

namespace Haro.GAS
{
    public class MutableTagCombine : ITagCombine
    {
        private readonly List<Tag> _tags;
        public IReadOnlyList<Tag> GetTags()
        {
            return _tags;
        }

        public int Count()
        {
            return _tags.Count;
        }
        
        public MutableTagCombine()
        {
            _tags = new List<Tag>();
        }
        
        public MutableTagCombine(params Tag[] tags)
        {
            _tags = new List<Tag>(tags);
        }
        
        public MutableTagCombine(in List<Tag> tags)
        {
            _tags = new List<Tag>(tags);
        }
        
        public void AddTag(Tag tag)
        {
            _tags.Add(tag);
        }
        
        public void RemoveTag(Tag tag)
        {
            _tags.Remove(tag);
        }
        
        public void RemoveAllMatchTag(Tag tag)
        {
            _tags.RemoveAll(t => t.Match(tag));
        }
        
        public void RemoveAllMatchTags(in List<Tag> tags)
        {
            foreach (var tag in tags)
            {
                RemoveAllMatchTag(tag);
            }
        }
         
        public void RemoveAllEqualTag(Tag tag)
        {
            _tags.RemoveAll(t => t.Equals(tag));
        }
        
        public void RemoveAllEqualTags(in List<Tag> tags)
        {
            foreach (var tag in tags)
            {
                RemoveAllEqualTag(tag);
            }
        }
        
        public void Clear()
        {
            _tags.Clear();
        }
        
        public void AddTags(params Tag[] tags)
        {
            _tags.AddRange(tags);
        }
        
        public void AddTags(in List<Tag> tags)
        {
            _tags.AddRange(tags);
        }
        
        
    }
}