using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public bool isPowerUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetPosition(Vector3 pos){
        transform.position = pos;

    }


}
