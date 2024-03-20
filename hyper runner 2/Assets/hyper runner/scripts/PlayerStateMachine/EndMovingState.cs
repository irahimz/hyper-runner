using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMovingState : State
{
    public PlayerDate playerData;

    public GameObject Mcamera;

    public GameObject _goal;
    public override event CorutineDelegate StartCoroutineEvent;

    public EndMovingState(PlayerDate _playerData, GameObject goal)
    {
        playerData = _playerData;
        _goal = goal;

    }

    public override void Update() { }

    public void endscene()
    {
        camraScript.instance.set_to_move(_goal.transform, transform, new Vector3(40, 31.92f, 23.54f));
        StartCoroutineEvent(move_toward_goal());
    }

    public IEnumerator move_toward_goal()
    {
        GameObject body = transform.GetChild(0).gameObject;
        Vector3 looking_position = new Vector3(_goal.transform.position.x, body.transform.position.y, _goal.transform.position.z);


        while (Vector3.Distance(transform.position, _goal.transform.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, _goal.transform.position, 3 * playerData.Ending_speed * Time.deltaTime);
            body.transform.LookAt(looking_position);
            yield return null;
        }
    }


    public override void EndState() { }

    public override void GetBasicProprites(Transform tr, Rigidbody rb)
    {
        this.transform = tr;
        this.rb = rb;
        Start();
        endscene();
    }
}
