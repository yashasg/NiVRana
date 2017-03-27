using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject[] children;

    enum eGameStates
    {
        MainMenu=0,
        BeginRound=1,
        ShowScore=2,
        ShowFinalScore=3
    };
    private eGameStates currentGameState;


    void Start()
    {
        currentGameState = eGameStates.MainMenu;
    }

   public void MoveToNextState()
    {
        switch (currentGameState)
        {
            case eGameStates.MainMenu:
                currentGameState = eGameStates.BeginRound;
                ToggleChildren(false);
                break;
            case eGameStates.BeginRound:
                currentGameState = eGameStates.ShowScore;
                ToggleChildren(true);
                break;
            case eGameStates.ShowScore:
                currentGameState = eGameStates.BeginRound;
                ToggleChildren(false);
                break;
        }
    }

    public void MoveToFinalScore()
    {
        ToggleChildren(true);
        //show suwas' score here.


    }


    private void ToggleChildren(bool isEnabled)
    {
        foreach(GameObject child in children)
        {
            child.SetActive(isEnabled);
        }
    }


	
	// Update is called once per frame
	void Update () {
	
	}
}
