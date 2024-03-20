using System.Collections;
using UnityEngine;

namespace Assets.hyper_runner.scripts
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] generation _generator;
        [SerializeField] Controller _controller;


        public void startGame()
        {
            _controller.Get_State_Handler().Start_running();
        }
        


        

    }
}