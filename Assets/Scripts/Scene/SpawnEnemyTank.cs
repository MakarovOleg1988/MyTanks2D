using System.Collections;
using UnityEngine;

namespace MyTanks2D
{
    public class SpawnEnemyTank : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyTank;
        private Transform _spawnPoint;
        [Space, SerializeField] private int _volumeEnemy;
        private bool _canSpawn = true;

        private float _timebetweenSpawn;

        private void Start()
        {
            _spawnPoint = GetComponent<Transform>();
        }

        private void Update()
        {
            SpawnTank();
        }

        public void SpawnTank()
        {
            for (int i = 0; i < _volumeEnemy; i++)
            {
                if (_canSpawn == false) return;
            {
                    GameObject enemy = Instantiate(_enemyTank, _spawnPoint.transform.position, Quaternion.identity);
                    enemy.transform.parent = transform;
                    StartCoroutine(Timer());
                }
            }
        }

        private IEnumerator Timer()
        {
            _canSpawn = false;
            _timebetweenSpawn = Random.Range(5f, 15f);
            yield return new WaitForSeconds(_timebetweenSpawn);
            _canSpawn = true;
        }
    }
}
