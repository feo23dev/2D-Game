using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace UProje.Abstract.StateMachines
{
    public interface IState 
    {
        void Tick();
        void OnEnter();
        void OnExit();
       
    }


}


