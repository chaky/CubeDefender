using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;

public static class GameData{

	public enum EnemyTypes{
		SimpleCube, JumpyCube, ZigZagCube, BigCube, TitanCube
	}
	public enum WeaponTypes{
		MachineGun, Sniper, ShotGun
	}
	private static string gameSavedDataFile = "gameSavedData";
	private static string gameConfigFile = "gameConfig";
}

[System.Serializable]
public class GameConfig{
	public int matchTime;
	public int defaultDifficulty;
	public bool useThirdPersonCamera;
	public int secondsPreparingToPlay;
}

[System.Serializable]
public class GameSavedData{
	public int[] hiscores;
	public string[] names;
}