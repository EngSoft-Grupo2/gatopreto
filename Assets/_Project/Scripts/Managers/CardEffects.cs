using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
    public class CardEffects : MonoBehaviour
    {
        public CardEffect[] RightEffects;
        public CardEffect[] LeftEffects;

        private void OnSwipeRight()
        {
            foreach (CardEffect effect in RightEffects)
            {
                GameManager.instance.player.ApplyEffect(effect);
            }
        }

        private void OnSwipeLeft()
        {
            foreach (CardEffect effect in LeftEffects)
            {
                GameManager.instance.player.ApplyEffect(effect);
            }
        }
    }
}