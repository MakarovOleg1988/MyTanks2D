using System;
using UnityEngine;

namespace MyTanks2D
{
    public class TutorialManager : MonoBehaviour
    {
        [Header("PrefabCanvas"), SerializeField] private TutorialTextShield _tutorialTextShieldPrefab;
        [Header("PrefabHint"), SerializeField] private GameObject _tutorialHintGOPrefab;
        [Header("PrefabHintUI"), SerializeField] private GameObject _tutorialHintUIPrefab;
        private TutorialTextShield _tutorialTextShield;
        private GameObject _tutorialHintGO;
        private GameObject _tutorialHintUI;
        [Space(30f)] public TutorialCriptableObject[] _tutorialCriptableObject;
        private TutorialCriptableObject _currentScript;

        private int _currentStep;
        private float _lockTimer;

        private bool _isActive => _currentScript != null;
        private TutorialSteps CurrentStep => _currentScript._steps[_currentStep];
        private TutorialSteps NextStep => _currentScript._steps[_currentStep + 1];
        private bool HasNextStep => _currentScript._steps.Length > _currentStep + 1;
        private bool IsLocked => _lockTimer > 0;

        private void StartTutorial(TutorialEvent @event)
        {
            foreach (var script in _tutorialCriptableObject)
            {
                if (script._startTrigger == @event)
                {
                    _currentScript = script;
                    _currentStep = 0;
                    ProcessCurrentSteps();
                    break;
                }
            }
        }

        private void Update()
        {
            if (IsLocked) _lockTimer -= Time.unscaledDeltaTime;

            OnEvent(TutorialEvent.Update);
        }

        private void FinishTutorial()
        {
            _currentScript = null;
            _currentStep = 0;
        }

        public void OnEvent(TutorialEvent @event)
        {
            if (IsLocked) return;

            if (_isActive) ProcessEvent(@event);
            else StartTutorial(@event);
        }

        private void ProcessEvent(TutorialEvent @event)
        {
            if (NextStep.startTrigger == @event)
            {
                PlayNextStep();
            }

            if (!HasNextStep)
            {
                FinishTutorial();
            }
        }

        private void PlayNextStep()
        {
            _currentStep++;
            ProcessCurrentSteps();
        }

        private void ProcessCurrentSteps()
        { 
            switch (CurrentStep._tutorialAction)
            {
                case TutorialAction.ShowText:
                    ShowText(CurrentStep.data);
                    break;
                case TutorialAction.HintOnUI:
                    HintOnUI(CurrentStep.data);
                    break;
                case TutorialAction.HintOnGameObject:
                    HintOnGameObject(CurrentStep.data);
                    break;
                case TutorialAction.Clear:
                    Clear();
                    break;
                case TutorialAction.Wait:
                    Wait(float.Parse(CurrentStep.data));
                    break;
            };
        }

        private void HintOnGameObject(string data)
        {
            GameObject go = GameObject.Find(data);
            if (go == null)
            {
                Debug.Log("GameObject not found");
                return;
            }
            
            if (_tutorialHintGO == null)
            {
                _tutorialHintGO = Instantiate(_tutorialHintGOPrefab);
            }

            _tutorialHintGO.transform.SetParent(go.transform, false);
        }

        private void HintOnUI(string data)
        {
            GameObject go = GameObject.Find(data);
            if (go == null)
            {
                Debug.Log("GameObject not found");
                return;
            }

            if (_tutorialHintUI == null)
            {
                _tutorialHintUI = Instantiate(_tutorialHintUIPrefab);
            }

            _tutorialHintUI.transform.SetParent(go.transform, false);
        }

        private void Wait(float time)
        {
            _lockTimer = time; 
        }

        private void Clear()
        {
            if (_tutorialTextShield != null) Destroy(_tutorialTextShield.gameObject);
            Destroy(_tutorialHintUI);
            Destroy(_tutorialHintGO);
        }

        private void ShowText(string data)
        {
            if (_tutorialTextShield == null)
            {
                _tutorialTextShield = Instantiate(_tutorialTextShieldPrefab);
                _tutorialTextShield.SetPanel();
                _tutorialTextShield.SetText(data);
            }
        }
    }
}
