using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generation : MonoBehaviour
{
    public static GameObject[] Road;
    [SerializeField] GameObject normal_tile, Cutted_tile,ending_floor;
    [SerializeField] int RoadLength;
    [SerializeField] Vector3 GenerationPoint = new Vector3(0, 0, 0);
   
    private void Start()
    {
        Road = new GameObject[RoadLength];
        for (int i = 0; i < RoadLength; i++)
        {
            Road[i] = Instantiate(normal_tile,GenerationPoint,normal_tile.transform.rotation);
            GenerationPoint += new Vector3(0, 0, 50);
            Road[i].GetComponent<platformGeneration>().Platform_ID = i;
        }

        for (int i = 0; i < RoadLength/3; i++)
        {
            change_Random_Tile();
        }
        Road[RoadLength] = Instantiate(ending_floor, GenerationPoint, ending_floor.transform.rotation);
    }

    
    public void change_Random_Tile()
    {
        
        int random = Random.Range(3, RoadLength);
        Transform tileTrans= Road[random].transform;
        Destroy(Road[random]);
        Road[random] = Instantiate(Cutted_tile, tileTrans.position, tileTrans.rotation);
        if (Random.Range(0, 1.0f) > 0.5f) Road[random].transform.localScale = Vector3.Scale(Road[random].transform.localScale , new Vector3(-1,1,1));
        //Debug.Log($"the tile number {random} had been deactivated");
    }

    /*  public void genarateRoad()
      {
          GenerationPoint = new Vector3(0, 0, 0);
          foreach (GameObject g in Road)Destroy(g);
          for (int i = 0; i < RoadLength; i++)
          {
              Road[i] = Instantiate(normal_tile, GenerationPoint, normal_tile.transform.rotation);
              int r = Random.Range(0, 5);
              if (r == 0)
              {
                  Destroy(Road[i]);
                  Road[i] = Instantiate(Cutted_tile, GenerationPoint, Cutted_tile.transform.rotation);
              }

          }




  }*/
}
