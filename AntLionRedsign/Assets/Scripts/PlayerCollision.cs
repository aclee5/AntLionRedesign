using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.CompareTag("Enemy")){
         Debug.Log("Hit!");
         FindObjectOfType<GameManager>().UpdateState(-2);




      }
   
   }

  


}
