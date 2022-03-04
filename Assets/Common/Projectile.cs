using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] ForceMode forceMode;

    public void Start()
	{
        rb.AddRelativeForce(Vector3.forward * speed, forceMode);
	}
}
