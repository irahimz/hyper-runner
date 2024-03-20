using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ps5 : collectable
{
    GameObject player;
    float f_speed;
    public override void On_touch(GameObject g)
    {
        player = g;
        base.On_touch(g);
        StartCoroutine(stumpbaby());
       
    }
    IEnumerator stumpbaby()
    {
        yield return new WaitForSeconds(0.5f);
        player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("stumple");
        f_speed = player.GetComponent<State_handeler>().forward_speed;
        player.GetComponent<State_handeler>().forward_speed = f_speed / 2;
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<State_handeler>().forward_speed = f_speed;
        player.transform.GetChild(0).transform.localEulerAngles = Vector3.zero; 
    }


}
