using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//reference: https://youtu.be/u_n3NEi223E
public class CountDownTimer : MonoBehaviour
{
    [Header("Component")] 
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header ("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HundredthDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit))){
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText();
        
    }
    private void SetTimerText(){
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();

    }

    public void setTime(float time){
        timerText.color = Color.black;
        enabled = true;
        currentTime = time;
        
    }


    public enum TimerFormats{
        Whole,
        TenthDecimal,
        HundredthDecimal
    }
}
