using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField]public float moveSpeed; 
    [SerializeField]public Transform movePoint;

    [SerializeField]public LayerMask whatStopsMovement;
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
                        if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatStopsMovement)){
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);                
                        }
                
                    }
                }
                Vector3 moveDirection = transform.position - movePoint.position;
                if (moveDirection != Vector3.zero){
                    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x)*Mathf.Rad2Deg + 90;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
                canMove = false;

            }

        }
        else{
            canMove = true;
        }

        
    }
}
