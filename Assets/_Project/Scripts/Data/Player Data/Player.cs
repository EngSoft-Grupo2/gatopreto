using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
    public class Player : MonoBehaviour
    {
        public double[] attributeValues = new double[Enum.GetValues(typeof(PlayerAttribute)).Length - 1];

        public void ApplyEffect(CardEffect effect)
        {
            switch (effect.operation)
            {
                case EffectOperation.ADD:
                    attributeValues[(int) effect.attribute] += effect.value;
                    break;
                case EffectOperation.MULTIPLY:
                    attributeValues[(int) effect.attribute] *= effect.value;
                    break;
                case EffectOperation.SET:
                    attributeValues[(int) effect.attribute] = effect.value;
                    break;
            }
            if (effect.callEvent != null)
                effect.callEvent.Invoke();
        }
    }
}