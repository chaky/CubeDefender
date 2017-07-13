using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	private List<EnemyCube> aliveEnemies;

	public void RemoveEnemies(){
		foreach(EnemyCube enemy in aliveEnemies){
			enemy.Kill();
		}
	}


}
