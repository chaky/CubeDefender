using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	public GameObject m_ShootTarget;
	public PlayerController m_PlayerController;

	void Start () {
		m_ShootTarget = transform.Find("ShootTarget").gameObject;
		if(!m_ShootTarget){
			Debug.LogError("Player needs the gameobject called ShootTarget");
			Debug.Break();
		}
		m_PlayerController = GetComponent<PlayerController>();
	}

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Shoot();
		}
	}

	private void Shoot(){
		Debug.Log("bang");

	}
}
