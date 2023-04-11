using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTanks2D
{
    public class CameraAssistant : MonoBehaviour
    {
        private PlayerController _target;
        [Space(10f), SerializeField, Range(0f, 10f)] private float _speedMovementCamera = 6f;

        private void Start()
        {
            _target = transform.parent.GetComponent<PlayerController>();
            transform.parent = null;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.transform.position, _speedMovementCamera * Time.deltaTime);
        }
    }
}
