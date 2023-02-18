using UnityEngine;

namespace MyTanks2D
{
    [RequireComponent(typeof(MoveParam))]
    public class Projectile : MonoBehaviour
    {
        private SideType _side;
        private DirectionType _direction;
        private MoveParam _moveComp;

        [SerializeField, Range(1f, 5f)] private int _damage = 1;
        [SerializeField] private float _lifeTime = 4f;

        private void Start()
        {
            _moveComp = GetComponent<MoveParam>();
            Destroy(gameObject, _lifeTime);
        }

        public void SetParams(DirectionType direction, SideType side) => (_direction, _side) = (direction, side);

        private void Update()
        {
            _moveComp.OnMove(_direction);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var fire = collision.GetComponent<FireParam>();

            if (fire != null)
            {
                if (fire.GetSide == _side) return;

                var condition = collision.GetComponent<UnitCondition>();
                condition.SetDamage(_damage);
                Destroy(gameObject);
                return;
            }

            var cell = collision.GetComponent<CellCondition>();

            if (cell != null)
            {
                if (cell.DestroyProjectile) Destroy(gameObject);
                if (cell.DestroyCell) Destroy(cell.gameObject);
                return;
            }
        }
    }
}
