using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool hasEnded = false;
    public float restartDelay = 0;
    public GameObject completeLevelUI;
    public GameObject hudUI;
    public GameObject gameOverUI;
    
    public int state;
    public const int WIN = -1;
    public const int LOSE = -2;
    public const int START = 0;
    public const int LEVEL1 = 1;

    //gameStates;
    void Start(){
        state = LEVEL1;

    }

    void Update(){
        switch(state){              
            case WIN:
                LevelComplete();
                break;
            case LOSE:
                EndGame();
                break;
            case LEVEL1:
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
            Invoke("ShowEndScreen", restartDelay);

        }
        

    }

    public void LevelComplete(){
        Debug.Log("Level won");
        completeLevelUI.SetActive(true);
        hudUI.SetActive(false);

    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(){
        SceneManager.LoadScene("Level01");
    }

    public void ShowEndScreen(){
        gameOverUI.SetActive(true);
        hudUI.SetActive(false);

    }
}

