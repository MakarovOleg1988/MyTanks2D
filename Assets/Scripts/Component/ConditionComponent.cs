using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTanks2D
{
    public class ConditionComponent : MonoBehaviour
    {
        [SerializeField] protected int _health = 1;
        public virtual void SetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0) Destroy(gameObject);
        }
    }
}
