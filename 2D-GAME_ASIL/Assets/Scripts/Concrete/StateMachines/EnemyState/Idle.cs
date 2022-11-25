using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    public class Idle : IState
    {
        public void OnEnter()
        {
            Debug.Log("Idle On Enter Started");
        }

        public void OnExit()
        {
            Debug.Log("Idle on Exit");
        }

        public void Tick()
        {
            Debug.Log("Idle on Tick");
        }
    }



}


