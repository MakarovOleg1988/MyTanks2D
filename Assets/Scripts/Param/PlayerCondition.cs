using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MyTanks2D
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerCondition : UnitCondition
    {
        private Vector3 _startPosition;
        [SerializeField] private Slider _healthBar;
        [Space, SerializeField] private float _ImmortalTime = 0.2f;
        [SerializeField] private float _immortalSwitch = 0.2f;
        private bool _immortal;
        private int _maxHealth;
        [Space(10f), SerializeField] private SpriteRenderer[] _sprites;


        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        private void Start()
        {
            MaxHealth = CurrentHealth;
            _healthBar.value = MaxHealth - CurrentHealth;
            _healthBar.maxValue = MaxHealth;
            _startPosition = transform.position;
            SpriteRenderer[] _sprites = new SpriteRenderer[4];
        }

        public override void SetDamage(int damage)
        {
            if (_immortal) return;

            CurrentHealth -= damage;
            _healthBar.value = MaxHealth - CurrentHealth;

            if (CurrentHealth <= 0)
            {
                transform.position = _startPosition;
                StartCoroutine(OnImmortal());
                //Destroy(gameObject);
            }
        }

        private IEnumerator OnImmortal()
        {
            _immortal = true;

            while (_ImmortalTime > 0f)
            {
                for (int i = 0; i <= _sprites.Length - 1; i++)
                {
                    _sprites[i].enabled = !_sprites[i];
                    _ImmortalTime -= Time.deltaTime;
                    yield return new WaitForSeconds(_immortalSwitch);
                }
            }

            _immortal = false;
            _sprites[0].enabled = true;
            _sprites[1].enabled = true;
            _sprites[2].enabled = true;
            _sprites[3].enabled = true;
        }
    }
}
