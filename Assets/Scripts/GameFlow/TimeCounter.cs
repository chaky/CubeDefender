using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

	private bool m_TimeRunning = false;
	public Text m_Text;
	private float m_TimeStarted;
	private float m_ElapsedTimeExact;
    public float m_ElapsedTime;
	private float m_LastElapsedTime;
	private float m_TimePaused;

	void Start () {
	}

	void Update () {
		if(m_TimeRunning){
			m_ElapsedTimeExact = Time.time - m_TimeStarted;
            int elapsedTimeCents = Mathf.FloorToInt(m_ElapsedTimeExact * 10);
			m_ElapsedTime =  (float)elapsedTimeCents / 10;

            if (m_ElapsedTime > m_LastElapsedTime){
				//set text only when value changes with two decimals
                m_LastElapsedTime = m_ElapsedTime;
				m_Text.text = string.Format("{0:0}:{1:00}.{2:0}", Mathf.Floor(m_LastElapsedTime/60), Mathf.Floor(m_LastElapsedTime % 60), elapsedTimeCents % 10);
            }
		}
	}

	public void StartTimer(){
		m_TimeRunning = true;
		m_TimeStarted = Time.time;
        m_LastElapsedTime = 0;
	}

	public void ResetTimer(){
		m_TimeStarted = Time.time;
        m_LastElapsedTime = 0;
		m_TimeRunning = false;
		if (m_Text){
			m_Text.text = string.Format ("{0:0}:{1:00}.{2:00}", 0, 0, 0);
		}
	}

	public void StopTimer(){
		m_TimeRunning = false;
        m_TimePaused = Time.time;
	}

    public void ContinueTimer(){
        float timePausedElapsed = Time.time - m_TimePaused;
        m_TimeStarted += timePausedElapsed;
        m_TimeRunning = true;
    }
}
