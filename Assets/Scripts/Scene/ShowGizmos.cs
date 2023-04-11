using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTanks2D
{
    public class ShowGizmos : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }
    }
}
