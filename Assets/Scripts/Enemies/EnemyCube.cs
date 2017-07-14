using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour {

	public float m_Speed = 1f;
	public float m_Life = 100;
	private float m_Damage = 0;
	public TextMesh m_LifeText; 
	private float m_AdvanceAngle;
	private float m_AdvanceTimeStart;
	private Material m_Material;
	public GameData.EnemyTypes m_Type;
	public enum States{
		New, Idle, WaitForObstacle, Advancing, Jumping, Staring
	}
	public States m_State;

	private GameObject m_Pivot;
	private GameObject m_Cube;

	void Start () {
		CheckObjectRig();
		m_Material = m_Cube.GetComponent<Renderer>().material;
		m_Material.color = new Color(Random.value, Random.value, Random.value);
	}

	public void SetType(GameData.EnemyTypes type){
		m_Type = type;
		switch(m_Type){
		case GameData.EnemyTypes.SimpleCube:
			m_Speed = 2;
			m_Life = 100;
			ScaleProperly(2);
			break;
		case GameData.EnemyTypes.JumpyCube:
			m_Speed = 0.5f;
			m_Life = 50;
			transform.localScale = Vector3.one * 0.5f;
			ScaleProperly(1);
			break;
		case GameData.EnemyTypes.ZigZagCube:
			m_Speed = 2;
			m_Life = 100;
			ScaleProperly(3);
			break;
		case GameData.EnemyTypes.BigCube:
			m_Speed = 3;
			m_Life = 200;
			ScaleProperly(6);
			break;
		case GameData.EnemyTypes.TitanCube:
			m_Speed = 4;
			m_Life = 500;
			ScaleProperly(10);
			break;
		}
		m_LifeText.text = m_Life.ToString();
		m_State = States.Idle;
	}

	private void ScaleProperly(float size){
		transform.localScale = Vector3.one * size;
		Vector3 pos = transform.localPosition;
		pos.y = size / 2;
		transform.localPosition = pos;
	}

	void Update () {
		switch(m_State){
		case States.Idle:
			//dispatch rotation
			StartAdvance();
			break;
		case States.Advancing:
			float elapsedAdvance = Time.time - m_AdvanceTimeStart;
			m_AdvanceAngle = Mathf.Lerp(0, 90, elapsedAdvance * (1/m_Speed));
			if(m_AdvanceAngle >= 90){
				m_AdvanceAngle = 90;
				m_Pivot.transform.localEulerAngles = new Vector3(m_AdvanceAngle, 0, 0);
				AdvanceFinished();
			} else {
				m_Pivot.transform.localEulerAngles = new Vector3(m_AdvanceAngle, 0, 0);
			}
			break;
		}
	}

	private void StartAdvance(){
		m_State = States.Advancing;
		m_Cube.transform.SetParent(m_Pivot.transform);
		m_AdvanceTimeStart = Time.time;
	}

	public void AdvanceFinished(){
		m_State = States.Idle;
		m_Pivot.transform.localEulerAngles = new Vector3(90, 0, 0);

		transform.position = m_Cube.transform.position;
		m_Cube.transform.SetParent(transform); 
		m_Cube.transform.localPosition = Vector3.zero;
		m_Cube.transform.localEulerAngles = Vector3.zero;
		m_Pivot.transform.localEulerAngles = Vector3.zero;
	}

	private void CheckObjectRig(){
		m_Pivot = transform.Find("Pivot").gameObject;
		if(!m_Pivot){
			Debug.LogError("Enemy object needs a placeholder named Pivot");
			Debug.Break();
		}
		m_Cube  = transform.Find("CubeModel").gameObject;
		if(!m_Cube){
			Debug.LogError("Enemy object needs a placeholder named CubeModel");
			Debug.Break();
		}
	}

	public void ApplyDamage(float damage){
		m_LifeText.text = (m_Life - m_Damage).ToString();
		m_Damage += damage;
		Color col = m_Material.color;
		col.a = (m_Life - m_Damage) / m_Life;
		m_Material.color = col;
		if(m_Damage > m_Life){
			Kill();
		}
	}

	public void Kill(){
		//TODO: create a particle system for explosion, out of this object
		GameObject.Destroy(gameObject);
	}
}
