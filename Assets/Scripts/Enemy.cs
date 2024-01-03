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

		public void MoveToBase(Vector3 basePosition) =>
			StartCoroutine(MoveToBaseCoroutine(basePosition));

		private IEnumerator MoveToBaseCoroutine(Vector3 basePosition)
		{
			while (_transform.position != basePosition)
			{
				_transform.position = Vector3.MoveTowards(_transform.position,
					basePosition,
					0.1f);

				Rotate(basePosition);

				yield return null;
			}
		}

		private void Rotate(Vector3 basePosition) =>
			_transform.rotation = Quaternion.LookRotation(basePosition);
	}
}