using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class desk_script : MonoBehaviour
{
    State_handeler handler;
    [SerializeField]
    GameObject ChairSet;
   Vector3 Character_pos = new Vector3(-05f,0,45f);
   Vector3 Character_Rot = new Vector3(0,-25f, 0);
    bool PlayerEntered;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered the desk");
        if (!(other.TryGetComponent<State_handeler>(out handler)) || PlayerEntered) return;
        handler.Change_State(new TypingState(transform, Character_pos, Character_Rot));
        PlayerEntered = true;
    }

    
}

