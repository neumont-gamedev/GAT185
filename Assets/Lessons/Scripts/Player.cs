using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 10)][Tooltip("speed of the player")] public float speed = 5;
    [SerializeField] AudioSource audioSource;


	void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        transform.position += direction * speed * Time.deltaTime;
        //transform.rotation *= Quaternion.Euler(5, 0, 0);
        //transform.localScale = new Vector3(2, 2, 2);

        if (Input.GetButtonDown("Fire1"))
		{
            audioSource.Play();
            GetComponent<Renderer>().material.color = Color.green;
            //transform.rotation *= Quaternion.Euler(5, 0, 0);
        }

/*        GameObject go = GameObject.Find("Cube");
        if (go)
		{
            go.GetComponent<Renderer>().material.color = Color.cyan;
		}*/
    }
}
