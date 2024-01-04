using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
	public class Base : MonoBehaviour
	{
		[SerializeField] private float _areaLength = 3.5f;
		[SerializeField] private float _speed = 2f;

		private Transform _transform;
		private Vector3 _basePosition;
		private Vector3 _targetPosition;

		public Vector3 Position => transform.position;

		private void Awake()
		{
			_transform = transform;
			_basePosition = _transform.position;
		}

		private void Start() =>
			ChangeTargetPosition();

		private void Update()
		{
			if (_transform.position == _targetPosition)
				ChangeTargetPosition();
			else
				_transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, Time.deltaTime * _speed);
		}

		private void ChangeTargetPosition() =>
			_targetPosition = _basePosition + new Vector3(Random.Range(0f, _areaLength), 0f, Random.Range(0f, _areaLength));
	}
}