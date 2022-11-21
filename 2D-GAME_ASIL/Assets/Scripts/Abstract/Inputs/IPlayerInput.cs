using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UProje.Abstract.Inputs
{
    public interface IPlayerInput
    {
        public float Horizontal { get; }
        public float Vertical { get; }

        public bool jump { get;}
        
        public bool attack { get;}

    }

}

