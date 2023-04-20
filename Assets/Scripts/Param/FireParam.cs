using System.Collections;
using UnityEngine;

namespace MyTanks2D
{
    public class FireParam : MonoBehaviour
    {
        private bool _canFire = true;

        [SerializeField, Range(0.1f, 5f)] private float _timebetweenFire = 1f;
        [SerializeField] private Projectile _prefab;
        [SerializeField] private Transform _firepoint;
        private PoolParam _pool;
        [SerializeField] private SideType _side;
        public SideType GetSide => _side;

        private void Start()
        {
            _pool = FindObjectOfType<PoolParam>();
        }

        public void OnFire()
        {
            if (_canFire == false) return;
            _canFire = false;

            Projectile bullet = Instantiate(_prefab, _firepoint.position, _firepoint.rotation);
            bullet.transform.parent = _pool.transform;
            bullet.SetParams(transform.eulerAngles.ConvertRotationFromType(), GetSide);
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            _canFire = false;
            yield return new WaitForSeconds(_timebetweenFire);
            _canFire = true;
        }
    }
}
