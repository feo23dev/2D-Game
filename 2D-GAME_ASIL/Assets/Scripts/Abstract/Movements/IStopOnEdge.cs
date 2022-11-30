using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UProje.Abstract.Movements
{
    public interface IStopOnEdge 
    {
        public bool HasReachEdge();
        public bool isRightDirection { get; set; }
    }

}


