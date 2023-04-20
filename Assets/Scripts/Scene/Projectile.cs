using UnityEngine;

namespace MyTanks2D
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        private SideType _side;
        private DirectionType _direction;
        private Rigidbody2D _rbBullet;

        [SerializeField, Range(1f, 5f)] private int _damage = 1;
        [SerializeField, Range(0.1f, 2f)] private float _bulletForce = 1f;
        [SerializeField] private float _lifeTime = 4f;

        private void Start()
        {
            _rbBullet = GetComponent<Rigidbody2D>();
            Destroy(gameObject, _lifeTime);
        }

        public void SetParams(DirectionType direction, SideType side) => (_direction, _side) = (direction, side);

        private void Update()
        {
            _rbBullet.AddForce(transform.up * _bulletForce, ForceMode2D.Impulse); 
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            FireParam fire = collision.GetComponent<FireParam>();

            if (fire != null)
            {
                if (fire.GetSide == _side) return;

                UnitCondition condition = collision.GetComponent<UnitCondition>();
                GameSystem.Instance.TutorialManager.OnEvent(TutorialEvent.PlayerKillEnemy);
                condition.SetDamage(_damage);
                Destroy(gameObject);
                return;
            }

            CellCondition cell = collision.GetComponent<CellCondition>();

            if (cell != null)
            {
                if (cell.DestroyProjectile == true) Destroy(gameObject);
                if (cell.DestroyCell == true) Destroy(cell.gameObject);
                return;
            }
        }
    }
}
