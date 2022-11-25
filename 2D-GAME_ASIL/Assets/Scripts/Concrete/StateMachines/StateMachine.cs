
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines
{
    public class StateMachine 
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>();
        List<StateTransition> _anyStateTransitions = new List<StateTransition>();

        IState _currentState; //idle - walk 

        public void SetState(IState state) // walk
        {   
            if( state == _currentState)  return;

            _currentState?.OnExit(); // current state den çikarken yapmak istediklerimizi yap, çünkü current den çikip digerine geçicez
            _currentState = state;
            _currentState.OnEnter(); // yeni gelen state i OnEnter çalıştırdık.
        }

        public void Tick() // update içinde çalisacak
        {
            StateTransition stateTransition = CheckForTransition();

            if(stateTransition != null)
            {
                SetState(stateTransition.To);
            }

            _currentState.Tick(); // Tick fucn. inside every state(walk,attack etc)..it will run in Update all the time


        }

        private StateTransition CheckForTransition()
        {

            foreach (StateTransition anyStateTransition in _anyStateTransitions)
            {
                if(anyStateTransition.Condition.Invoke()) return anyStateTransition;
            }


            foreach(StateTransition stateTransition in _stateTransitions)
            {
                if(stateTransition.Condition() && stateTransition.From == _currentState) // walk - walk ise 
                {
                    return stateTransition;
                }
            }
            
            return null; // if this returns null, Tick function above, will keep runnng _currentState.Tick()..
        }

        public void AddTransition(IState from, IState to,System.Func<bool> condition)
        {
            StateTransition stateTransition = new StateTransition(from,to,condition);
            _stateTransitions.Add(stateTransition);
            
        }

        public void AddAnyState(IState to, System.Func<bool> condition)
        {
            StateTransition anyStateTransition = new StateTransition(null,to,condition);
            _anyStateTransitions.Add(anyStateTransition);


        }

       
        
    }



}


