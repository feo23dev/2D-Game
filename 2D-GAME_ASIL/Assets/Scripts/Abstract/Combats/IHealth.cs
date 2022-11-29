using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UProje.Abstract.Combat
{
    public interface IHealth : ITakeHit
    {
        //int CurrentHealth { get; }
        bool IsDead { get;}
        event System.Action OnHealthChange;


    }
        
    


}


