using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
    public class DropZone : MonoBehaviour
    {

        void OnTriggerEnter2D (Collider2D other)
        {
            Debug.Log ("Triggered");
        }

    }
}