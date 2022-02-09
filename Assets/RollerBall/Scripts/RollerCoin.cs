using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoin : MonoBehaviour, IDestructable
{
    public float amplitude;
    public float rate;
    public float spinRate;

    Vector3 initialPosition;
    float time;
    float angle;

	public void Destroyed()
	{
		RollerGameManager.Instance.Score++;
	}

	void Start()
    {
        time = Random.Range(0f, 5f);
        angle = Random.Range(0f, 360f);
        initialPosition = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime * rate;
        angle += Time.deltaTime * spinRate;

        Vector3 offset = Vector3.up * Mathf.Sin(time) * amplitude;
        transform.position = initialPosition + offset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
