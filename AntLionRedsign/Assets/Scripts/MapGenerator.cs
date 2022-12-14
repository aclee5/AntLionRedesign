using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [Header ("Dimensions")]
    [SerializeField] private int width = 16;
    [SerializeField] private int height;
    
    public float colonySpaceHeightPercentage = 0.25f;
    private int colonySpaceOpeningWalls; 
    private int colonyHeightLoc;
    public bool hasPickup = true;
    
    [Header ("Tilemap Input")]
    public Tilemap contentGrid;
    public Tilemap barrierGrid;

    [Header ("Tiles to Use")]
    public Tile barrierL;
    public Tile barrierR;
    public Tile barrier;
    public Tile safetyTileHorizontal;
    public Tile safetyTileVertical; 
    public Tile winTile; 
    public Tile tileNoValue;
    public Tile tileNegative1;
    public Tile tileNegative2;
    public Tile tileNegative3;
    public Tile tilePositive1;
    public Tile tilePositive2;
    public Tile tilePositive3;

    public GameObject powerUp;
    public GameObject powerDown; 

    [Header("Probabilities of Tile out of 100")]
    public int probabilityOfNegative = 60;
    public int probabilityOfPositive = 15;
    public int probabilityOfSafety = 3;
    public int denominatorofPickup = 10;
    public int denominatorofPowerUp = 3;
    [Header ("Probabilities of Value (maximum 1.0)*** Only for 1 & 2 Values the rest is 3")]
    public float negative1 = 0.6f;
    public float negative2 = 0.8f;
    public float positive1 = 0.6f;
    public float positive2 = 0.9f;


   

    // Start is called before the first frame update
    void Start()
    {
        colonySpaceOpeningWalls = (int)(width*0.75)/2;
        colonyHeightLoc = (int)(height*colonySpaceHeightPercentage);   

        for (int x = 0; x < width; x ++){
            for(int y = 0; y < height; y ++){

               // if (((x == 0 || x == (width - 1)) || (y == 0)) || ((y == (height - colonyHeightLoc)) && ((x < colonySpaceOpeningWalls) || (x > (width - colonySpaceOpeningWalls)))))
               // {
               //     barrierGrid.SetTile(new Vector3Int(x, y, 0), barrier);
               // }

                if (x == 0 || y == 0){
                    barrierGrid.SetTile(new Vector3Int(x,y,0), barrierL);
                }

                else if (x == (width - 1))
                {
                    barrierGrid.SetTile(new Vector3Int(x, y, 0), barrierR);
                }

                else if (((y == (height - colonyHeightLoc)) && ((x < colonySpaceOpeningWalls) || (x > (width - colonySpaceOpeningWalls)))))
                {
                    barrierGrid.SetTile(new Vector3Int(x, y, 0), barrier);
                }

                else if (y > (height - colonyHeightLoc)){
                    contentGrid.SetTile(new Vector3Int(x,y,0), winTile); 
                }

                else{

                    

                        int decider = (int)Random.Range(0, 100);
                        contentGrid.SetTile(new Vector3Int(x, y, 0), DecideTile(decider));

                        if (hasPickup)
                        {
                            int hasPickUpItem = (int)Random.Range(0, denominatorofPickup);
                            if (hasPickUpItem == 1)
                            {
                                if ((int)Random.Range(0, denominatorofPowerUp) < 2)
                                {

                                    Instantiate(powerUp, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity);
                                }
                                else
                                {

                                    Instantiate(powerDown, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity);
                                }
                            }
                        }
                    }

  

            }
        }
        
    }

    public Vector2 getDimensions(){
        return new Vector2(width, height);
    }

    public int getColonyHeight(){
        return colonyHeightLoc;
    }

    private Tile DecideTile(int number){
        Tile tileToReturn;
        //probability of safetey Zones 
        if (number <= probabilityOfSafety){
            float burrowDirection = Random.Range(0, 2);
            if (burrowDirection < 1){
                tileToReturn = safetyTileHorizontal;
            }
            else{
                tileToReturn = safetyTileVertical;
            }
            
        }
        //probablility of positive tiles
        else if (number > probabilityOfSafety && number <= probabilityOfPositive){
            if (number < (int)(probabilityOfPositive*positive1)){
                tileToReturn = tilePositive1;
            }
            else if (number < (int)(probabilityOfPositive*positive2)){
                tileToReturn = tilePositive2;
            }
            else{
                tileToReturn = tilePositive3;
            }
        }
        //probability of negative tiles 
        else if(number > probabilityOfPositive && number <= probabilityOfNegative){
            if (number < (int)(probabilityOfNegative*negative1)){
                tileToReturn = tileNegative1;
            }
            else if (number < (int)(probabilityOfNegative*negative2)){
                tileToReturn = tileNegative2;
            }
            else{
                tileToReturn = tileNegative3;
            }

        
        }
        else{
            tileToReturn = tileNoValue;
        }



        return tileToReturn;

    }


   
}
