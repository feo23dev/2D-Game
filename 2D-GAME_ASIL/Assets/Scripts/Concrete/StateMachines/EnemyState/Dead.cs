using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    public class Dead : IState
    {
        public void OnEnter()
        {
            Debug.Log("Dead on Enter");
        }

        public void OnExit()
        {
            Debug.Log("Dead on Exit");
        }

        public void Tick()
        {
            Debug.Log("Dead on Tick");
        }
    }



}


