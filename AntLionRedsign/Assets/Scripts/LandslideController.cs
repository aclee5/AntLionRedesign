using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandslideController : MonoBehaviour
{
    public GameObject landslide;
    [SerializeField] private float landslideLength;
    [SerializeField] private float timeTillLandslide;
    [SerializeField] private float spawnLocationX;
    [SerializeField] private float spawnLocationY;
    [SerializeField] private CountDownTimer countDownTimer;
    public bool occuring = true;
    
    private Vector2 screenBoundary;  


    // Start is called before the first frame update
    void Start()
    {
        countDownTimer.setTime(landslideLength);
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

      
        StartCoroutine(TriggerLandslide());

    }

    void Update(){
        if(!occuring){
            Debug.Log("LandslideStopped");
            StopCoroutine(TriggerLandslide());
        }
    }
    private void spawnLandslide(){
        GameObject a = Instantiate(landslide) as GameObject;
        a.transform.position = new Vector2(spawnLocationX, spawnLocationY);
        Debug.Log("Landslide");
        //Find landslide countdown timer to reset
        
        

    }

   IEnumerator TriggerLandslide(){    
        while(occuring){
            countDownTimer.setTime(timeTillLandslide);
            yield return new WaitForSeconds(timeTillLandslide);
            spawnLandslide();
            yield return new WaitForSeconds(landslideLength);

        }

   }



}
