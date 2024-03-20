using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraStates
{
    following,
    movingToPosition,
    
}
public class camraScript : MonoBehaviour
{
    public static camraScript instance;
    public CameraStates currentState = CameraStates.following;

    //outside refrences 
    [SerializeField]
    private GameObject _Player;

    //follwing data and variables
    [Header("follwing data and variables")]
    [SerializeField]
    Vector3 Follow_offset = new Vector3(8.7f, 20.7f, -19.5f);
    [Range(0f, 50f)]
    [SerializeField]
    float _AHeadDestance;


    GameObject _Ahead;

    //move toward data and variables 
    [Header("move toward data and variables ")]
    
    public float movingSpeed;
    [SerializeField]
    public Transform movingDestination;
    public Transform movinglookingTarget ;
    [SerializeField]
    public Vector3 MovingOffset;

    //on collect data
    public Vector3 OnCollectOffset;
    private Vector3 TEMPOFFSET;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }
    private void Start()
    {
        if(_Player==null) return;
        movinglookingTarget = _Player.transform;
        switch (currentState)
        {
            case CameraStates.following:
                _Ahead = _Ahead ==null ?  new GameObject("ahead"):_Ahead;
                _Ahead.transform.parent = _Player.transform;
                TEMPOFFSET = Follow_offset;
                break;
            case CameraStates.movingToPosition:
    
                break;
        }

    }

    private void LateUpdate()
    {
        if (_Player == null) return;
        switch (currentState)
        {
            case CameraStates.following:
                follow();       
                break;
            case CameraStates.movingToPosition:
                Move_to(movingDestination, movinglookingTarget);
                break;
        }
    }

    public void follow()
    {
              
        transform.position = _Player.transform.position + Follow_offset; // changing the position should be before the looking or it will sututter 
        _Ahead.transform.position = _Player.transform.position + _Player.transform.forward * _AHeadDestance;
        transform.LookAt(_Ahead.transform);
    }
    public void Move_to(Transform destination  , Transform lookingAt) //moving toward destination while lookingAt choosed place
    {
        transform.position = Vector3.MoveTowards(transform.position,destination.position + MovingOffset,movingSpeed * Time.deltaTime);
        transform.LookAt(lookingAt);

    }
    public void ChangeState(CameraStates _state)
    {
        currentState = _state;
        Start();

    }


    
    public void OnCollect(int value)
    {
        //Debug.Log($"on collect and value is {value}");
        
        if (value > 0) Follow_offset -= OnCollectOffset * Mathf.Abs(value);
        else if (value < 0)
        {
            //Debug.Log("value is less than 0");
            Follow_offset += OnCollectOffset * Mathf.Abs(value);
           // if (TEMPOFFSET.z - Follow_offset.z < 1   ) Follow_offset = TEMPOFFSET;
         
        }

    }
    
    public void Set_PLayer(GameObject P)
    {
        _Player = P;
        Start();
    }

    public void set_to_move(Transform dest , Transform target , Vector3 offset)
    {
        movingDestination = dest;
        movinglookingTarget = target;
        MovingOffset = offset;
        ChangeState(CameraStates.movingToPosition);
    }

}




