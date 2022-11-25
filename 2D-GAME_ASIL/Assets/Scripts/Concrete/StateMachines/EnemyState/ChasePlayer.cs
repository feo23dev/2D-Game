using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    public class ChasePlayer : IState
    {
        public void OnEnter()
        {
            Debug.Log("ChasePlayer on Enter");
        }

        public void OnExit()
        {
            Debug.Log("ChasePlayer on Exit");
        }

        public void Tick()
        {
            Debug.Log("ChasePlayer on Tick");
        }
    }



}


