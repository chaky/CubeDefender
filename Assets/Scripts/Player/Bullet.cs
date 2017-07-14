using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float thrust = 10;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().AddForce(transform.forward * thrust, ForceMode.Impulse);
	}
}
