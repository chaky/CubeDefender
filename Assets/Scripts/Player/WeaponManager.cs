﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	public GameObject m_ShootTarget;
	public GameObject m_WeaponModel;
	public ParticleSystem m_ShootFlare;
	public PlayerController m_PlayerController;
	public GameObject m_BulletPrefab;
	public GameData.WeaponTypes m_CurrentWeapon;

	void Start () {
		m_ShootTarget = transform.Find("ShootTarget").gameObject;
		if(!m_ShootTarget){
			Debug.LogError("Player needs the gameobject called ShootTarget");
			Debug.Break();
		}
		m_WeaponModel = transform.Find("Weapon").gameObject;
		if(!m_WeaponModel){
			Debug.LogError("Player needs the gameobject called Weapon");
			Debug.Break();
		}
		if(!m_ShootFlare){
			Debug.LogError("Player needs the gameobject called ShootFlare");
			Debug.Break();
		}
		m_PlayerController = GetComponent<PlayerController>();
	}

	void Update () {
		MoveWeapon();
		if(Input.GetMouseButtonDown(0)){
			Shoot();
		}
	}

	private void MoveWeapon(){
		Ray ray = new Ray();
		ray.origin = m_PlayerController.m_CurrentCamera.transform.position;
		ray.direction = m_PlayerController.m_CurrentCamera.transform.forward;
		m_ShootTarget.transform.position = ray.GetPoint(GameData.m_StageRadius);
		m_WeaponModel.transform.LookAt(m_ShootTarget.transform);
	}

	private void Shoot(){
		GameObject bullet = GameObject.Instantiate(m_BulletPrefab, m_ShootFlare.transform.position, m_PlayerController.m_CurrentCamera.transform.rotation);
		bullet.GetComponent<Bullet>().m_Thrust = 100;
		bullet.GetComponent<Bullet>().m_Damage = GameData.m_WeaponDamages[(int)m_CurrentWeapon];
		bullet.GetComponent<Bullet>().Shoot();
		m_ShootFlare.Play();
	}
}
