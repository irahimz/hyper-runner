using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Selector : MonoBehaviour , Selector_Base
{
    public GameObject MyPlayer;
    public Character_Selection_UI CSUI;
    public GameObject selected_visualize;

    public void deSelect()
    {
        Toggle_visualize();
    }

    public void select()
    {
        if(CSUI.Selected_selector!=null)CSUI.Selected_selector.deSelect();
        CSUI.SetPlayer(MyPlayer);
        CSUI.Selected_selector = this;
        Toggle_visualize();
    }


    void Toggle_visualize()
    {
        selected_visualize.SetActive(!selected_visualize.activeSelf);
    }
}
