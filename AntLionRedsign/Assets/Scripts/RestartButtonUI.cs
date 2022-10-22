using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonUI : MonoBehaviour
{
    public void LoadGame(){
        FindObjectOfType<GameManager>().Restart();
    }

    public void BeginGame(){
        FindObjectOfType<GameManager>().StartGame();
    }

    public void BackHome(){
        FindObjectOfType<GameManager>().ReturnHome();

    }

    public void ResumePlay(){
        FindObjectOfType<GameManager>().Resume();


    }

    public void PausePlay(){
        FindObjectOfType<GameManager>().Pause();


    }
}
