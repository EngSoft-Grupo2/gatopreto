using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto {
    public class ToggleSoundAndVib : MonoBehaviour {

        public void toggleAudio() {
            GameManager.instance.settings.audio = !GameManager.instance.settings.audio;
        }

        public void toggleVib() {
            GameManager.instance.settings.vibration = !GameManager.instance.settings.vibration;
        }
    }
}