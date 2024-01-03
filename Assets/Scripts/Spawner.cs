using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private List<SpawnPoint> _spawnPoints;
		[SerializeField] private Enemy _enemyPrefab;
		[SerializeField] private Base _base;

		private WaitForSeconds _waitForSeconds;
		private Quaternion _rotation;
		private Vector3 _randomPosition;

		private void Awake() =>
			_waitForSeconds = new WaitForSeconds(2f);

		private void Start()
		{
			StartCoroutine(InstantiateEnemyCoroutine());
		}

		private Vector3 GetRandomPosition() =>
			_spawnPoints[Random.Range(0, _spawnPoints.Count)].Position;

		private Quaternion GetRotation() =>
			Quaternion.LookRotation(_base.Position.normalized);

		private IEnumerator InstantiateEnemyCoroutine()
		{
			while (true)
			{
				_randomPosition = GetRandomPosition();
				Quaternion rotation = GetRotation();

				Enemy enemy = Instantiate(_enemyPrefab, _randomPosition, rotation);
				enemy.MoveToBase(_base.Position);
				
				yield return _waitForSeconds;
			}
		}
	}
}