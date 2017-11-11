using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MenuButton
    {
        public string sceneName;

        public override void Action()
        {
            base.Action();
            SceneManager.LoadScene(sceneName);
        }
    }
}