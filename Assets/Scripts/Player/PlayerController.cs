using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	[SerializeField] private MouseLook m_MouseLook;
	private Camera m_CurrentCamera;
	private Camera m_FPCamera;
	private Camera m_3PCamera;
	public bool m_use3PCamera;

	void Start () {
		InitCamera();
		m_MouseLook.Init(transform , m_CurrentCamera.transform);
	}

	private void InitCamera(){
		m_FPCamera = transform.Find("FPCamera").GetComponent<Camera>();
		if(!m_FPCamera){
			Debug.LogError("Player object a camera called FPCamera");
			Debug.Break();
		}
		m_3PCamera = transform.Find("3PCamera").GetComponent<Camera>();
		if(!m_3PCamera){
			Debug.LogError("Player object need a camera called 3PCamera");
			Debug.Break();
		}
		if(m_use3PCamera){
			m_CurrentCamera = m_3PCamera;
			m_FPCamera.GetComponent<Camera>().enabled = false;
		} else {
			m_CurrentCamera = m_FPCamera;
			m_3PCamera.GetComponent<Camera>().enabled = false;
		}
	}

	void Update () {
		RotateView();
	}

	void FixedUpdate(){
		m_MouseLook.UpdateCursorLock();
	}

	private void RotateView()
	{
		m_MouseLook.LookRotation (transform, m_CurrentCamera.transform);
	}
}
