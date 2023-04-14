using UnityEngine;

namespace MyTanks2D
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _winPanel;
        private PlayerController _player;

        public static GameSystem Instance { get; private set; }
        public TutorialManager TutorialManager;

        private void Awake()
        {
            Instance = this;
            _player = GetComponent<PlayerController>();
        }

        private void Start()
        {
            TutorialManager.OnEvent(TutorialEvent.GameStart);
        }

        private void Update()
        {
            EnemyAction[] _enemes = FindObjectsOfType<EnemyAction>();

            foreach (var enemy in _enemes)
            {
                if (enemy == null)
                {
                    _player.enabled = false;
                    _winPanel.SetActive(true);
                }
            }
        }
    }
}
