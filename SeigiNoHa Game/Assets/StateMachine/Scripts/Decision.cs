using UnityEngine;
using System.Collections;

namespace SNH.StateMachine
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(StateController stateController);

      
    }
}