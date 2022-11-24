using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines
{
    public class StateTransition 
    {
        IState _from;
        IState _to;
        System.Func<bool> _condition;

        public IState From => _from;
        public IState To => _to; 
        public System.Func<bool> Condition => _condition;

        public StateTransition(IState from, IState to,System.Func<bool> condition)  // constructor 
        {
            _from = from;
            _to = to;
            _condition = condition;
        }   

       
    }


}


