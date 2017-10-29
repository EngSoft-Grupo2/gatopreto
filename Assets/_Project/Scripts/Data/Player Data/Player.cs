using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
    public class Player
    {
        public int[] attributeValues = new int[Enum.GetValues(typeof(PlayerAttribute)).Length - 1];

        public void ApplyEffect(CardEffect effect)
        {

        }
    }
}