using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
    public class MenuButton : MonoBehaviour
    {
        public AudioClip audioClip;

        public virtual void Action()
        {
            AudioControl.PlayAudioFromSource(audioClip);
        }
    }
}