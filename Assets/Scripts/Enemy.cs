using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
	public class Enemy : MonoBehaviour
	{
		private Transform _transform;

		private void Awake() =>
			_transform = transform;

		public void MoveToBase(Transform baseTransform) =>
			StartCoroutine(MoveToBaseCoroutine(baseTransform));

		private IEnumerator MoveToBaseCoroutine(Transform baseTransform)
		{
			// Vector3.Distance(_transform.position, baseTransform.position) > 0.1f
			while (true)
			{
				_transform.position = Vector3.MoveTowards(_transform.position,
					baseTransform.position,
					0.1f);

				Rotate(baseTransform.position);

				yield return null;
			}
		}

		private void Rotate(Vector3 basePosition) =>
			_transform.forward = Vector3.Lerp(_transform.forward, basePosition - _transform.position, Time.deltaTime);
	}
}