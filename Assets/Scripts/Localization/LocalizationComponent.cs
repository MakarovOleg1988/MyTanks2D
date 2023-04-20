using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class LocalizationComponent: MonoBehaviour
    {
        private Dictionary<string, string> _parameters;

        [SerializeField] private string key;
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        
        public string Key
        {
            get => key;
            set
            {
                key = value;
                UpdateTerm();
            }
        }

        private void OnEnable()
        {
            Localization.OnLanguegeChanged += UpdateTerm;
            UpdateTerm();
        }

        private void Awake()
        {
            if (_textMeshPro is null)_textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        private void OnValidate()
        {
            if (_textMeshPro is null) _textMeshPro = GetComponent<TextMeshProUGUI>();

            UpdateTerm();
        }

        private void UpdateTerm()
        {
            _textMeshPro.text = Localization.GetTerm(key, _parameters);
        }

        public void SetParameters(Dictionary<string, string> parameters)
        {
            _parameters = parameters;
            UpdateTerm();
        }

        private void OnDisable()
        {
            Localization.OnLanguegeChanged -= UpdateTerm;
        }
    }
}
