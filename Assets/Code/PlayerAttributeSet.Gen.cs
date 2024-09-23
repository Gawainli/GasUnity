using Haro.GAS;

namespace GasGame
{
    public partial class PlayerAttributeSet : AttributeSet
    {
        //==自动化变量开始
        public Attribute hp;
        public Attribute mana;
        public Attribute attack;

        
        public PlayerAttributeSet()
        {
            //==自动化创建开始
            hp = CreateAttribute("hp");
            mana = CreateAttribute("mana");
            attack = CreateAttribute("attack");

        }
    }
}