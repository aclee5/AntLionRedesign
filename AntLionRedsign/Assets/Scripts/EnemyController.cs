using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;

    //random walk/wander: https://forum.unity.com/threads/making-npcs-wander-in-2d.524950/

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(-2, 2);
    private float decisionTimeCount = 0;
 
    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    private Vector2[] moveDirections = new Vector2[] { Vector2.right, Vector2.left, Vector2.up, Vector2.down};
    private int currentMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroRange){
            //code to chase player
            PlayerChase();
        }

        else{
            //stop chasing player
            StopPlayerChase();
        }
    }

    private void PlayerChase(){
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

    }

    private void StopPlayerChase(){
       transform.position = Vector2.MoveTowards(transform.position, moveDirections[currentMoveDirection], moveSpeed*Time.deltaTime);

        if(decisionTimeCount > 0) {
            decisionTimeCount -= Time.deltaTime;
        }
        else{
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
            ChooseMoveDirection();
        }

    }

    private void ChooseMoveDirection(){
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }
}
