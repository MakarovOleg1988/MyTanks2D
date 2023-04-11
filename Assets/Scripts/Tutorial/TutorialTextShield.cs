using UnityEngine;
using UnityEngine.UI;

namespace MyTanks2D
{
    public class TutorialTextShield : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _placeForText;

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void SetPanel()
        {
            _placeForText.SetActive(true);
        }

    }
}
