using UnityEngine;
using System.Collections;
using SNH.StateMachine;
[CreateAssetMenu(menuName = "State Machine/Actions/Calculate Look Rotation Camera Relative From Main Axis")]
public class CalculatenRotationToMatchMoveDirectiion : PlayerControllerStateAction
{
    Vector3 lookDirectionPosition;
    Vector3 tempRotation;
    public override void Execute(PlayerControllerStateController stateController)
    {
        if (stateController.m_Move.x != 0 || stateController.m_Move.z != 0)
        {
            lookDirectionPosition = stateController.transform.position + stateController.m_Move;
            tempRotation = lookDirectionPosition - stateController.transform.position;
            tempRotation.y = 0;
            stateController.m_LookInMoveDirectionRotation = tempRotation;
        }
    }

}
