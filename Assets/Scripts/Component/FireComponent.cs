using System.Collections;
using UnityEngine;

namespace MyTanks2D
{
    public class FireComponent : MonoBehaviour
    {
        private bool _canFire = true;

        [SerializeField, Range(0.1f, 5f)] private float _timebetweenFire = 1f;
        [SerializeField] private Projectile _prefab;
        [SerializeField] private Transform _firepoint;
        [SerializeField] private SideType _side;
        public SideType GetSide => _side;

    public void OnFire()
        {
            if (!_canFire) return;
            _canFire = false;

            var bullet = Instantiate(_prefab, _firepoint.transform.position, transform.rotation);
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
