using UnityEngine;

namespace MyTanks2D
{
    public class CellCondition : MonoBehaviour
    {
        [SerializeField] private bool _destroyProjectile;
        [SerializeField] private bool _destroyCell;

        public bool DestroyProjectile => _destroyProjectile;
        public bool DestroyCell => _destroyCell;
    }
}
