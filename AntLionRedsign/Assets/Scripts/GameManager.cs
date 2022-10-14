using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool hasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    
    public int state;
    public const int WIN = -1;
    public const int LOSE = -2;
    public const int LEVEL0 = 0;

    //gameStates;
    void Start(){
        state = LEVEL0;

    }

    void Update(){
        switch(state){              
            case WIN:
                LevelComplete();
                break;
            case LOSE:
                EndGame();
                break;
            case LEVEL0:
                break;


        }
    }



    public void UpdateState(int newState){
        state = newState;
    }
    
    public void EndGame(){
        if(hasEnded == false){
            Debug.Log("Game Over");
            hasEnded = true;
            Invoke("Restart", restartDelay);

        }
        

    }

    public void LevelComplete(){
        Debug.Log("Level won");
        completeLevelUI.SetActive(true);

    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

