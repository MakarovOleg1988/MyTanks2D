using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MyTanks2D
{
    public class LocalizationTextField : MonoBehaviour
    {
        [SerializeField] Text _key_Back_Main_Menu;
        [SerializeField] private LocalizationType _language;
        [SerializeField] private LocalizationStruct _localizationStruct;

        private void OnValidate()
        {
            switch (_language)
            {
                case LocalizationType.Rus:
                    {
                        _key_Back_Main_Menu.text = _localizationStruct.Rus_Back_Main_Menu;
                    }; break;
                case LocalizationType.Eng:
                    {
                        _key_Back_Main_Menu.text = _localizationStruct.Eng_Back_Main_Menu;
                    }; break;

            }
        }
    }
}
