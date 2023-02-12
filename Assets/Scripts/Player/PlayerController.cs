using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace MyTanks2D
{
    public class PlayerController : PlayerParam
    {
        private NewControls _Controller;
        private Rigidbody2D _rbPlayer;

        private void Awake()
        {
            _Controller = new NewControls();
            _Controller.NewActionMap.Enable();
            _Controller.NewActionMap.Fire.performed += SimpleFire;
        }

        private void Start()
        {
            _rbPlayer = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var direction = _Controller.NewActionMap.Movement.ReadValue<Vector2>();
            var velocity = new Vector3(direction.x, direction.y, 0f);
            transform.position += velocity * GetMovementPlayer() * Time.deltaTime;
        }

        private void SimpleFire(CallbackContext context)
        {
            if (_timebetweenFire <= 0)
            {
                var bullet = Instantiate(_simplebullets, _firepoint.transform.position, Quaternion.identity);
                _timebetweenFire = 2f;
            }
            else _timebetweenFire -= Time.deltaTime;
        }

        private void OnDestroy()
        {
            _Controller.Disable();
        }
    }
}   
