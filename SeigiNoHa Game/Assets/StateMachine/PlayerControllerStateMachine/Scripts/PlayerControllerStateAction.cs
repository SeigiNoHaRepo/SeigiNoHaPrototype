using UnityEngine;
using System.Collections;

namespace SNH.StateMachine
{
    public abstract class PlayerControllerStateAction : ScriptableObject
    {
        public abstract void Execute(PlayerControllerStateController stateController);
    }
}