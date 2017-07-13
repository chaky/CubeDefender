using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	private EnemyManager m_EnemyManager;
	public int secondsPreparingToPlay = 3; //TODO in gamedata


	void Start () {
		m_EnemyManager = GetComponent<EnemyManager>();
	}
	
	public void ClearStage(){
		//TODO: remove everything in stage
		m_EnemyManager.RemoveEnemies();
	}

	public void PrepareToPlay(){
		//TODO: Shows countdown before playing
	}
}
