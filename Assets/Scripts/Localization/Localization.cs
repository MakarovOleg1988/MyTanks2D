using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Localization
    {
        public static event Action OnLanguegeChanged;

        private static ILookup<string, string> _termsMap;

        public static SystemLanguage CurrentLanguage { get; private set; }
        public static bool IsLoaded => _termsMap != null;

        public static void Load()
        {
            var lang = PlayerPrefs.GetString(LocalizationSettings.Instance.PrefKey, null);

            if (Enum.TryParse(lang, out SystemLanguage localizationLanguege))
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
            SupportedLanguage language = LocalizationSettings.Instance.SupportedLanguages.FirstOrDefault(x => x.Language == CurrentLanguage);
            LocalizationResource resource = Resources.Load<LocalizationResource>(language.ResourceFile);

            _termsMap = resource.Terms.ToLookup(item => item.Key, item => item.Value);

            OnLanguegeChanged?.Invoke();
        }

        internal static string GetTerm(string key, Dictionary<string, string> _parameters = null)
        {
            if (string.IsNullOrEmpty(key)) return string.Empty;

            if (!IsLoaded) Load();

            string result = _termsMap[key].FirstOrDefault();

            if (result != null)
            {
                if (_parameters != null && _parameters.Count > 0)
                {
                    _parameters.Aggregate(result,
                    (currrent, parameter) => currrent.Replace($"%{parameter.Key}%", parameter.Value));
                }

                return result;
            }

            if (Application.isPlaying) Debug.LogWarning($"{ key} not found in {CurrentLanguage}");

            return $">>{key}<<";
        }

        private static SystemLanguage DetectLanguage()
        {
            SystemLanguage systemLanguage = Application.systemLanguage;

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
            CurrentLanguage = lang;

            PlayerPrefs.SetString(LocalizationSettings.Instance.PrefKey, lang.ToString());
            PlayerPrefs.Save();

            LoadTermsMap();
        }

        public static readonly Regex Plurals = new Regex("(\\[(\\d+-?\\d*:\\w*,?)+\\])");

        public static string GetPlural(string key, int quantity = 1)
        {
            string term = GetTerm(key);
            int qty = CalculatePLuralQuantity(quantity);
            return Plurals.Replace(term, x => PluralReplacer(x, qty));
        }

        private static string PluralReplacer(Capture x, int qty)
        {
            var pluralGroup = x.Value.Trim('[', ']');
            var variants = pluralGroup.Split(',');

            foreach (var variant in variants)
            {
                var data = variant.Split(':');
                var range = new PluralsRange(data[0]);
                if (range.InRange(qty))
                {
                    return data[1];
                }
            }

            return null;
        }

        private static int CalculatePLuralQuantity(int quantity)
        {
            var qty = Mathf.Abs(quantity) % 100;

            if (qty == 0 && quantity > 0)
            {
                qty = 100;
            }
            else
            {
                qty = qty < 20 ? qty : qty % 10;

                if (qty == 0 && quantity > 0)
                {
                    qty = 20;
                }
            }

            return qty;
        }

        private class PluralsRange
        {
            private readonly int max;
            private readonly int min;

            public PluralsRange(string range)
            {
                var values = range.Split('-');
                max = min = int.Parse(values[0]);
                if (values.Length == 2)
                {
                    var secondValue = values[1];
                    max = string.IsNullOrEmpty(secondValue) ? int.MaxValue : int.Parse(secondValue);
                }
            }

            public bool InRange(int val)
            {
                return val >= min && val <= max; 
            }

        }
    }
}
