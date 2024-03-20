using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : collectable
{
    public override void On_touch(GameObject g = null)
    {
        base.On_touch(g);
        Debug.Log("book touched");
        Destroy(gameObject);
    }
}
