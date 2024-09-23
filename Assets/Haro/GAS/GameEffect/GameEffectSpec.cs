using System;

namespace Haro.GAS
{
    public class GameEffectSpec
    {
        public GameEffectDefine define;

        public AbilitySystem source;
        public AbilitySystem target;

        public float level;
        public float durationRemaining;
        public float totalDuration;
        public float timeUntilPeriodTick;
        public int stackCount;

        private readonly ModifierSpec[] _modSpecs;

        public static GameEffectSpec CreateNew(GameEffectDefine define, AbilitySystem source, float level = 1)
        {
            return new GameEffectSpec(define, source, level);
        }

        private GameEffectSpec(GameEffectDefine define, AbilitySystem source, float level)
        {
            this.define = define;
            this.source = source;
            this.level = level;

            totalDuration = define.duration;
            durationRemaining = totalDuration;
            timeUntilPeriodTick = define.period;
            if (this.define.executeImmediately)
            {
                timeUntilPeriodTick = 0;
            }

            _modSpecs = new ModifierSpec[define.modifierDefines.Length];
            for (int i = 0; i < define.modifierDefines.Length; i++)
            {
                var modifierDefine = define.modifierDefines[i];
                var newSpec = new ModifierSpec(source.attributeSet?.GetAttribute(modifierDefine.attributeName), modifierDefine);

                //check combine
                for (int j = 0; j < i; j++)
                {
                    if (_modSpecs[j].CanCombine(newSpec))
                    {
                        _modSpecs[j].Combine(newSpec);
                        newSpec = null;
                    }
                }

                if (newSpec != null)
                {
                    newSpec.UpdateValue(this);
                    _modSpecs[i] = newSpec;
                }
            }
        }

        public void TickDuration(float deltaTime)
        {
            if (define.durationPolicy == GameEffectDurationType.HasDuration)
            {
                durationRemaining -= deltaTime;
            }
            else
            {
                durationRemaining = 1;
            }
        }

        public bool TickPeriodic(float deltaTime)
        {
            timeUntilPeriodTick -= deltaTime;
            if (timeUntilPeriodTick > 0) return false;

            timeUntilPeriodTick = define.period;
            return define.period > 0;
        }

        public void ApplyModifiers()
        {
            foreach (var modSpec in _modSpecs)
            {
                modSpec.UpdateValue(this);
                modSpec.Apply();
            }
        }
    }
}