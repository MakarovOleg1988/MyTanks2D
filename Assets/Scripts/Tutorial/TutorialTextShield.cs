using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MyTanks2D
{
    public class TutorialTextShield : MonoBehaviour, IEventAssistant
    {
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _placeForText;

        public void SetText(string text)
        {
            IEventAssistant.SendSetInputText();
            StartCoroutine(ViewNameOfGame(text));
        }

        private IEnumerator ViewNameOfGame(string text)
        {
            _text.text = "";

            for (int i = 0; i < text.Length; i++)
            {
                _text.text += text[i];
                yield return new WaitForSeconds(0.1f);
            }
        }

        public void SetPanel()
        {
            _placeForText.SetActive(true);
        }

    }
}
