using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject m_EnemyPrefab;
	public float m_EnemyInterval = 2f;
	private float intervalTimer;

	private List<EnemyCube> m_AliveEnemies;

	public void RemoveEnemies(){
		foreach(EnemyCube enemy in m_AliveEnemies){
			enemy.Kill();
		}
	}

	void Start () {
		m_AliveEnemies = new List<EnemyCube>();
	}

	public void DispatchEnemies() {
		if((Time.time - m_EnemyInterval ) > intervalTimer){
			AddEnemy();
			intervalTimer = Time.time;
		}
	}

	private void AddEnemy(){
		GameObject newEnemy = GameObject.Instantiate(m_EnemyPrefab);
		Ray ray = new Ray();
		ray.origin = Vector3.zero;
		ray.direction = new Vector3(Random.value - 0.5f, 0, Random.value - 0.5f);
		Vector3 enemySpawnPosition = ray.GetPoint(GameData.m_StageRadius);
		newEnemy.transform.position = enemySpawnPosition + Vector3.up * 0.5f;
		newEnemy.transform.LookAt(Vector3.zero + Vector3.up * 0.5f);
		newEnemy.GetComponent<EnemyCube>().SetType(GetNextEnemyType());
		m_AliveEnemies.Add(newEnemy.GetComponent<EnemyCube>());
	}

	private GameData.EnemyTypes GetNextEnemyType(){
		//TODO: enough killed enemies dispatch a Titan
		//return GameData.EnemyTypes.Titan;
		//probabilities
		float value = Random.value;
		if (value >= 0 && value < 0.4)return GameData.EnemyTypes.SimpleCube;
		if (value >= 0.4 && value < 0.7)return GameData.EnemyTypes.JumpyCube;
		if (value >= 0.7 && value < 0.9)return GameData.EnemyTypes.ZigZagCube;
		return GameData.EnemyTypes.BigCube;
	}
}