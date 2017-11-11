using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjetoGatoPreto
{
    [RequireComponent(typeof(Player))]
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager instance
        {
            get
            {
                if (_instance == null)
                {
                    var obj = new GameObject("Game Manager");
                    _instance = obj.AddComponent<GameManager>();
                }
                return _instance;
            }
        }

        public class Settings
        {
            private bool _audio;
            public bool audio
            {
                set { _audio = value; }
                get { return _audio; }
            }

            private bool _vibration = true;
            public bool vibration
            {
                set { _vibration = value; }
                get { return _vibration; }
            }

            private Object parent;

            public Settings(Object parent)
            {
                this.parent = parent;
            }
        }
        public Settings settings;

        public Player player;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
                settings = new Settings(this);
                player = GetComponent<Player>();
            }
        }
    }
}