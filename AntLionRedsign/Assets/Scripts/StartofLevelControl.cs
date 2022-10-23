using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class StartofLevelControl : MonoBehaviour
{
    public GameObject pauseScreenUI;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
            pauseScreenUI.SetActive(false); 
            Time.timeScale = 1; 

        }

    }
}
