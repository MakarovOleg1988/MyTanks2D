using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTanks2D
{
    public class UnitParam : MonoBehaviour
    {
        [SerializeField, Range(1f, 10f)] protected float _speedMove;
        [SerializeField, Range(1f, 5f)] protected float _health;
        [SerializeField, Range(-5f, 5f)] protected float _timebetweenFire;
        [Space, SerializeField] protected GameObject _simplebullets;
        [SerializeField] protected Transform _firepoint;
    }
}
