using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ending_line_1 : MonoBehaviour
{
    public GameObject goal;


    private void OnTriggerEnter(Collider other)
    {
        State_handeler handler; 
        
        if (!other.TryGetComponent<State_handeler>(out handler)) return;       
        handler.Change_State(new EndMovingState(handler.playerData,goal));
    }

}
