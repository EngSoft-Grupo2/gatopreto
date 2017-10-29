using System;
using System.ComponentModel;

namespace ProjetoGatoPreto
{
    // TODO: Define card categories, see https://github.com/EngSoft-Grupo2/gatopreto/issues/22 for reference
    public enum CardCategory
    {
        NONE, // DO NOT REMOVE THIS

        [Description("XP")]
        XP,

        [Description("SCRUM")]
        SCRUM
    }
}