using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UProje.Abstract.Inputs;

namespace UProje.Inputs
{
    public class PCInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");

        public float Vertical => Input.GetAxis("Vertical");

        public bool jump => Input.GetButtonDown("Jump");
    }


}

