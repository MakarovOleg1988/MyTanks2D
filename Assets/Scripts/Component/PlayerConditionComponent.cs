using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTanks2D
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerConditionComponent : ConditionComponent
    {
        private SpriteRenderer _sprite;
        private Vector3 _startPosition;
        [SerializeField] private float _ImmortalTime = 0.2f;
        [SerializeField] private float _immortalSwitch = 0.2f;
        private bool _immortal;

        private void Start()
        {
            _startPosition = transform.position;
            _sprite = GetComponent<SpriteRenderer>();
        }

        public override void SetDamage(int damage)
        {
            if (_immortal) return;

                _health -= damage;
            transform.position = _startPosition;
            StartCoroutine(OnImmortal());

            if (_health <= 0) Destroy(gameObject);
        }

        private IEnumerator OnImmortal()
        {
            _immortal = true;
            while (_ImmortalTime > 0f)
            {
                _sprite.enabled = !_sprite.enabled;
                _ImmortalTime -= Time.deltaTime;
                yield return new WaitForSeconds(_immortalSwitch);
            }

            _immortal = false;
            _sprite.enabled = true;
        }
    }
}
