using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
    // TODO: Define card categories, see https://github.com/EngSoft-Grupo2/gatopreto/issues/22 for reference
    public enum CardCategory
    {
        NONE, // DO NOT REMOVE THIS
        TYPE1,
        TYPE2
    }

    public static class CardCategoryExtensions
    {
        public static string GetString (this CardCategory cat)
        {
            switch (cat)
            {
                case CardCategory.NONE:
                    return "";
                case CardCategory.TYPE1:
                    return "?";
                case CardCategory.TYPE2:
                    return "?";
                default:
                    return cat.ToString ();
            }
        }
    }
}