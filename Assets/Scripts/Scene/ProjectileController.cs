using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTanks2D
{
    public class ProjectileController : ProjectileParam
    {
        void Update()
        {
            MovementBullet();
        }

        void MovementBullet()
        {
            transform.position += transform.forward * _speedMovementBullet * Time.deltaTime;
        }
    }
}
