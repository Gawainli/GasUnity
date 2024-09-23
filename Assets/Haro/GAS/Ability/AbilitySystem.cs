using System.Collections.Generic;

namespace Haro.GAS
{
    public class AbilitySystem
    {
        public AttributeSet attributeSet;
        public readonly List<GameEffectSpec> appliedEffects = new List<GameEffectSpec>();
        
        public GameEffectSpec MakeGameEffectSpec(GameEffectDefine define, float level = 1)
        {
            return GameEffectSpec.CreateNew(define, this, level);
        }
        
        public void ApplyGameEffectSpecToSelf(GameEffectSpec effectSpec)
        {
            effectSpec.target = this;
            
            switch (effectSpec.define.durationPolicy)
            {
                case GameEffectDurationType.Instant:
                    effectSpec.ApplyModifiers();
                    break;
                case GameEffectDurationType.Infinite:
                case GameEffectDurationType.HasDuration:
                    appliedEffects.Add(effectSpec);
                    break;
            }
        }
        
        public void Tick(float deltaTime)
        {
            TickAppliedGameEffects(deltaTime);
        }
        
        private void TickAppliedGameEffects(float deltaTime)
        {
            foreach (var effectSpec in appliedEffects)
            {
                if (effectSpec.define.durationPolicy == GameEffectDurationType.Instant)
                {
                    continue;
                }
                
                effectSpec.TickDuration(deltaTime);

                if (effectSpec.TickPeriodic(deltaTime))
                {
                    effectSpec.ApplyModifiers();
                }
            }
            
            CleanExpiredEffects();
        }
        
        private void CleanExpiredEffects()
        {
            appliedEffects.RemoveAll(effect => effect.durationRemaining <= 0);
        }
    }
}