using UnityEngine;

namespace MyTanks2D
{
    [CreateAssetMenu(fileName = "Tutorial.asset", menuName = "Tutorial/Create Tutorial")]
    public class TutorialCriptableObject : ScriptableObject
    {
        public TutorialEvent _startTrigger;
        public TutorialSteps[] _steps; 
    }

    [System.Serializable]
    public class TutorialSteps
    {
        public TutorialEvent startTrigger;
        public TutorialAction _tutorialAction;
        public string data;
    }
}