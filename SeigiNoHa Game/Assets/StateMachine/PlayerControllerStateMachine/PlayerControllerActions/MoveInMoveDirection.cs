using UnityEngine;
using System.Collections;
using SNH.StateMachine;
[CreateAssetMenu(menuName = "State Machine/Actions/Move in Direction")]
public class MoveInMoveDirection : PlayerControllerStateAction
{
    public override void Execute(PlayerControllerStateController stateController)
    {
        stateController.moveByForce.MoveObject(stateController.m_Move);
    }

    
}
