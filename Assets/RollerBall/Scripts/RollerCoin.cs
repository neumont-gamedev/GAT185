using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoin : RollerPickup, IDestructable
{
    [SerializeField] int points;

    public void Destroyed()
    {
        RollerGameManager.Instance.Score += points;
    }
}
