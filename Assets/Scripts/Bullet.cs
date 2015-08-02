using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public int speed = 10;
	
	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
