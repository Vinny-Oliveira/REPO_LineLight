using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockProperties;

public class BlockKinematics : MonoBehaviour
{
    Block thisBlock = new Block();

    //public float fltPushPower = 2f;
    private Rigidbody rbBlock;
    private FixedJoint boxJoint;

    // Cubes of start and end of the path
    public GameObject sourceCube;
    public GameObject endCube;

    // Epsilon: arbitrary distance for alignment
    [SerializeField]
    public float EPSILON = 0f;

    private void Start() {
        rbBlock = gameObject.GetComponent<Rigidbody>();
        boxJoint = gameObject.GetComponent<FixedJoint>();
    }

    /// <summary>
    /// Allow the block to move when the player touches it while pressing the grab key
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.Space)) {
            //Debug.Log("Collided");
            rbBlock.isKinematic = false;
            thisBlock.AttachToPlayer(collision.gameObject, boxJoint);
        }
    }

    /// <summary>
    /// Make the block move if it is grabbed by the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (Input.GetKeyDown(KeyCode.Space)) // Allow the block to be movable
            {
                //Debug.Log("Block grabbed");
                rbBlock.isKinematic = false;
                thisBlock.AttachToPlayer(collision.gameObject, boxJoint);
            }
            else if (Input.GetKeyUp(KeyCode.Space)) // Release the block and make it immovable
            {
                //Debug.Log("Block released"); 
                rbBlock.isKinematic = true;
                thisBlock.DetachFromPlayer(boxJoint);

                // Check if the block is aligned with the others
                thisBlock.isAligned(gameObject, sourceCube, endCube, EPSILON);
            }
        }
    }

    /// <summary>
    /// Do not allow the block to move anymore if the player is not touching it
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            //Debug.Log("Separated");
            rbBlock.isKinematic = true;
        }
    }

    ///// <summary>
    ///// Attach the player to the block's joint
    ///// </summary>
    ///// <param name="inPlayer"></param>
    //void AttachToPlayer(GameObject inPlayer) {
    //    boxJoint.connectedBody = inPlayer.GetComponent<Rigidbody>();
    //    boxJoint.enableCollision = true;
    //}

    ///// <summary>
    ///// Detach the player from the block's joint
    ///// </summary>
    //void DetachFromPlayer() {
    //    boxJoint.connectedBody = null;
    //    boxJoint.enableCollision = false;
    //}
}
