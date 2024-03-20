using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class State_handeler : MonoBehaviour
{
    public PlayerDate playerData;
    [Header("Running State properties")]
    public float forward_speed;
    public float horizontal_speed;
    public Vector3[] Boarders;
    [Space(15)]
    [Header("End Moving properties")]
    public float EndingSpeed;

    public State currentstate;
    void Awake()
    {
    
        currentstate = new Idle_state();
        currentstate.GetBasicProprites(transform, GetComponent<Rigidbody>());

        
    }
    private void Start()
    {
        Controller.instance.S_hanlder_Setter(this);
    }

    // Update is called once per frame
    void Update()
    {
        playerData.forward_speed = forward_speed;
        playerData.Horizontal_speed = horizontal_speed;
        playerData.Ending_speed = EndingSpeed;
        playerData.boarders = Boarders;
        currentstate.Update();
    } 

    public void Change_State(State state)
    {
        Debug.Log($"current state is : {state }");
        StopAllCoroutines();
        currentstate.EndState();
        currentstate = state;
        currentstate.StartCoroutineEvent += Scorutine;
        currentstate.GetBasicProprites(transform, GetComponent<Rigidbody>());

    }
    
    public void Scorutine(IEnumerator _Ienum)
    {
        StartCoroutine(_Ienum);
    }
    public void Start_running()
    {
        currentstate = new RunningState(playerData);
        currentstate.GetBasicProprites(transform, GetComponent<Rigidbody>());
    }
}
