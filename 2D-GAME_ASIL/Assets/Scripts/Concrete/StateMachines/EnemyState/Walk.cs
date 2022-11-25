using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    public class Walk : IState
    {
        public void OnEnter()
        {
            Debug.Log("Walk on Enter");
        }

        public void OnExit()
        {
            Debug.Log("Walk on Exit");
        }

        public void Tick()
        {
            Debug.Log("Walk on Tick");
        }
    }


}


