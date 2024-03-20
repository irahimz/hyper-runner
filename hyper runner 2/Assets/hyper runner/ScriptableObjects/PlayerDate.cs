using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "scriptable Objects / Player Date ",fileName ="PlayerDate")]
public class PlayerDate : ScriptableObject
{
    public GameObject Player; 
    [Space(10)]
    [Header("running moving proprites")]
    public float forward_speed = 12f;
    public float Horizontal_speed = 1.2f;
    public Vector3[] boarders;
    [Space(10)]
    [Header("end moving proprites")]
    public float Ending_speed = 4;
    
}
