using UnityEngine;

namespace MyTanks2D
{
    public class GameSystem : MonoBehaviour
    {
        public static GameSystem Instance { get; private set; }
        public TutorialManager TutorialManager;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            TutorialManager.OnEvent(TutorialEvent.GameStart);
        }

    }
}
