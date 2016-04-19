using UnityEngine;
using System.Collections;

public class AIRelocate : MonoBehaviour {
	public Transform m_othercube;
	// Use this for initialization
	void OnTriggerEnter(Collider i_other){
		if (i_other.tag.Equals ("AIBird")) {
			i_other.gameObject.GetComponent<AIBirdMotion> ().setNewDestination(m_othercube);
		}

	}
}
