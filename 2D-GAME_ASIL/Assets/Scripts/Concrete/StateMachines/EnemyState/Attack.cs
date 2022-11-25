using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines.EnemyStates
{
    
    public class Attack : IState
    {
        public void OnEnter()
        {
            Debug.Log("Attack on Enter");
        }

        public void OnExit()
        {
            Debug.Log("Attack on Exit");
        }

        public void Tick()
        {
            Debug.Log("Attack on Tick");
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}


