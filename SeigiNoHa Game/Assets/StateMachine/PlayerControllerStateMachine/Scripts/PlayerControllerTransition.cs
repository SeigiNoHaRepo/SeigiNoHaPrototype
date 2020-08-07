using UnityEngine;
using System.Collections;

namespace SNH.StateMachine
{
    [System.Serializable]
    public class PlayerControllerTransitions : Transition
    {
        public PlayerControllerState trueState;

        public PlayerControllerState failState;
    }
}
