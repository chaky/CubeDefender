using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	private EnemyManager m_EnemyManager;
	private TimeCounter m_TimeCounter;
	public int secondsPreparingToPlay = 3; //TODO in gamedata
	public enum States{
		GameOver, PreparingToPlay, Playing, Paused
	}
	public States state;

	void Start () {
		m_EnemyManager = GetComponent<EnemyManager>();
		m_TimeCounter = GetComponent<TimeCounter>();
		PrepareToPlay();
	}

	void Update(){
		switch (state){
		case States.Playing:
			m_EnemyManager.DispatchEnemies();
			break;
		}
	}

	public void ClearStage(){
		//TODO: remove everything in stage
		m_EnemyManager.RemoveEnemies();
	}

	public void PrepareToPlay(){
		//TODO: Shows countdown before playing
		state = States.Playing;
		CountFinished();
	}

	public void CountFinished(){
		m_TimeCounter.StartTimer();
	}

}
