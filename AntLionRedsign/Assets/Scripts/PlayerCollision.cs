using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class PlayerCollision : MonoBehaviour
{
   [SerializeField] public MapManager mapManager;
   [SerializeField] private CountDownTimer countDownTimer;
   [SerializeField] private float coolDown;

   private TileBase currTile;
   
   

   private void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.CompareTag("Enemy")){
         Debug.Log("Hit!");
         FindObjectOfType<GameManager>().UpdateState(-2);

      }

      


   
   }
   void Start(){
      Vector3Int mapTile = mapManager.map.WorldToCell(transform.position);
      currTile = mapManager.map.GetTile(mapTile);

   }

   void Update(){
      StartCoroutine(TileTimerEffect());
      

   }

   IEnumerator TileTimerEffect(){
      while(true){
         Vector3Int mapTile = mapManager.map.WorldToCell(transform.position);
         TileBase onTile = mapManager.map.GetTile(mapTile);
         if(onTile != currTile){
            float timeAdd = mapManager.dataFromTiles[onTile].timeAdd;
            countDownTimer.addTime(timeAdd);
            Debug.Log(timeAdd);
            currTile = onTile;

         }        
         yield return null;
         
         
      }
   }
     


}
