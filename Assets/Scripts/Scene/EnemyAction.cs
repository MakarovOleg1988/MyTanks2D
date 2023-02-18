using UnityEngine;
using System;
using Random = System.Random;

namespace MyTanks2D
{
    [RequireComponent(typeof(MoveParam), typeof(FireParam))]
    public class EnemyAction : MonoBehaviour
    {
        private MoveParam _moveComp;
        private FireParam _fireComp;
        [SerializeField] private DirectionType _direction;

        [SerializeField] private Transform _CheckWall;

        private void Start()
        {
            _moveComp = GetComponent<MoveParam>();
            _fireComp = GetComponent<FireParam>();
        }

        private void FixedUpdate()
        {
            CheckWay();
            _fireComp.OnFire();
            _moveComp.OnMove(_direction);

        }

        private void CheckWay()
        {
            RaycastHit2D wallInfo = Physics2D.Raycast(_CheckWall.position, Vector2.up, 0.1f);

            if (wallInfo.collider == true)
            {
                DirectionType value = RandomEnumValue<DirectionType>();

                _direction = value;
            }
        }

        static Random _R = new Random();
        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }
    }
}
