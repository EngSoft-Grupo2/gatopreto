using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
	public class Card : MonoBehaviour
	{
		public CardData defaultCard;
		public CardData Data
		{
			get
			{
				return data;
			}
			set
			{
				data = value;
				UpdateCard();
			}
		}
		private CardData data;

		private Image cardTexture;
		private Text cardDescriptionText;
		private Text leftDecisionText;
		private Text rightDecisionText;
		private Text helpText;

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			cardTexture = ReferencesManager.instance.cardFront.GetComponent<Image>();
			cardDescriptionText = ReferencesManager.instance
				.cardDescriptionText
				.GetComponent<Text>();
			leftDecisionText = ReferencesManager.instance
				.leftDecisionText
				.GetComponent<Text>();
			rightDecisionText = ReferencesManager.instance
				.rightDecisionText
				.GetComponent<Text>();
			helpText = ReferencesManager.instance
				.helpText
				.GetComponent<Text>();
		}

		void UpdateCard()
		{
			cardTexture.sprite = Data.cardTexture;
			cardDescriptionText.text = Data.cardDescription;
			leftDecisionText.text = Data.leftDecision.decisionDescription;
			rightDecisionText.text = Data.rightDecision.decisionDescription;
			helpText.text = Data.helpText;
		}

	}
}