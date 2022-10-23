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
   public Transform floatingNumberSpawnPoint;

   public GameObject floatingAddedTime;

   private TileBase currTile;
   private bool pastSafeTile;
   public bool onSafeTile;
   
   //audio sources 
   public AudioSource positiveTileSound; 
   public AudioSource negativeTileSound;
   public AudioSource burrowSound;
   public AudioSource powerupSound;
   public AudioSource powerdownSound;
   public AudioSource antdeathSound;

   private void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.CompareTag("Enemy") && !onSafeTile){
         Debug.Log("Hit!");
         //play death sfx
         antdeathSound.Play();
         FindObjectOfType<GameManager>().UpdateState(-2);

      }
     


   
   }

   void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Obstacle") && !onSafeTile && (FindObjectOfType<LandslideController>().occuring == true)){
            Debug.Log("Losing");

            //play death sfx
            antdeathSound.Play();

            FindObjectOfType<GameManager>().UpdateState(-2);   

        }

        if(collision.CompareTag("PickUp")){
            Debug.Log("Hit This");
            if(collision.GetComponent<PickupItem>().isPowerUp){
               // FindObjectOfType<EnemyController>().SetEnemySpeed(0); 
               powerupSound.Play();
               FindObjectOfType<EnemyController>().tempStop = true; 
            }

            else{
               powerdownSound.Play();
               float currentSpeed = FindObjectOfType<EnemyController>().GetEnemySpeed();
               float addSpeed = currentSpeed +1;
               FindObjectOfType<EnemyController>().SetEnemySpeed(addSpeed);
               
            }
            collision.GetComponent<PickupItem>().DestroyItem();
            
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
               //play sfx for burrow 
               burrowSound.Play();
               safteyTimer.setTime(safeTime);
            
            }
            else if(!onSafeTile && (onSafeTile != pastSafeTile) ){
               safteyTimer.setTime(0);
            }


            if(timeAdd != 0){
               string timeAdded;
               float yLocation = (float)(transform.position.y + transform.localScale.y*0.5f);
               Color colour;
               if(timeAdd > 0){
                  timeAdded = "+"+ timeAdd.ToString("0");
                  
                  // positive sfx play 
                  positiveTileSound.Play(); 
                   colour = Color.cyan;

               }
               else{
                   timeAdded = timeAdd.ToString("0");
                   colour = Color.red; 
                    //negative sfx play 
                  negativeTileSound.Play();
                  

               }
               
               GameObject addingTimeFloat = Instantiate(floatingAddedTime, floatingNumberSpawnPoint.transform.position, Quaternion.identity);
               TimeAddText addText = addingTimeFloat.GetComponent<TimeAddText>();
               addText.SetText(timeAdded);
               addText.SetColor(colour);
               
   

            }
            
            

            countDownTimer.addTime(timeAdd);            
            currTile = onTile;
         } 
           
         yield return null;
         
         
      }
   }
     


}
