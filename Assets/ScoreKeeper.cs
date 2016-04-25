using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public GameObject m_Fish;
    public GameObject m_Bird;
    public float m_timeLeft;
    public float m_ScoreTime=3.0f;
    private Text m_textField;
    // Use this for initialization
    void Start () {
        m_textField = GetComponent<Text>();
        m_Bird.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        m_timeLeft -= Time.deltaTime;
        m_textField.text = "Time Left: " + m_timeLeft;
        if (m_timeLeft < 0.0f) {
            if (m_Bird.activeSelf)
            {
                m_ScoreTime -= Time.deltaTime;
                m_textField.text = "X Score: " + m_Bird.GetComponent<AIBirdMotion>().getScore();
                if (m_ScoreTime <= 0.0f)
                {
                    m_ScoreTime = 3.0f;
                    m_Bird.SetActive(false);
                    m_Fish.SetActive(true);
                    m_timeLeft = 10.0f;
                }
            }
            else
            {
                m_ScoreTime -= Time.deltaTime;
                m_textField.text = "Y Score: " + m_Fish.GetComponent<AIBirdMotion>().getScore();
                if (m_ScoreTime <= 0.0f)
                {
                    m_ScoreTime = 3.0f;
                    m_Fish.SetActive(false);
                    m_Bird.SetActive(true);
                    m_timeLeft = 10.0f;
                }
            }
                              }

    }
}
