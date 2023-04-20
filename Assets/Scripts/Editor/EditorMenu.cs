using UnityEditor;
using MyTanks2D;

namespace Assets.Scripts
{
    public static class EditorMenu
    {
        [MenuItem("Localization/English")]
        public static void SetLanguageEnglish()
        {
            Localization.SetLanguage(UnityEngine.SystemLanguage.English);
            UpdateCheckBox();
        }

        [MenuItem("Localization/Russian")]
        public static void SetLanguageRussian()
        {
            Localization.SetLanguage(UnityEngine.SystemLanguage.Russian);
            UpdateCheckBox();
        }

        [MenuItem("Localization/Reload", priority = 200)]
        public static void ReloadLocalization()
        {
            Localization.Load();
        }

        private static void UpdateCheckBox()
        {
            Menu.SetChecked("Localization/English", Localization.CurrentLanguage == UnityEngine.SystemLanguage.English);
            Menu.SetChecked("Localization/Russian", Localization.CurrentLanguage == UnityEngine.SystemLanguage.Russian);
        }

        [InitializeOnLoadMethod]
        public static void LoadCheckbox()
        {
            EditorApplication.delayCall += UpdateCheckBox;
        }

    }
}
