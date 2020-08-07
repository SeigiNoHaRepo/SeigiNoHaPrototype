using UnityEngine;
using System.Collections;
using SNH.StateMachine;

[CreateAssetMenu (menuName ="State Machine/Actions/Calculate Move Direction From Main Axis")]
public class CalculateMoveDirectionFromMainInputAxis : PlayerControllerStateAction
{
    private Vector3 normalizedInput;
    public override void Execute(PlayerControllerStateController stateController)
    {
        normalizedInput = stateController.m_mainAxisInput.normalized;
       
        stateController.m_Move = stateController.m_Cam.right * normalizedInput.x+ stateController.m_Cam.forward * normalizedInput.z;
    }

   
}
