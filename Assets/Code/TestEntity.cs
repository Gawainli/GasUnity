using Haro.GAS;
using UnityEngine;

namespace Code
{
    public class TestEntity : MonoBehaviour
    {
        public MutableTagCombine Tag = new MutableTagCombine();
        public TestAttributeSet AttributeSet = new TestAttributeSet();
        
        private void Start()
        {
            AttributeSet.Initialize();
            var attr = AttributeSet.GetAttribute(AttributeSet.MaxHealth);
            Debug.Log($"attr name: {attr.GetName()}");
        }
    }
}