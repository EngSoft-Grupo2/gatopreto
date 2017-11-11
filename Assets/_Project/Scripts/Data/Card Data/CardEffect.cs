using System.Collections;
using System.Collections.Generic;
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
        public double value = 0.0;

        [Tooltip("Special event triggered upon using this effect. Not implemented properly yet, can be ignored, for now.")]
        public bool callEvent;
    }
}