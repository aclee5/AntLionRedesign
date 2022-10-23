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
    public GameObject killedBeetleUI;
    public GameObject pauseUI;
    public GameObject settingsUI; 
    public GameObject instructionsUI; 
    
    public int state;
    public const int WINKILL = -3;
    public const int WIN = -1;
    public const int LOSE = -2;
    public const int START = 0;
    public const int LEVEL1 = 1;
    public const int LEVEL2 = 2;
    public const int LEVEL3 = 3;

    //gameStates;
    void Start(){
        state = LEVEL1;

    }

    void Update(){
        switch(state){              
            case WIN:
                LevelComplete();
                break;

            case WINKILL:
                BeetleDead();
                break;

            case LOSE:
                EndGame();
                break;
            case LEVEL1:
                break;
            case LEVEL2:
                break;
            case LEVEL3:
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
            FindObjectOfType<EnemyController>().canHit = false;
            FindObjectOfType<EnemyController>().canMove = false;
            Invoke("ShowEndScreen", restartDelay);

        }
        

    }

    public void LevelComplete(){
        FindObjectOfType<EnemyController>().canMove = false;
        FindObjectOfType<LandslideController>().occuring = false;
        // Debug.Log("Level won");        
        completeLevelUI.SetActive(true);
        hudUI.SetActive(false);

    }

    public void BeetleDead(){
        FindObjectOfType<EnemyController>().canMove = false;
        FindObjectOfType<LandslideController>().occuring = false;  
        killedBeetleUI.SetActive(true);
        hudUI.SetActive(false);

    }


    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(){
        SceneManager.LoadScene("Level01");
    }
    public void LoadLevel(int number){
        string levelNumber = number.ToString();
        string sceneName = "Level0" + levelNumber;
        SceneManager.LoadScene(sceneName);

    }

    public void ShowEndScreen(){
        gameOverUI.SetActive(true);
        hudUI.SetActive(false);

    }

    public void ShowInstruction(){
        instructionsUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitInstruction(){
        instructionsUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowSettings(){
        settingsUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitSettings(){
        settingsUI.SetActive(false);
        Time.timeScale = 1;
    }



    public void ReturnHome(){
        SceneManager.LoadScene("StartScreen");
    }

    public void Pause(){
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }
}

