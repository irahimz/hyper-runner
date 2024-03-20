using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Selection_UI : MonoBehaviour
{
   
    [HideInInspector] 
    public Selector_Base Selected_selector;

    public void SetPlayer(GameObject P)
    {
        Controller.instance.set_Player(P);
    }
    
}

public interface Selector_Base  
{
    public void select();
    public void deSelect();

}
