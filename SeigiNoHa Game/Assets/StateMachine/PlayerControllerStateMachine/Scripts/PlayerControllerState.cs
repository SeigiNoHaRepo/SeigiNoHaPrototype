using UnityEngine;
using System.Collections;
using System;

namespace SNH.StateMachine
{
    [CreateAssetMenu(menuName = "State Machine/State/PlayerControllerState")]
    public class PlayerControllerState : State
    {
      //  public PlayerMove playerMove;
        public PlayerControllerStateAction[] updateActions;
        public PlayerControllerStateAction[] fixedUpdateActions;
        public PlayerControllerStateAction[] enterStateActions;
        public PlayerControllerStateAction[] exitStateActions;
        public PlayerControllerTransitions[] transitions;
        

        public void UpdateState(PlayerControllerStateController stateController)
        {
            ExecuteUpdateActions(stateController);
            CheckTransitions(stateController);
        }

        public void FixedUpdateState(PlayerControllerStateController stateController)
        {
            ExecuteFixedUpdateActions(stateController);
        }

        private void ExecuteFixedUpdateActions(PlayerControllerStateController stateController)
        {
            if (fixedUpdateActions.Length == 0) return;
            for (int i = 0; i < updateActions.Length; i++)
            {
                fixedUpdateActions[i].Execute(stateController);
            }
        }

        public void EnterStateActions(PlayerControllerStateController stateController)
        {
            for (int i = 0; i < enterStateActions.Length; i++)
            {
                enterStateActions[i].Execute(stateController);
            }

        }

        public void ExitStateActions(PlayerControllerStateController stateController)
        {
            for (int i = 0; i < exitStateActions.Length; i++)
            {
                exitStateActions[i].Execute(stateController);
            }
        }

        public void ExecuteUpdateActions(PlayerControllerStateController stateController)
        {
            for (int i = 0; i < updateActions.Length; i++)
            {
                updateActions[i].Execute(stateController);
            }
        }

        public void CheckTransitions(PlayerControllerStateController stateController)
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decisionSuccess = transitions[i].decision.Decide(stateController);
                if (decisionSuccess)
                {
                    stateController.TransitionToState(transitions[i].trueState);
                }
                else
                {
                    stateController.TransitionToState(transitions[i].failState);
                }
            }

        }
    }
}