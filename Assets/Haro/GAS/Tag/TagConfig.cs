using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Haro.GAS
{
    [CreateAssetMenu(fileName = "GAS/TagConfig", menuName = "TagConfig", order = 0)]
    public class TagConfig : ScriptableObject
    {
        [Searchable] public List<string> tagTexts;

        [Button]
        public void Refresh()
        {
            TagCollection.Clear();
            for (var i = 0; i < tagTexts.Count; i++)
            {
                var text = tagTexts[i];
                if (!TagCollection.AddTagText(text.ToUpper()))
                {
                    Debug.LogWarning($"Tag already exists: {text} at index {i}");
                }
            }

            Debug.Log($"{tagTexts.Count} tags added.");
        }
    }
}