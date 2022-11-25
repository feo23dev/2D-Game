using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    public class TakeHit : IState
    {
        public void OnEnter()
        {
            Debug.Log("TakeHit on Enter");
        }

        public void OnExit()
        {
            Debug.Log("TakeHit on Exit");
        }

        public void Tick()
        {
            Debug.Log("TakeHit on Tick");
        }
    }



}


