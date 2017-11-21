using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace ProjetoGatoPreto
{
    [System.Serializable]
    public class CardEffect
    {
        [Tooltip("Affected attribute.")]
        public PlayerAttribute attribute;

        [Tooltip("Effect operation. You can use ADD to subtract and MULTIPLY to divide, and it will work as expected.")]
        public EffectOperation operation = EffectOperation.ADD;

        [Tooltip("Value to apply. You can use negative values to subtract if this is an ADD effect.")]
        public float value = 0.0f;

        [Tooltip("Event triggered when the effect is applied.")]
        public UnityEvent callEvent;
    }
}