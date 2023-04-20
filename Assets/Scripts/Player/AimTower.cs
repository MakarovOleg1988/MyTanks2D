using UnityEngine;
using UnityEngine.InputSystem;

namespace MyTanks2D
{
    public class AimTower : MonoBehaviour
    {
        [SerializeField, Range(1f, 40f)] private float _speedRotationTower = 20f;
        [SerializeField] private GameObject _tower;
        private NewControls _controller;

        private void Awake()
        {
            _controller = new NewControls();
        }

            private void OnEnable()
        {
            _controller.Enable();
        }

        private void Update()
        {
            RotationTower();
        }

        public void RotationTower()
        {
            float direction = _controller.NewActionMap.RotationTower.ReadValue<float>();

            _tower.transform.Rotate(Vector3.forward, direction * _speedRotationTower * Time.deltaTime);

        }

        private void OnDestroy()
        {
            _controller.Disable();
        }
    }
}
