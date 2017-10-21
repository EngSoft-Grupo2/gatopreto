using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
	[System.Serializable]
	public class CardDecision {

		[Tooltip("Text shown when the card is slid.")]
		public string decisionDescription = "";

		[Tooltip("Card effects.")]
		public CardEffect[] decisionEffects;
	}
}