using UnityEngine;
using System.Collections;
using SNH.StateMachine;
[CreateAssetMenu(menuName = "State Machine/Actions/Rotate to Face Move Direction")]
public class RotateToFaceMoveDirection : PlayerControllerStateAction
{
    float angle;
    public override void Execute(PlayerControllerStateController stateController)
    {
        angle = Quaternion.Angle(stateController.transform.rotation, Quaternion.LookRotation(stateController.m_LookInMoveDirectionRotation));

        //and if it's not zero (to avoid a warning)
        if (angle != 0)   //look towards the camera
        {
            stateController.rotateToFaceMoveDirection.RotateObject(stateController.m_LookInMoveDirectionRotation);
        }      
    }
}
