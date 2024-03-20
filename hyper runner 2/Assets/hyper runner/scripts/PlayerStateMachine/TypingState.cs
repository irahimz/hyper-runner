using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingState : State
{
    private Transform Parent_desk;
    private Vector3 dest_position;
    private Vector3 dest_rotation;
    private Animator animator;

    private int ScoreCounter;

    public override event CorutineDelegate StartCoroutineEvent;
    public TypingState(Transform PD, Vector3 pos, Vector3 rot)
    {
        this.Parent_desk = PD;
        this.dest_position = pos;
        this.dest_rotation = rot;
        ScoreCounter = Controller.instance.GetScore();

    }

    public override void EndState() { this.rb.isKinematic = false; }

    public override void GetBasicProprites(Transform tr, Rigidbody rb)
    {
        this.transform = tr;
        this.rb = rb;
        setDown();
    }

    public void setDown()
    {
        Debug.Log($"set down function {ScoreCounter}");
        GameObject Body = transform.GetChild(0).gameObject;
        animator = Body.GetComponent<Animator>();
        transform.parent = Parent_desk;
        transform.localPosition = dest_position;
        transform.localEulerAngles = dest_rotation;
        rb.isKinematic = true;
        animator.SetBool("writing", true);
        StartCoroutineEvent(DecrieseScore());


    }
    public override void Update()
    {



    }
    IEnumerator DecrieseScore()
    {
        Vector3 tempOffsest = camraScript.instance.MovingOffset;
        float tempUpsest = camraScript.instance.movingSpeed;
        camraScript.instance.MovingOffset = new Vector3(4.6f, 6.5f, 13.4f);
        camraScript.instance.movingSpeed /= 3f;
        while (ScoreCounter > 0)
        {
            // Debug.Log(ScoreCounter);
            Controller.instance.setScoreText(ScoreCounter);
            ScoreCounter--;
            Controller.instance.incriase_Head_size(-1);
            yield return new WaitForSeconds(0.2f);
        }
        if (Controller.instance.GetScore() > 5)
        {
            Debug.Log("pass");
            animator.Play("setting vectory");
        }
        else
        {
            Debug.Log("fail");
            animator.Play("setting disbeleive");
        }
        yield return new WaitForSeconds(2);
        GameManagner.instance.endGame();
        

        //camraScript.instance.MovingOffset = tempOffsest; 
    }
}
