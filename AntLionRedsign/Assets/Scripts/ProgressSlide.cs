using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlide : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] MapGenerator map; 
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 mapDim = map.getDimensions();
        int colonySize = map.getColonyHeight();
        slider.maxValue = mapDim.y - (colonySize + 1); 
        slider.minValue = player.transform.position.y;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.transform.position.y;
    }
}
