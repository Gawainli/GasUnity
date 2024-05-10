using Haro.GAS;

namespace Code
{
    public class TestAttributeSet : AttributeSet
    {
        public AttributeData MaxHealth = new AttributeData();
        public AttributeData CurrentHealth = new AttributeData();
        
        public override void Initialize()
        {
        }
    }
}