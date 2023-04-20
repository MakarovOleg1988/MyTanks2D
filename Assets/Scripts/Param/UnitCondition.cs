using UnityEngine;

namespace MyTanks2D
{
    public class UnitCondition : MonoBehaviour
    {
        [SerializeField] private int _currenthealth = 1;

        public int CurrentHealth 
        {
            get { return _currenthealth; }
            set { _currenthealth = value; }
        }

        public virtual void SetDamage(int damage)
        {
            _currenthealth -= damage;
            GameSystem.Instance.TutorialManager.OnEvent(TutorialEvent.PlayerKillEnemy);

            if (_currenthealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
