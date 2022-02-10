using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerHealthPickup : RollerPickup, IDestructable
{
	[SerializeField] float health;

	public void Destroyed()
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		go.GetComponent<Health>().health += health;
	}
}
