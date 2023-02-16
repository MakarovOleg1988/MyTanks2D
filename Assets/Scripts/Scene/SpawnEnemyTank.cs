using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyTanks2D
{
    public class SpawnEnemyTank : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyTank;
        private Transform _spawnPoint;
        [Space, SerializeField] private int _volumeEnemy;
        private bool _canSpawn = true;

        private float _timebetweenFire;

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
                if (!_canSpawn) return;
            {
                    var enemy = Instantiate(_enemyTank, _spawnPoint.transform.position, transform.rotation);
                    StartCoroutine(Timer());
                }
            }
        }

        private IEnumerator Timer()
        {
            _canSpawn = false;
            _timebetweenFire = Random.Range(15f, 30f);
            yield return new WaitForSeconds(_timebetweenFire);
            _canSpawn = true;
        }
    }
}
