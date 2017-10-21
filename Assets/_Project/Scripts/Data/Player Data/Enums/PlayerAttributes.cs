namespace ProjetoGatoPreto
{
    // See https://github.com/EngSoft-Grupo2/gatopreto/issues/5 for reference
    public enum PlayerAttribute
    {
        NONE, // DO NOT REMOVE THIS
        MONEY,
        STAFF,
        QUALITY,
        CLIENT
    }

    public static class PlayerAttributeExtensions
    {
        public static string GetString (this PlayerAttribute attr)
        {
            switch (attr)
            {
                case PlayerAttribute.NONE:
                    return "";
                case PlayerAttribute.MONEY:
                    return "Dinheiro";
                case PlayerAttribute.STAFF:
                    return "Pessoal";
                case PlayerAttribute.QUALITY:
                    return "Qualidade do produto";
                case PlayerAttribute.CLIENT:
                    return "Satisfação dos clientes";
                default:
                    return attr.ToString ();
            }
        }
    }
}