// [Implements: https://github.com/EngSoft-Grupo2/gatopreto/issues/22]

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
#if UNITY_EDITOR
    using UnityEditor;
    [CreateAssetMenu (fileName = "CardData", menuName = "Card")]
#endif 
    public class CardData : ScriptableObject
    {
        [Header ("Card Data")]

        [Tooltip("Card identifier. If empty, the file name will be used.")]
        public string cardName = "";

        [Tooltip("Category this card will fall into. NONE by default.")]
        public CardCategory cardCategory = CardCategory.NONE;

        [Tooltip("Image used by this card in the interface. Make sure it is in the proper resolution.")]
        public Sprite cardTexture;

        [Tooltip("Card description shown in the in-game interface.")]
        [TextArea]
        public string cardDescription = "";

        [Tooltip("[<] decision.")]
        public CardDecision leftDecision;

        [Tooltip("[>] decision.")]
        public CardDecision rightDecision;

        [Tooltip("Help text.")]
        [TextArea]
        public string helpText;

        [Tooltip("Bibliography/sources.")]
        [TextArea]
        public string bibliography;
    }
}