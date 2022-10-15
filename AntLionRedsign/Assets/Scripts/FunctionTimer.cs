using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used YouTube Tutorial Code Monkey "Trigger an Action after some Timer (Unity Tutorial)" https://www.youtube.com/watch?v=1hsppNzx7_0
public class FunctionTimer
{
    private static List<FunctionTimer> activeTimerList;
    private static GameObject initGameObject;

    private static void InitIfNeeded(){
        if(initGameObject == null){
            initGameObject = new GameObject("FunctionTimer_InitGameObject");
            activeTimerList = new List<FunctionTimer>();

        }
    }

    public static FunctionTimer Create(Action action, float timer, string timerName = null){
        InitIfNeeded();
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));
        FunctionTimer functionTimer = new FunctionTimer(action, timer, timerName, gameObject);        
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = functionTimer.Update;
        activeTimerList.Add(functionTimer);
        return functionTimer;

    }

    private static void RemoveTimer(FunctionTimer functionTimer){
        InitIfNeeded();
        activeTimerList.Remove(functionTimer);
    }

    private static void StopTimer(string timerName){
        for (int i=0; i<activeTimerList.Count; i++){
            if (activeTimerList[i].timerName == timerName){
                activeTimerList[i].DestroySelf();
                i--;
            }
        }
    }

    public class MonoBehaviourHook : MonoBehaviour {
        public Action onUpdate;
        void Update(){
            if(onUpdate != null){
                onUpdate();
            }

        }

    }
    private Action action;
    private float timer;
    private string timerName;
    private GameObject gameObject;
    private bool isDestroyed;

    private FunctionTimer(Action action, float timer, string timerName, GameObject gameObject){
        this.action = action;
        this.timer = timer;
        this.timerName = timerName;
        this.gameObject = gameObject;
        isDestroyed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isDestroyed){
            timer -= Time.deltaTime;
            if (timer < 0){
                action();
                DestroySelf();
            }

        }
        
        
    }

    private void DestroySelf(){
        isDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
        RemoveTimer(this);
    }
}
