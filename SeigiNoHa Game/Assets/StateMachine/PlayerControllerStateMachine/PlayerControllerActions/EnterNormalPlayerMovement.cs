using UnityEngine;
using System.Collections;

namespace SNH.StateMachine
{
    [CreateAssetMenu(menuName = "State Machine/Actions/Enter Normal Player Movement")]
    public class EnterNormalPlayerMovement : PlayerControllerStateAction
    {
        public override void Execute(PlayerControllerStateController stateController)
        {
            stateController.m_Move = Vector3.zero;
            stateController.m_Jump = false;
        }
    }
}