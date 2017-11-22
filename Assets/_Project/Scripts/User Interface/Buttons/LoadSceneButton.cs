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
        public Color fadeColor = Color.black;
        public float fadeTime = 0.5f;

        public override void Action()
        {
            Initiate.Fade(sceneName, fadeColor, fadeTime);
            base.Action();
        }
    }
}