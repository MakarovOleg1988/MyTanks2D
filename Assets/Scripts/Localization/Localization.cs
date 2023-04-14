using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyTanks2D
{
    public static class Localization
    {
        private static ILookup<string, string> _termsMap;

        public static SystemLanguage CurrentLanguage { get; private set;}
        public static bool IsLoaded => _termsMap != null;

        public static void Load()
        {
            var lang = PlayerPrefs.GetString(LocalizationSettings.Instance.PrefKey, null);

            if (!Enum.TryParse(lang, out SystemLanguage localizationLanguege))
            {
                CurrentLanguage = localizationLanguege;
            }
            else
            {
                CurrentLanguage = DetectLanguage();
            }

            LoadTermsMap();
        }

        private static void LoadTermsMap()
        {
            var language = LocalizationSettings.Instance.SupportedLanguages.FirstOrDefault(x => x.Language == CurrentLanguage);
            var resource = Resources.Load<LocalizationResource>(language.ResourcesFile);

            _termsMap =  resource.Terms.ToLookup(item => item.Key, item => item.Value);
        }

        internal static string GetTerm(string key, Dictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(key)) return string.Empty;

            if (!IsLoaded) Load();

            var result = _termsMap[key].FirstOrDefault();

            if (result != null)
            {
                if (parameters != null && parameters.Count > 0)
                {
                    parameters.Aggregate(result,
                        (currrent, parameter) => currrent.Replace($"%{parameter.Key}%", parameter.Value));
                }
                return result;

            }

            if (Application.isPlaying) Debug.LogWarning($"{ key} not found in {CurrentLanguage}");

            return $">> {key} <<";
        }

        private static SystemLanguage DetectLanguage()
        {
            var systemLanguage = Application.systemLanguage;

            foreach (var lang in LocalizationSettings.Instance.SupportedLanguages)
            {
                if (lang.Language == systemLanguage)
                {
                    return lang.Language;
                }
            }
            return LocalizationSettings.Instance.DefaultLanguage;
        }

        public static void SetLanguage(SystemLanguage lang)
        {
            PlayerPrefs.SetString(LocalizationSettings.Instance.PrefKey, lang.ToString());
            PlayerPrefs.Save();
        }
    }
}
