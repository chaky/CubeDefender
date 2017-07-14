using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float m_Thrust = 100;
	public float m_Damage = 10;
	private float m_LifeTime = 3;

	void Start () {
	}

	void Update() {
		m_LifeTime -= Time.deltaTime;
		if(m_LifeTime < 0){
			GameObject.Destroy(gameObject);
		}
	}

	public void Shoot(){
		GetComponent<Rigidbody>().AddForce(transform.forward * m_Thrust, ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision collision){
		//Debug.Log( "hit " + collision.gameObject.name);
		CubeModelLogic cubeLogic = collision.gameObject.GetComponent<CubeModelLogic>();
		if(cubeLogic){
			cubeLogic.m_EnemyCube.ApplyDamage(m_Damage);
			GameObject.Destroy(gameObject);
		} else {
			Debug.Log("MISSED: " + collision.gameObject.name);
		}

	}
}
