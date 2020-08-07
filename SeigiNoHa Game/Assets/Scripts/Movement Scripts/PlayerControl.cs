using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    Rigidbody rigidBody;
    CapsuleCollider capCol;

    [SerializeField]
    PhysicMaterial zfriction;   //Zero Friction Physic Material (in 2D it's called Physics) we want zero friction when we move

    [SerializeField]
    PhysicMaterial mfriction;    //Max Friction Physic Material (in 2D it's called Physics) but maximum friction when we are sationary

    Transform cam;

    [SerializeField]
    float speed = 0.8f;    //How fast the player can move
    [SerializeField]
    float turnSpeed = 5;    //How fast the player can turn
    [SerializeField]
    float jumpPower = 5;

    /*What does SerializeField mean? It means you can edit these variables in the editor!*/

    Vector3 directionPos;   //The direction the player is facing
    Vector3 storDir;

    float horizontal;
    float vertical;
    bool jumpInput;
    bool onGround;

    void Start()
    {
        //Initialize references
        rigidBody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        capCol = GetComponent<CapsuleCollider>();
        onGround = true;    //The player starts out on the ground
    }

    void Update()
    {
        HandleFriction();
    }

    void FixedUpdate()
    {
        //Inputs
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jumpInput = Input.GetButtonDown("Jump");

        /*
            This if statment is how tolerant we are on changing the direction based on where the camera is looking.
            For example, if the player is moving to the left/right of where the camera is looking and then he rotates the camera
            so it looks towards where he is going, we will keep moving at the same direction as before
        */
        storDir = cam.right;        //This means, the player can keep moving in the same direction they were before even if they change the camera angle


        if (onGround)        //Jump!, does not rotate
        {
            rigidBody.AddForce(((storDir * horizontal) + (cam.forward * vertical)) * speed / Time.deltaTime);

            //Jump controls
            if (jumpInput && onGround)
            {
                rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);      //ForceMode.Impulse (I think) gives all the force to the jump for only one frame.
            }
        }

        /*Rotates the Character*/
        //Find a position in front of where the camera is looking
        directionPos = transform.position + (storDir * horizontal) + (cam.forward * vertical);
        //Find the direction from that position
        Vector3 dir = directionPos - transform.position;
        dir.y = 0;  //The player should not be bouncing up and down.

        //If the player has been given input, we move!
        if (horizontal != 0 || vertical != 0)
        {
            //find the angle, between the character's rotation and where the camera is looking
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(dir));

            //and if it's not zero (to avoid a warning)
            if (angle != 0)   //look towards the camera
            { rigidBody.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime); }
        }
    }

    //If we are touching something (like the ground )
    void OnCollisionEnter(Collision other)
    {
        //This means we are on the ground

        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            rigidBody.drag = 5;
        }
    }

    //Once we are no longer touching the object we collided with earlier
    void OnCollisionExit(Collision other)
    {
        //We want to know when we have left the ground (or anything else)
        if (other.gameObject.tag == "Ground")    //You can copy this if statement and make it "Vehicle" or something to jump off a car.
        {
            onGround = false;
            rigidBody.drag = 0;
        }
    }


    void HandleFriction()   //handles the friction physics for the character
    {
        if (horizontal == 0 && vertical == 0)
        {
            //We are stationary so we want maximum friction.
            capCol.material = mfriction;
        }
        else
        {
            //We are moving, don't cause friction
            capCol.material = zfriction;
        }
    }
}