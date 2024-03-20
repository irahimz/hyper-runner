using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGeneration : MonoBehaviour
{
    [SerializeField] GameObject Book, PS;
    [SerializeField] Vector3 LowerCorner, UpperCorner;
    Vector3 latestBooklinePosition;
    public int Platform_ID = 0;
    [Range(1,5)] [SerializeField] float genrationDistance;
    // Start is called before the first frame update
    private void Start()
    {
        if (Platform_ID < 2) return;
        GeneratePS();
        latestBooklinePosition = new Vector3(Random.Range(LowerCorner.x,UpperCorner.x) , LowerCorner.y , LowerCorner.z );
        while (latestBooklinePosition.z < UpperCorner.z)
        {
            GenerateBookLine(latestBooklinePosition);
        }

    }

    void GenerateBookLine(Vector3 LineBegining)
    {
        Vector3 instainationPos = LineBegining;
        int LineMaximum = Random.Range(2, 5);
        for (int i = 0; i<LineMaximum; i++)
        {
            if (latestBooklinePosition.z > UpperCorner.z) break;
            GameObject b = Instantiate(Book);
            b.transform.parent = transform;
            b.transform.localPosition = instainationPos;
            
            instainationPos += new Vector3(0, 0, genrationDistance);
            latestBooklinePosition = new Vector3(Random.Range(LowerCorner.x, UpperCorner.x),latestBooklinePosition.y , latestBooklinePosition.z+ genrationDistance);
        }
    }
    void GeneratePS()
    {

        int r = Random.Range(0, 4);
        GameObject[] ps5s = new GameObject[r];
        float Edistance = Mathf.Abs(LowerCorner.z - UpperCorner.z) /r;
        float currentpos = 0.75f;
        for (int i = 0; i < r; i++)
            {
                GameObject P = Instantiate(PS);
                P.transform.parent = transform;
                P.transform.localPosition = new Vector3(
                        Random.Range(LowerCorner.x, UpperCorner.x), //xpos 
                        LowerCorner.y-1.2f, //ypos
                        LowerCorner.z + currentpos*Edistance);//zpos
                currentpos++;
                ps5s[i] = P;
            }
        
        

    }
}
