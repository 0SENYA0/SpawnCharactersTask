using UnityEngine;

namespace DefaultNamespace
{
	public class SpawnPoint : MonoBehaviour
	{
		private Transform _transform;

		private void Awake() =>
			_transform = transform;

		public Vector3 Position => _transform.position;	}
}