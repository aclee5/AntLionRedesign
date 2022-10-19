using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] PlayerCollision playerCol;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] int health;
    [SerializeField] Slider healthBar;
    [SerializeField]public Transform movePoint;
    [SerializeField]public LayerMask whatStopsMovement;
    public GameManager gameManager;
    public bool canHit;
    public bool canMove;

    //random walk/wander: https://forum.unity.com/threads/making-npcs-wander-in-2d.524950/

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(0, 10);
    private float decisionTimeCount = 0;
 
    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    private Vector2[] moveDirections = new Vector2[] { Vector2.right, Vector2.left, Vector2.up, Vector2.down};
    private int currentMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        ChooseMoveDirection();
        healthBar.maxValue = health;
        canHit = true;
        canMove = true;
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canMove){
            if(playerCol.onSafeTile){
                StopPlayerChase();
                
            }

            else{
                PlayerChase();
                
            }

            if (health <= 0){
                SetEnemySpeed(0);
                canMove = false;
                gameManager.UpdateState(-1);   
                
            }


        }
        
     
    }
    
   
    private void PlayerChase(){
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed*Time.deltaTime);

        Vector3 targetPos = player.transform.position;

        Vector3 pos = new Vector3(0,0,0);
        if(Mathf.Abs(transform.position.x - player.transform.position.x) <= 0.05){
            if (transform.position.y <= player.transform.position.y){
                pos += Vector3.up;
            }
            else if (transform.position.y > player.transform.position.y){
                pos += Vector3.down;
            }

            if(!Physics2D.OverlapCircle(movePoint.position + pos, 0.2f, whatStopsMovement)){
                movePoint.position = Vector3.MoveTowards(transform.position, transform.position + pos, moveSpeed * Time.deltaTime);
            }
            
        }            
            



        else{
            
            if (transform.position.x <= player.transform.position.x){
                pos += Vector3.right;
            }
            else if (transform.position.x > player.transform.position.x){
                pos += Vector3.left;
            }

            if(!Physics2D.OverlapCircle(movePoint.position + pos, 0.2f, whatStopsMovement)){
                movePoint.position = Vector3.MoveTowards(transform.position, transform.position + pos, moveSpeed * Time.deltaTime);
            }
            

        }
        
    

     
        if (pos != Vector3.zero){
            float angle = Mathf.Atan2(pos.y, pos.x)*Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    private void StopPlayerChase(){
        Vector2 newPos = moveDirections[currentMoveDirection]* Random.Range(0, 5);
        transform.position = Vector2.MoveTowards(transform.position, newPos, moveSpeed*Time.deltaTime);

        if(decisionTimeCount > 0) {
            decisionTimeCount -= Time.deltaTime;
        }
        else{
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
            ChooseMoveDirection();
        }

    }

    public void SetEnemySpeed(float speed){
        moveSpeed = speed;
    }



    private void ChooseMoveDirection(){
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));

    }


    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Obstacle")){
            if(canHit){
                health -= 1;
                healthBar.value = health;
                canHit = false;
            }
            Debug.Log("Enemy Health" + healthBar.value);
            
                    

        }
   }

   void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Obstacle") && (FindObjectOfType<LandslideController>().occuring == true)){
            if(!canHit){
                canHit = true;
            
            }
                
        }

    }
}
