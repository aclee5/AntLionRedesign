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
   public bool onSafeTile;
   
   

   private void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.CompareTag("Enemy")){
         Debug.Log("Hit!");
         FindObjectOfType<GameManager>().UpdateState(-2);

      }
     


   
   }

   void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Obstacle") && !onSafeTile){
            Debug.Log("Losing");
            FindObjectOfType<GameManager>().UpdateState(-2);   

        }
   }

   void Start(){
      Vector3Int mapTile = mapManager.map.WorldToCell(transform.position);
      currTile = mapManager.map.GetTile(mapTile);
      onSafeTile = false; 

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
            onSafeTile = mapManager.dataFromTiles[onTile].safe;
            countDownTimer.addTime(timeAdd);
            currTile = onTile;
         }        
         yield return null;
         
         
      }
   }
     


}
