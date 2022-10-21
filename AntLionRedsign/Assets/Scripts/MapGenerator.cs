using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int width = 16;
    [SerializeField] private int height;
    
    public float colonySpaceHeightPercentage = 0.25f;
    private int colonySpaceOpeningWalls; 
    private int colonyHeightLoc;   
    

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
    public int probabilityOfSafety = 3;
    

   

    // Start is called before the first frame update
    void Start()
    {
        colonySpaceOpeningWalls = (int)(width*0.75)/2;
        colonyHeightLoc = (int)(height*colonySpaceHeightPercentage);   

        for (int x = 0; x < width; x ++){
            for(int y = 0; y < height; y ++){
                
                if(((x == 0 || x == (width - 1)) || (y == 0)) || ((y == (height - colonyHeightLoc)) && ((x < colonySpaceOpeningWalls) || (x > (width - colonySpaceOpeningWalls))))){
                    barrierGrid.SetTile(new Vector3Int(x,y,0), barrier);
                }

                else if (y > (height - colonyHeightLoc)){
                    contentGrid.SetTile(new Vector3Int(x,y,0), winTile); 
                }

                else{
                    int decider = (int)Random.Range(0, 100);
                    contentGrid.SetTile(new Vector3Int(x,y,0), DecideTile(decider));
                }
  

            }
        }
        
    }

    public Vector2 getDimensions(){
        return new Vector2(width, height);
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
        //probability of negative tiles 
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



        return tileToReturn;

    }


   
}
