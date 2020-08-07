using UnityEngine;
using System.Collections;
using SNH.Movement;
public class PlayerMove : Move,ICanMove
{
   
  
    [SerializeField]
    private Rigidbody r_PlayerRigidBody;
    public void MoveObject(Vector3 moveVector)
    {
        r_PlayerRigidBody.velocity = new Vector3(moveVector.x, 0f, moveVector.y);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
