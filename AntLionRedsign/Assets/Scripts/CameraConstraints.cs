using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConstraints : MonoBehaviour
{
    public MapGenerator map; 
    private Vector2 mapDimensions;
    public Transform player; 
    // Start is called before the first frame update
    void Start()
    {
        float mapWidth = map.getDimensions().x;
        float orthoSize = mapWidth * Screen.height/Screen.width * 0.5f;

        Camera.main.orthographicSize = orthoSize;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        
    }
}
