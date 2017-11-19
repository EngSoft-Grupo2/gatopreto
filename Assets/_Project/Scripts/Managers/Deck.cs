using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
	public class Deck : MonoBehaviour
	{
		public List<CardData> cards;
		public CardData OpenCard
		{
			set
			{
				SetOpenCard(value);
			}
			get
			{
				return _openCard;
			}
		}
		private CardData _openCard;
		private GameObject openCard;
		private Text openCardDescriptionText;

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			openCard = transform.Find("Card Holder/Card").gameObject;
			openCardDescriptionText = transform.Find("Card Description Panel/Text").GetComponent<Text>();
		}

		void SetOpenCard(CardData cardData)
		{
			
			_openCard = cardData;

		}

		public void Shuffle()
		{
			cards.Shuffle();
		}

		public CardData Draw()
		{
			if (cards.Count <= 0)
			{
				return null;
			}
			else
			{
				return cards[0];
			}
		}

		public void Discard()
		{
			OpenCard = null;
			if (cards.Count <= 0)
			{
				cards.RemoveAt(0);
			}
		}
	}
}