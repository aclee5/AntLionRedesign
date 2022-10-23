using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public bool isPowerUp;
   

    public void SetPosition(Vector3 pos){
        transform.position = pos;
        
    }

    public void DestroyItem(){
       
        Destroy(this.gameObject); 

    }


}
