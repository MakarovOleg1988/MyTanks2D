using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "localization_setting.asset", menuName = "Localization/Create Setting")]
    public class LocalizationSettings : ScriptableObject
    {
        private static LocalizationSettings _instance;

        public static LocalizationSettings Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = Resources.Load<LocalizationSettings>("localization_setting");
                }
                return _instance;
            }
        }

        public string PrefKey = "lang";
        public SystemLanguage DefaultLanguage = SystemLanguage.English;
        public SupportedLanguage[] SupportedLanguages;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (SupportedLanguages.Length == 0)
            {
                CreateDefaultLanguage();
            }

            CheckAllLanguages();
        }

        [ContextMenu("Check All Terms")]
        private void CheckAllterms()
        {
            Dictionary<SystemLanguage, HashSet<string>> keys = new Dictionary<SystemLanguage, HashSet<string>>();
            HashSet<string> uniqueKeys = new HashSet<string>();

            foreach (var lang in SupportedLanguages)
            {
                var file = Resources.Load<LocalizationResource>(lang.ResourceFile);
                keys[lang.Language] = new HashSet<string>();

                if (file.Terms == null) continue;
                
                foreach (var term in file.Terms)
                {
                    uniqueKeys.Add(term.Key);
                    keys[lang.Language].Add(term.Key);
                }
            }

            foreach (var langPair in keys)
            {
                var keySet = langPair.Value;
                keySet.SymmetricExceptWith(uniqueKeys);
                if (keySet.Count != 0)
                {
                    foreach (var key in keySet)
                    {
                        Debug.LogWarning($"Key <b>{key}</b> not found in {langPair.Key}");
                    }
                }
            }
        }


        private void CheckAllLanguages()
        {
            HashSet<SystemLanguage> usedLanguages = new HashSet<SystemLanguage>();

            foreach (var lang in SupportedLanguages)
            {
                if (!IsExists(lang.ResourceFile))
                {
                    lang.ResourceFile = CreateNewResource(lang.Language);    
                }

                if (usedLanguages.Contains(lang.Language))
                {
                    Debug.LogWarning($"{lang.Language} already is used. Please fix it");
                }
                else
                {
                    usedLanguages.Add(lang.Language);
                }
            }
        }

        private string CreateNewResource(SystemLanguage language)
        {
            var name = $"loc_{language.ToString().ToLower()}";

            if (!IsExists(name))
            {
                UnityEditor.AssetDatabase.CreateAsset(
                    CreateInstance<LocalizationResource>(), $"Assets/Resources/{name}.asset");
                UnityEditor.AssetDatabase.SaveAssets();
            }
            return name;
        }

        private bool IsExists(string ResourceFile)
        {
            return Resources.Load<LocalizationResource>(ResourceFile) != null;
        }

        private void CreateDefaultLanguage()
        {
            DefaultLanguage = Application.systemLanguage;

            SupportedLanguages = new SupportedLanguage[]
            {
                new SupportedLanguage
                {
                    Language = DefaultLanguage
                }
            };
        }
       
#endif
    }
}

