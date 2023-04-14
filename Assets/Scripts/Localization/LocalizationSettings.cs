using UnityEngine;

namespace MyTanks2D
{
    [CreateAssetMenu(fileName = "Localization_setting.asset", menuName = "Localization/Create Localization Setting")]
    public class LocalizationSettings : ScriptableObject
    {
        private static LocalizationSettings _instance;

        public static LocalizationSettings Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = Resources.Load<LocalizationSettings>("Localization_setting");
                }

                return _instance;
            }
        }

        public string PrefKey = "lang";
        public SystemLanguage DefaultLanguage = SystemLanguage.English;
        public SupportedLanguage[] SupportedLanguages;
    }
}
