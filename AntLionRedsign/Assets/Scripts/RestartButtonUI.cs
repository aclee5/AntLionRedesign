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

    public void StartLevel(int number){
        FindObjectOfType<GameManager>().LoadLevel(number);
    }

    public void ResumePlay(){
        FindObjectOfType<GameManager>().Resume();


    }

    public void PausePlay(){
        FindObjectOfType<GameManager>().Pause();


    }

    public void GuideScreenShow(){
        FindObjectOfType<GameManager>().ShowInstruction();

    }

    public void GuideScreenOff(){
        FindObjectOfType<GameManager>().ExitInstruction();
    }

    public void SettingScreenShow(){
        FindObjectOfType<GameManager>().ShowSettings();

    }

    public void SettingScreenOff(){
        FindObjectOfType<GameManager>().ExitSettings();
    }


}
