using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ForceEffector : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] [Range(0, 100)] float magnitude;
	[SerializeField] bool constant = true;
	[SerializeField] ForceMode forceMode;

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{
			rb.AddForce(direction * magnitude, forceMode);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!constant) return;

		if (other.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{
			rb.AddForce(direction * magnitude, forceMode);
		}
	}
}
