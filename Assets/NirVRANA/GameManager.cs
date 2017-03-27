using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject[] children;

    public GameObject displayfish;
    public GameObject displayBird;

    enum eGameStates
    {
        MainMenu=0,
        BeginRound=1,
        ShowScore=2,
        ShowFinalScore=3
    };
    enum eRound
    {
        Fish=0,
        Bird=1,
        Sun=2
    }
    private eGameStates currentGameState;
    private eRound currentRound;


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
                currentRound = eRound.Fish;
                ToggleChildren(false);
                break;
            case eGameStates.BeginRound:
                currentGameState = eGameStates.ShowScore;
                if (currentRound == eRound.Fish)
                {
                    currentRound = eRound.Bird;
                }
                else if (currentRound == eRound.Bird)
                {
                    currentRound = eRound.Sun;
                }
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
        foreach (GameObject child in children)
        {
            child.SetActive(isEnabled);
        }
        if(currentRound==eRound.Bird)
        {
            displayBird.SetActive(isEnabled);
        }
        else if (currentRound == eRound.Fish)
        {
            displayfish.SetActive(isEnabled);
        }
    }


	
	// Update is called once per frame
	void Update () {
	
	}
}
