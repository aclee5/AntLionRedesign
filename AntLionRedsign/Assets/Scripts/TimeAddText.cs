using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAddText : MonoBehaviour
{
    public float timeTillDeath;
    public TMP_Text addedTime;
    // Start is called before the first frame update
    void Start()
    {
        FunctionTimer.Create(KillThis, timeTillDeath);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void KillThis(){
        Destroy(this.gameObject);
    }

    public void SetText(string time){
        addedTime.text = time;

    }

    public void SetColor(Color colour){
        addedTime.color = colour; 
    }
}
