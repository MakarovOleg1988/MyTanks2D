using UnityEngine;

namespace MyTanks2D
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private float _speedMove = 1f;

        public void OnMove(DirectionType type)
        {
            transform.position += type.ConvertTypeFromDirection() * (_speedMove * Time.deltaTime);
            transform.eulerAngles = type.ConvertTypeFromRotation();
        }
    }
}
