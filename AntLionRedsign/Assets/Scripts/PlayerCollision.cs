using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class PlayerCollision : MonoBehaviour
{
   [SerializeField] public MapManager mapManager;
   [SerializeField] private CountDownTimer countDownTimer;
   [SerializeField] private CountDownTimer safteyTimer;
   [SerializeField] private float coolDown;
   [SerializeField] private float safeTime;

   public GameObject floatingAddedTime;

   private TileBase currTile;
   private bool pastSafeTile;
   public bool onSafeTile;
   
   

   private void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.CompareTag("Enemy")){
         Debug.Log("Hit!");
         FindObjectOfType<GameManager>().UpdateState(-2);

      }
     


   
   }

   void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Obstacle") && !onSafeTile && (FindObjectOfType<LandslideController>().occuring == true)){
            Debug.Log("Losing");
            FindObjectOfType<GameManager>().UpdateState(-2);   

        }
   }

   void Start(){
      Vector3Int mapTile = mapManager.map.WorldToCell(transform.position);
      currTile = mapManager.map.GetTile(mapTile);
      if(mapManager.dataFromTiles[currTile].safe){
         onSafeTile = true;
      }
      else{
         onSafeTile = false; 
      }
      

   }

   void Update(){
      if ((onSafeTile)&&(onSafeTile == pastSafeTile) && (safteyTimer.currentTime == 0)){
         
         FindObjectOfType<GameManager>().UpdateState(-2);

      }
      StartCoroutine(TileTimerEffect());
      

   }

   IEnumerator TileTimerEffect(){
      while(true){
         Vector3Int mapTile = mapManager.map.WorldToCell(transform.position);
         TileBase onTile = mapManager.map.GetTile(mapTile);
         pastSafeTile = onSafeTile;
         if(onTile != currTile){
            float timeAdd = mapManager.dataFromTiles[onTile].timeAdd;
            onSafeTile = mapManager.dataFromTiles[onTile].safe;
            if(mapManager.dataFromTiles[onTile].win){
               Debug.Log("winning");
               FindObjectOfType<GameManager>().UpdateState(-1);
            }
            if(onSafeTile && (onSafeTile != pastSafeTile)){
               safteyTimer.setTime(safeTime);
            
            }
            else if(!onSafeTile && (onSafeTile != pastSafeTile) ){
               safteyTimer.setTime(0);
            }

            
            if(timeAdd != 0){
               string timeAdded;
               float yLocation = (float)(transform.position.y + transform.localScale.y*0.5f);
               if(timeAdd > 0){
                  timeAdded = "+"+ timeAdd.ToString("0") + " s";

               }
               else{
                   timeAdded = timeAdd.ToString("0") + " s";

               }
               
               Instantiate(floatingAddedTime, new Vector3(transform.position.x, yLocation, transform.position.z), Quaternion.identity);
               TimeAddText addText = floatingAddedTime.GetComponent<TimeAddText>();

               addText.SetText(timeAdded);
               
   

            }
            
            

            countDownTimer.addTime(timeAdd);            
            currTile = onTile;
         } 
           
         yield return null;
         
         
      }
   }
     


}
