using UnityEngine;

public class WinTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Debug.Log("winning");
            gameManager.UpdateState(-1);   

        }

    }

    
}
