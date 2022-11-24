using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.StateMachines;

namespace UProje.StateMachines
{
    public class StateMachine 
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>();

        IState _currentState;

        public void SetState(IState state)
        {
            if(state == _currentState) return;

            _currentState?.OnExit();
            _currentState = state;
            _currentState.OnEnter();

        }

        public void Tick()
        {
            StateTransition stateTransition = CheckForTransition();
            if(stateTransition != null)
            {
                SetState(stateTransition.To);
                
            }

            _currentState.Tick(); // Tick inside the  IState...and in all State scripts ..for each 
        }

        private StateTransition CheckForTransition()
        {
            foreach(StateTransition stateTransition in _stateTransitions)
            {
                if(stateTransition.Condition() && stateTransition.From == _currentState)
                {
                    return stateTransition;
                }
            }

            return null;
            
        }

        public void AddTransition(IState from, IState to, System.Func<bool> condition)
        {
            StateTransition stateTransition = new StateTransition(from,to,condition);
            _stateTransitions.Add(stateTransition);

        }
        
    }



}


