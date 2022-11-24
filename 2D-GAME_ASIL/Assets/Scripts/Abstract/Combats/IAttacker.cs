using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UProje.Abstract.Combat
{
    public interface IAttacker 
    {
        void Attack(ITakeHit takeHit);
        int Damage { get; }
        
    }


}


