using UnityEngine;
using System.Collections;
using SNH.Movement;
public class SlerpRotateRigidbody : Rotation,ICanRotate
{
    [SerializeField]
    Rigidbody rigidBody;
    public void RotateObject(Vector3 moveVector)
    {
        
            rigidBody.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveVector), rotationSpeed * Time.deltaTime);
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
