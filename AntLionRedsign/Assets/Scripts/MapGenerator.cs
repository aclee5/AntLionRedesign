using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int width, height;


    public Tilemap contentGrid;
    public Tilemap barrierGrid;

    public Tile barrier;
    public Tile safetyTile;
    public Tile winTile; 
    public Tile tileNoValue;
    public Tile tileNegative1;
    public Tile tileNegative2;
    public Tile tileNegative3;
    public Tile tilePositive1;
    public Tile tilePositive2;
    public Tile tilePositive3;
    public int probabilityOfNegative = 60;
    public int probabilityOfPositive = 15;
    public int probabilityOfSafety = 5;
    



   

    // Start is called before the first frame update
    void Start()
    {

        for (int x = 0; x < width; x ++){
            for(int y = 0; y < height; y ++){
                
                if((x == 0 || x == (width - 1)) || (y == 0 || y == (height - 1))){
                    barrierGrid.SetTile(new Vector3Int(x,y,0), barrier);
                }

                else{
                    int decider = (int)Random.Range(0, 100);
                    contentGrid.SetTile(new Vector3Int(x,y,0), DecideTile(decider));
                }


                

            }
        }
        
    }

    private Tile DecideTile(int number){
        Tile tileToReturn;
        //probability of safetey Zones 
        if (number <= probabilityOfSafety){
            tileToReturn = safetyTile;
        }
        //probablility of positive tiles
        else if (number > probabilityOfSafety && number <= probabilityOfPositive){
            if (number < (int)(probabilityOfPositive*0.6)){
                tileToReturn = tilePositive1;
            }
            else if (number < (int)(probabilityOfPositive*0.9)){
                tileToReturn = tilePositive2;
            }
            else{
                tileToReturn = tilePositive3;
            }
        }
        else if(number > probabilityOfPositive && number <= probabilityOfNegative){
            if (number < (int)(probabilityOfNegative*0.6)){
                tileToReturn = tileNegative2;
            }
            else if (number < (int)(probabilityOfNegative*0.8)){
                tileToReturn = tileNegative3;
            }
            else{
                tileToReturn = tileNegative1;
            }

        
        }
        else{
            tileToReturn = tileNoValue;
        }

        
        
        //probability of negative tiles 



        return tileToReturn;

    }

   
}
