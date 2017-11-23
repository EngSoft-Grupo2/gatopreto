using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
    public class Player : MonoBehaviour
    {
        public static float maxAttributeValue = 100f;
        public static float minAttributeValue = 0f;
        public static float lowAttributePercentage = 0.1f;
        public static float highAttributePercentage = 0.8f;
        public static float initValues = 50f;
        internal float[] attributeValues = new float[Enum.GetValues(typeof(PlayerAttribute)).Length];

        public float this [PlayerAttribute i]
        {
            get { return attributeValues[(int) i]; }
            set { attributeValues[(int) i] = value; }
        }

        void OnLevelWasLoaded(int level)
        { 
            ResetValues();
        }

        void ResetValues()
        {
            for (int i = 0; i < attributeValues.Length; i++)
                attributeValues[i] = initValues;

        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Awake()
        {
            ResetValues();
        }

        public void ApplyDecisionEffects(CardDecision decision)
        {
            foreach (CardEffect effect in decision.decisionEffects)
            {
                ApplyEffect(effect);
            }
        }

        public void ApplyEffect(CardEffect effect)
        {
            float oldValue = this[effect.attribute];
            switch (effect.operation)
            {
                case EffectOperation.ADD:
                    this[effect.attribute] += effect.value;
                    break;
                case EffectOperation.MULTIPLY:
                    this[effect.attribute] *= effect.value;
                    break;
                case EffectOperation.SET:
                    this[effect.attribute] = effect.value;
                    break;
            }
            if (effect.callEvent != null)
                effect.callEvent.Invoke();
            ReferencesManager.instance.attributes[(int) effect.attribute]
                .GetComponent<Attribute>()
                .OnValueChange(oldValue, this[effect.attribute]);
        }
    }
}