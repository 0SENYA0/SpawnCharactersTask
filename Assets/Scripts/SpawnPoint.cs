using UnityEngine;

namespace DefaultNamespace
{
	public class SpawnPoint : MonoBehaviour
	{
		[SerializeField] private Enemy _enemyPrefab;
		[SerializeField] private Base _base;

		private Transform _transform;

		private void Awake() =>
			_transform = transform;

		public void CreateEnemy()
		{
			Enemy enemy = Instantiate(_enemyPrefab, _transform.position, Quaternion.identity);
			enemy.MoveToBase(_base.transform);
		}
	}
}