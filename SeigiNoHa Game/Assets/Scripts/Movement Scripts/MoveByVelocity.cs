using UnityEngine;
using System.Collections;
using SNH.Movement;

public class MoveByVelocity : Move,ICanMove
{
    [SerializeField]
    Rigidbody r_Rigidbody;
    public void MoveObject(Vector3 moveVector)
    {
        r_Rigidbody.velocity = moveVector * moveMentSpeed * Time.deltaTime;
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
