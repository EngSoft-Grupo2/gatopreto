using System;
using System.ComponentModel;

namespace ProjetoGatoPreto
{
    // See https://github.com/EngSoft-Grupo2/gatopreto/issues/5 for reference
    public enum PlayerAttribute
    {
        NONE, // DO NOT REMOVE THIS

        [Description("Dinheiro")]
        MONEY,

        [Description("Pessoal")]
        STAFF,

        [Description("Qualidade do produto")]
        QUALITY,

        [Description("Satisfação dos clientes")]
        CLIENT
    }
}