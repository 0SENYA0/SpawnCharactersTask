using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private List<SpawnPoint> _spawnPoints;

		private WaitForSeconds _waitForSeconds;

		private void Awake() =>
			_waitForSeconds = new WaitForSeconds(2f);

		private void Start() =>
			StartCoroutine(InstantiateEnemyCoroutine());

		private SpawnPoint GetRandomPoint() =>
			_spawnPoints[Random.Range(0, _spawnPoints.Count)];

		private IEnumerator InstantiateEnemyCoroutine()
		{
			while (true)
			{
				SpawnPoint spawnPoint = GetRandomPoint();
				spawnPoint.CreateEnemy();
				
				yield return _waitForSeconds;
			}
		}
	}
}