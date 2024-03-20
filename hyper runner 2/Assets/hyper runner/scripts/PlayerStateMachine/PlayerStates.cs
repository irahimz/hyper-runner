using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates{ }

public delegate void CorutineDelegate(IEnumerator c);
public abstract class State
{
    protected Transform transform;
    protected Rigidbody rb;
    public abstract void Update();
    public virtual void Start(){}
    public abstract void EndState();
    public abstract void GetBasicProprites(Transform tr , Rigidbody rb);
    public virtual event CorutineDelegate StartCoroutineEvent;
}