using UnityEngine;
using System.Collections;
using System;

public class AIBirdMotion : MonoBehaviour
{
    Rigidbody m_thisRigidBody;
    public float m_birdVelocity;
    private Transform m_startMarker;
    private Transform m_endMarker;
    private float startTime;
    private float journeyLength;
    public bool isFish;
    private Color m_CurrentColor = Color.white;
    //private float m_Score = 0;
    private float   m_Score1 = 0;
    private int     gaze_counter = 0;
    private int     total_gaze = 0;
    private int     total_counter = 0;
    public bool isMoving = false;

    // Use this for initialization

    void Start()
    {
        m_Score1 = 0;
        gaze_counter = 0;
        total_gaze = 0;
        total_counter = 0;
    }

    public void setNewDestination(Transform i_newSource,Transform i_newDest)
    {
        if (i_newDest != null)
        {
            isMoving = true;
            m_startMarker = i_newSource;
            m_endMarker = i_newDest;
            startTime = Time.time;
            journeyLength = Vector3.Distance(m_startMarker.position, m_endMarker.position);
            if (!isFish)
                //transform.LookAt(m_endMarker.position, Vector3.up);
            m_thisRigidBody = GetComponent<Rigidbody>();
           // if (GetComponent<Renderer>().material.color.Equals(m_CurrentColor))
                //m_Score += 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_startMarker != null && m_endMarker)
        {
            float distCovered = (Time.time - startTime) * m_birdVelocity;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(m_startMarker.position, m_endMarker.position, fracJourney);
            if (transform.position == m_endMarker.position)
            {
                isMoving = false;
            }
        }
        total_counter++;
        gaze_counter++;
    }

    public int getScore()
    {
        return (int)m_Score1;
    }
    public void SetGazedAt(bool gazedAt)
    {
        System.Random rand = new System.Random();
        m_CurrentColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
        GetComponent<Renderer>().material.color = gazedAt ? m_CurrentColor : Color.yellow;
        CalculateScore(gazedAt);
    }

    private void CalculateScore(bool gazedAt)
    {
        if (gazedAt == false)
        {
            total_gaze += gaze_counter;
            m_Score1 = (total_gaze / (float)total_counter) * 100;
            Debug.Log("Score " + getScore());
        }
        else
        {
            gaze_counter = 0;
        }
    }
}