using System.Collections;
using UnityEngine;


public class Idle_state : State
{
    public override void Start()
    {
        camraScript cam = camraScript.instance;
        cam.set_to_move(cam.transform, transform, new Vector3(0, 0, 0));
        transform.LookAt(new Vector3( cam.transform.position.x , transform.position.y , cam.transform.position.z));
        
        transform.GetChild(0).GetComponent<Animator>().Play("waving");
        Debug.Log("this is from idle state");
    }
    public override void EndState() { }

    public override void GetBasicProprites(Transform tr, Rigidbody rb)
    {
        this.transform = tr;
        this.rb = rb;
        Start();
    }

    public override void Update() { }
}