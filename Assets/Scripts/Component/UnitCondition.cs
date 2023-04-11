using UnityEngine;

namespace MyTanks2D
{
    public class UnitCondition : MonoBehaviour
    {
        [SerializeField] protected int _health = 1;

        public virtual void SetDamage(int damage)
        {
            _health -= damage;
            GameSystem.Instance.TutorialManager.OnEvent(TutorialEvent.PlayerKillEnemy);

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
