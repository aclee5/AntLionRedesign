using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed; 
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed*Time.deltaTime);
        if(Input.anyKeyDown){
            if(canMove){
                if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f){
                    if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                        if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatStopsMovement)){
                            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        }
                
                    }
            
                    else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f){
                        if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Horizontal"), 0f), 0.2f, whatStopsMovement)){
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);                
                        }
                
                    }
                }
                canMove = false;

            }

        }
        else{
            canMove = true;
        }

        
    }
}
