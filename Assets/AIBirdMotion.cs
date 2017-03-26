using UnityEngine;
using System.Collections;
using System;

public class AIBirdMotion : MonoBehaviour, ICardboardGazeResponder
{
	Rigidbody m_thisRigidBody;
	public float m_birdVelocity;
	public Transform m_startMarker;
	public Transform m_endMarker;
	private float startTime;
	private float journeyLength;
    public bool isFish;
    private Color m_CurrentColor=Color.white;
    private float m_Score = 0;
	// Use this for initialization
	void Start () {
		setNewDestination (m_endMarker);

	}
	public void setNewDestination (Transform i_newDest){
		if (i_newDest != null) {
			m_endMarker = i_newDest;
			startTime = Time.time;
			journeyLength = Vector3.Distance(transform.position, m_endMarker.position);
            if (!isFish)
            transform.LookAt (m_endMarker.position,Vector3.up);
			m_thisRigidBody = GetComponent<Rigidbody> ();
            if (GetComponent<Renderer>().material.color.Equals(m_CurrentColor))
                m_Score += 0.5f;


        }
	}
	
	// Update is called once per frame
	void Update () {

        float distCovered = (Time.time - startTime) * m_birdVelocity;
		float fracJourney = distCovered / journeyLength;
            m_thisRigidBody.position = Vector3.Lerp(transform.position, m_endMarker.position, fracJourney);

	}
    void LateUpdate()
    {
        Cardboard.SDK.UpdateState();
        if (Cardboard.SDK.BackButtonPressed)
        {
            Application.Quit();
        }
    }
    public float getScore()
    {
        return m_Score;
    }
    public void SetGazedAt(bool gazedAt)
    {
        System.Random rand = new System.Random();
        m_CurrentColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
        GetComponent<Renderer>().material.color = gazedAt ? m_CurrentColor : Color.yellow;
    }

 public void ToggleDistortionCorrection()
    {
        switch (Cardboard.SDK.DistortionCorrection)
        {
            case Cardboard.DistortionCorrectionMethod.Unity:
                Cardboard.SDK.DistortionCorrection = Cardboard.DistortionCorrectionMethod.Native;
                break;
            case Cardboard.DistortionCorrectionMethod.Native:
                Cardboard.SDK.DistortionCorrection = Cardboard.DistortionCorrectionMethod.None;
                break;
            case Cardboard.DistortionCorrectionMethod.None:
            default:
                Cardboard.SDK.DistortionCorrection = Cardboard.DistortionCorrectionMethod.Unity;
                break;
        }
    }

    #region ICardboardGazeResponder implementation

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see CardboardGaze).
    public void OnGazeEnter()
    {
        SetGazedAt(true);
    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit()
    {
        SetGazedAt(false);
    }

    // Called when the Cardboard trigger is used, between OnGazeEnter
    /// and OnGazeExit.
    public void OnGazeTrigger()
    {
    }

    #endregion
}
