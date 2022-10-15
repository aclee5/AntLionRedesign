using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    public Rigidbody2D playerRigidbody2D;
    private Vector3 moveDir;
    // Start is called before the first frame update
    
    // Update is called once per frame
    //private Player playerBase;

    private void Awake() {
        //playerBase = GameObject.GetComponent<Player>();
       playerRigidbody2D = GetComponent<Rigidbody2D> ();
    }
    void Update(){
            if (!isMoving){
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");
            }
        moveDir = new Vector3(input.x, input.y).normalized;
       
        //HandleMovement();
    }

    // private void HandleMovement(){
    //      float moveX = 0f;
    //     float moveY = 0f;
    //    if (Input.GetKey(KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
    //         Debug.Log("UP");
    //         moveY = +1f;

    //     } else if (Input.GetKey(KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
    //         moveY = -1f;
    //     } else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
    //        moveX = -1f;
    //     } else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
    //         moveX = +1f;
    //     }
       
    //     moveDir = new Vector3(moveX, moveY).normalized;
    // }
     private void FixedUpdate(){
        
         playerRigidbody2D.MovePosition(transform.position + moveDir*moveSpeed *Time.deltaTime);
     }
    // void Update()
    // {
        
    //     if (!isMoving){
    //         input.x = Input.GetAxisRaw("Horizontal");
    //         input.y = Input.GetAxisRaw("Vertical");

    //         if (input != Vector2.zero){
    //             var targetPos = transform.position;
    //             targetPos.x += input.x;
    //             targetPos.y += input.y;

    //             StartCoroutine(Move(targetPos));
    //         }

    //     }

    // }
    // if (Input.GetKeyDown (KeyCode.UpArrow)) {
	// 			MoveVertical(1);
	// 		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
	// 			MoveVertical(-1);
	// 		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
	// 			MoveHorizontal (-1);
	// 		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
	// 			MoveHorizontal (1);
	// 		}

    IEnumerator Move(Vector3 targetPos){
        isMoving = true;
        
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

   
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Collided!");
    }

    private void OnCollisionExit2D(Collision2D collision){
        Debug.Log("ended");
    }
   private void OnCollisionStay2D(Collision2D collision){
    Debug.Log("stay");
   }
}
