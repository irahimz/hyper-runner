using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Controller : MonoBehaviour
{
    [SerializeField] GameObject _Head;
    [SerializeField] State_handeler S_handler;
    [HideInInspector] GameObject Player_Character;
    public static Controller instance;
    
    private int score;
    public TextMeshProUGUI scoreText;
    
    public float Head_size_changing_conf = 0.5f;
    Vector3 Head_size_temp = new Vector3(1, 1, 1);

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);

    }
    public void SetScore(int value)
    {
        score += score+value>=0 ? value : 0 ;
     setScoreText(score);
    }
    public void incriase_Head_size(int change_value)
    {
        if (_Head.transform.localScale.x + change_value < 1)
        {
            _Head.transform.localScale = Vector3.one;
            return;
        }

        else if (_Head.transform.localScale.x + change_value > 9) { _Head.transform.localScale = Vector3.one * 9; return; }

        _Head.transform.localScale +=
            new Vector3(
            change_value * Head_size_changing_conf,
            change_value * Head_size_changing_conf,
            change_value * Head_size_changing_conf);

            camraScript.instance.OnCollect(change_value);

    }
    public int GetScore() { return score; }
    public void setScoreText(int score) { scoreText.text = score.ToString(); }
    public void setHead(GameObject H) { _Head = H;_Head.transform.localScale = Head_size_temp; }
    public void S_hanlder_Setter(State_handeler S_H ) { S_handler = S_H; }
    public State_handeler Get_State_Handler() { return S_handler; }
    public void set_Player(GameObject P) 
    {
        Vector3 Old_Postion = Player_Character != null ?  Player_Character.transform.position : new Vector3(0,0,0);
        Head_size_temp = _Head!=null ?  _Head.transform.localScale : new Vector3(1,1,1);
        if (Player_Character != null) Destroy(Player_Character);
        Player_Character = Instantiate(P,Old_Postion,P.transform.rotation); 
        camraScript.instance.Set_PLayer(Player_Character);
        
    }
    public GameObject Get_Player() 
    {
        return Player_Character; 
    }


}

