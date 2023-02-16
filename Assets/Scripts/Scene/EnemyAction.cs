using UnityEngine;

namespace MyTanks2D
{
    [RequireComponent(typeof(MoveComponent), typeof(FireComponent))]
    public class EnemyAction : MonoBehaviour
    {
        private MoveComponent _moveComp;
        private FireComponent _fireComp;
        private DirectionType _direction;

        private void Start()
        {
            _moveComp = GetComponent<MoveComponent>();
            _fireComp = GetComponent<FireComponent>();
        }

        private void FixedUpdate()
        {
            _fireComp.OnFire();
            _moveComp.OnMove(_direction);

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.GetComponent<EnemyAction>()) return;

            var way = Random.Range(0, 3);

            _direction = (DirectionType)way;
        }
    }
}
