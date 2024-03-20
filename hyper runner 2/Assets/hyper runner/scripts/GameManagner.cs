using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//more like UI manager
public class GameManagner : MonoBehaviour
{
    
    [SerializeField] GameObject Characters_list;
    [SerializeField] GameObject character_select_button;
    [SerializeField] GameObject Default_Player;

    
    public static  GameManagner instance; 
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }
    private void Start()
    {
        if (Controller.instance.Get_Player() != null)
        Controller.instance.set_Player(Controller.instance.Get_Player());
        else Controller.instance.set_Player(Default_Player);
    }

    public void ShowCharacter()
    {
        
        Characters_list.SetActive(true);
        character_select_button.SetActive(false);
    }

    public void StartGame()
    {
        Controller.instance.Get_State_Handler().Start_running();
        camraScript.instance.ChangeState(CameraStates.following);
            Characters_list.transform.parent.gameObject.SetActive(false);
        
    }
    public void endGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
