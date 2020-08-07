using UnityEngine;
using System.Collections;
using SNH.InputManager;
using SNH.StateMachine;

[CreateAssetMenu (menuName ="State Machine/Actions/Lsten For Main Axis Input")]
public class ListenForMainAxisInputs : PlayerControllerStateAction
{
    
    public override void Execute(PlayerControllerStateController stateController)
    {
        stateController.m_mainAxisInput.x = Controller.MainHorizontal();
        stateController.m_mainAxisInput.z = Controller.MainVertical();
    }

    
}
