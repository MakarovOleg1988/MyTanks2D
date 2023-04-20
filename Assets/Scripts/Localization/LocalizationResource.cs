using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "localization.asset", menuName = "Localization/Create Resources")]
    public class LocalizationResource : ScriptableObject
    {
        public List<LocalizationTerm> Terms;
    }

    [System.Serializable]
    public class LocalizationTerm
    {
        public string Key;
        public string Value;
    }
}
