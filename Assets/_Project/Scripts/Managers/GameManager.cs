using System;
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
            private bool _audio = true;
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

            private object parent;

            public Settings(object parent)
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

        public void ValidateAttributes()
        {
            return;
        }

        public string GetResultsString()
        {
            return "FIM DE JOGO!\n" + 
            PlayerAttribute.CLIENT.GetDescription() +
            "\n <b> BOLD TEST </b>\n<i> ITALIC </i>";
        }
    }
}