using UnityEngine;
using System.Collections;
using SNH.StateMachine;
using SNH;
public class PlayerControllerStateController : StateController
{
    public PlayerControllerState currentState;
    public PlayerControllerState remainInState;

    public MoveObjectByRigidbodyForce moveByForce;
    public SlerpRotateRigidbody rotateToFaceMoveDirection;

   // [HideInInspector]
    public Transform m_Cam;                  // A reference to the main camera in the scenes transform
  //  [HideInInspector]
   // public Vector3 m_CamForward;
    //[HideInInspector]
    public Vector3 m_mainAxisInput;
   // [HideInInspector]
    public Vector3 m_Move;
 //   [HideInInspector]
    public Vector3 m_LookInMoveDirectionRotation;
  //  [HideInInspector]
    public bool m_Jump;
    
    // Use this for initialization
    void Start()
    {
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
        
        currentState.EnterStateActions(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }
    public void TransitionToState(PlayerControllerState nextState)
    {
        if (nextState != remainInState)
        {
            currentState.ExitStateActions(this);
            currentState = nextState;
            currentState.EnterStateActions(this);
        }
    }
   
}
