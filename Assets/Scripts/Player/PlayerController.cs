using UnityEngine;
using UnityEngine.InputSystem;

namespace MyTanks2D
{
    [RequireComponent(typeof(MoveComponent), typeof(FireComponent))]
    public class PlayerController : MonoBehaviour
    {
        private MoveComponent _moveComp;
        private FireComponent _fireComp;
        private DirectionType _lastType;

        [SerializeField] private InputAction _move;
        [SerializeField] private InputAction _fire;

        private void Start()
        {
            _moveComp = GetComponent<MoveComponent>();
            _fireComp = GetComponent<FireComponent>();

            _move.Enable();
            _fire.Enable();
        }

        private void Update()
        {
            var fire = _fire.ReadValue<float>();
            if (fire == 1f) _fireComp.OnFire();

            var direction = _move.ReadValue<Vector2>();
            DirectionType type;
            if (direction.x != 0f && direction.y != 0f)
            {
                type = _lastType;
            }
            else if (direction.x == 0f && direction.y == 0f) return;
            else type = _lastType = direction.ConvertDirectionFromType();

            _moveComp.OnMove(type);
        }

        private void OnDestroy()
        {
            _move.Dispose();
            _fire.Dispose();
        }
    }
}   
