using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                    obj.AddComponent<AudioSource>();
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
                set {
                    _audio = value;
                }
                get { return _audio; }
            }

            private bool _vibration = true;
            public bool vibration
            {
                set {
                    _vibration = value;
                }
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
        public AudioSource audioSource;

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
                audioSource = GetComponent<AudioSource>();
            }
        }

        public void ValidateAttributes()
        {
            System.Random r = new System.Random();
            float minAttribute = 10f;

            foreach (int i in Enumerable.Range(1, player.attributeValues.Length-1).OrderBy(x => r.Next()))
            {
                if (player[(PlayerAttribute) i] < minAttribute)
                {
                    ReferencesManager.instance.modal
                        .GetComponent<ResultsModal>()
                        .OpenModal(GetGameOverString((PlayerAttribute) i), true, true, false);
                    break;
                }
            }

            return;
        }

        public string GetGameOverString(PlayerAttribute attribute)
        {
            switch(attribute)
            {
                case PlayerAttribute.MONEY:
                    return ":(\n\n" +
                            "Suas decisões fizeram com que <color=red>o orçamento do projeto acabasse se esgotando</color>!\n" +
                            "No Extreme Programming, é uma boa prática estimar o orçamento a partir de sistemas prontos e rodando, ao invéz de confiar em um planejamento feito antes.\n" +
                            "Para saber mais sobre decisões de orçamento no contexto do XP, <a href=http://wiki.c2.com/?CostingExtremeProgramming>clique aqui</a>.";
                case PlayerAttribute.STAFF:
                    return ":(\n\n" +
                           "Suas decisões fizeram com que <color=red>a equipe não tenha mais confiança para continuar no projeto</color>!\n" +
                           "No Extreme Programming, o trabalho em equipe é enfatizado. Gerentes, clientes e desenvolvedores são parceiros iguais em uma equipe colaborativa de desenvolvimento.\n" +
                           "Para saber mais sobre a equipe de desenvolvimento do XP, <a href=https://atlaz.io/blog/extreme-programming-team/>clique aqui</a>.";
                case PlayerAttribute.QUALITY:
                    return ":(\n\n" +
                           "Suas decisões fizeram com que <color=red>a qualidade do software ficasse insatisfatória</color>!\n" +
                           "No Extreme Programming, a qualidade do software se adapta às constantes mudanças de requisitos dos clientes.\n" +
                           "Para saber mais sobre a qualidade de software no XP, <a href=http://wiki.c2.com/?ExtremeProgrammingQualityAssurance>clique aqui</a>.";
                case PlayerAttribute.CLIENT:
                    return ":(\n\n" +
                           "Suas decisões fizeram com que <color=red>o cliente quisesse cancelar o projeto</color>!\n" +
                           "No Extreme Programming, o cliente é o papel mais importante em um projeto: ele é responsável por prover os requisitos e medir a qualidade.\n" +
                           "Para saber mais sobre o papel dos clientes no XP, <a href=http://researcharchive.vuw.ac.nz/handle/10063/877>clique aqui</a>.";
            }
            return "";
        }

        public string GetResultsString()
        {
            return "FIM DE JOGO!\n";
            /*       ""
            PlayerAttribute.CLIENT.GetDescription() +
            "\n <b> BOLD TEST </b>\n<i> ITALIC </i>\n" +
            "This is a link:\n<a href=https://github.com/EngSoft-Grupo2/gatopreto>Click</a>";*/
        }
    }
}