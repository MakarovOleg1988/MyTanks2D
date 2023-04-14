using System.Collections.Generic;
using UnityEngine;

namespace MyTanks2D
{
    [CreateAssetMenu(fileName = "localization.asset", menuName = "Localization/Create LocalizationResources")]
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
