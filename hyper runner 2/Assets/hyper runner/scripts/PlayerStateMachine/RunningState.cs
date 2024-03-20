using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : State
{

    public PlayerDate playerDate;

    Vector2 Initalpoint; // first touch position
    Vector3 mypos; // player position when touched 


    public RunningState(PlayerDate _playerDate)
    {
        playerDate = _playerDate;
    }
    public override void Start() 
    {
        transform.localEulerAngles = Vector3.zero;
        Transform child = transform.GetChild(0);
       child.GetComponent<Animator>().Play("test runnging");
        camraScript.instance.ChangeState(CameraStates.following);

    }
    public override void Update()
    {
        forward_movment();
        horizontal_movment();
        falling_Check();
    }
    void horizontal_movment()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Initalpoint = Input.mousePosition;
            mypos = transform.position;

        }
        if (Input.GetMouseButton(0))
        {
            float Move_distance = Initalpoint.x - Input.mousePosition.x;
            float X_pos = mypos.x - (Move_distance * playerDate.Horizontal_speed * 0.01f);
            float dirction = Move_distance / Mathf.Abs(Move_distance);
            if (!(X_pos > playerDate.boarders[0].x) && !(X_pos < playerDate.boarders[1].x))
                transform.position = new Vector3(X_pos, transform.position.y, transform.position.z);
        }
       
    }
    void forward_movment()
    {
        transform.position = new Vector3(
                            transform.position.x, 
                            transform.position.y, 
                            transform.position.z + playerDate.forward_speed * Time.deltaTime
                            );
    }

    public override void EndState()
    { rb.velocity = Vector3.zero; }

    public override void GetBasicProprites(Transform tr, Rigidbody RB)
    {
        transform = tr;
        rb = RB;
        Start();
    }

    public void falling_Check()
    {
        if(transform.position.y < -20f)
        {
            GameManagner.instance.endGame();
        }
    }
}
