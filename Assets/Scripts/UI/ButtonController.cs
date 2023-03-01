using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyTanks2D
{
    public class ButtonController : MonoBehaviour, IEventAssistant
    {
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _optionsPanel;

        public void StartGame()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineStartGame());
        }

        private IEnumerator CoroutineStartGame()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Level 1");
        }

        public void Options()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineOptions());
        }

        private IEnumerator CoroutineOptions()
        {
            yield return new WaitForSeconds(0.2f);
            _mainPanel.SetActive(false);
            _optionsPanel.SetActive(true);
        }

        public void QuitGame()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineQuitGame());
        }

        private IEnumerator CoroutineQuitGame()
        {
            yield return new WaitForSeconds(0.2f);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            Application.Quit();
#endif
        }

        public void BackMainMenu()
        {
            IEventAssistant.SendSetButton();
            StartCoroutine(CoroutineBackMainMenu());
        }

        private IEnumerator CoroutineBackMainMenu()
        {
            yield return new WaitForSeconds(0.2f);
            _mainPanel.SetActive(true);
            _optionsPanel.SetActive(false);
        }
    }
}
