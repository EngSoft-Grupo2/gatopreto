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
        public AudioSource audioSource;

        private void Awake()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }

        public virtual void Action()
        {
            if (audioSource && GameManager.instance.settings.audio)
                audioSource.Play();
        }
    }
}