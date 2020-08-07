using UnityEngine;
using System.Collections;
using SNH.Movement;
public class MoveObjectByRigidbodyForce : Move,ICanMove
{
    [SerializeField]
    private Rigidbody r_RigidBody;
    public float speed;
    public void MoveObject(Vector3 moveVector)
    {
        speed = moveMentSpeed / Time.deltaTime;
        r_RigidBody.AddForce(moveVector * speed );
    }  


    // Update is called once per frame
    void Update()
    {
       // speed=moveMentSpeed * Time.deltaTime;
    }
}
