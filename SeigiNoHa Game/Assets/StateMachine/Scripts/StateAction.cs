using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SNH.StateMachine
{
    public abstract class StateAction : ScriptableObject
    {
        public abstract void Execute(StateController stateController);
    }
}