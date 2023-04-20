using UnityEngine;
using UnityEngine.InputSystem;

namespace MyTanks2D
{
    [RequireComponent(typeof(MoveParam), typeof(FireParam))]
    public class PlayerController : MonoBehaviour
    {
        private MoveParam _moveComp;
        private FireParam _fireComp;
        private DirectionType _lastType;

        [SerializeField] private InputAction _move;
        [SerializeField] private InputAction _fire;

        private void Start()
        {
            _moveComp = GetComponent<MoveParam>();
            _fireComp = GetComponent<FireParam>();

            _move.Enable();
            _fire.Enable();
        }

        private void Update()
        {
            FireMainGun();
            MovementPlayer();
        }

        private void FireMainGun()
        {
            float fire = _fire.ReadValue<float>();

            if (fire == 1f)
            {
                _fireComp.OnFire();
                GameSystem.Instance.TutorialManager.OnEvent(TutorialEvent.PlayerFire);
            }
        }

        public void MovementPlayer()
        {
            Vector2 direction =  _move.ReadValue<Vector2>();

            DirectionType type;
            if (direction.x != 0f && direction.y != 0f)
            {
                type = _lastType;
            }
            else if (direction.x == 0f && direction.y == 0f) return;
            else type = _lastType = direction.ConvertDirectionFromType();

            if (direction.x != 0f || direction.y != 0f) GameSystem.Instance.TutorialManager.OnEvent(TutorialEvent.PlayerMovement);

            _moveComp.OnMove(type);
        }


        private void OnDestroy()
        {
            _move.Dispose();
            _fire.Dispose();
        }
    }
}   
