using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjetoGatoPreto
{
	public class CardEffects : MonoBehaviour
	{
		public Effect[] RightEffects;
		public Effect[] LeftEffects;

		private void OnSwipeRight()
		{
			foreach (Effect effect in RightEffects)
			{
				GameManager.instance.player.ApplyEffect(effect);
			}
		}

		private void OnSwipeLeft()
		{
			foreach (Effect effect in LeftEffects)
			{
				GameManager.instance.player.ApplyEffect(effect);
			}
		}
	}
}