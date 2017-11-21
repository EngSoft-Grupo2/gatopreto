using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
    public class OpenWiki : MonoBehaviour
    {


        public void onClick()
        {
            Application.OpenURL("https://github.com/EngSoft-Grupo2/gatopreto/wiki");
        }
    }
}