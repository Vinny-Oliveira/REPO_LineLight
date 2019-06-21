using UnityEngine;
using System.Collections;

public class PlayerPush : MonoBehaviour
{
    public float fltPushPower = 2f;

    /// <summary>
    /// Make the player push a block when they are touching it
    /// </summary>
    /// <param name="hit"></param>
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rbTouchingBody = hit.collider.attachedRigidbody; // Rigidbody of the object the player hits

        // Do nothing if there is no Rigidbody or if the object is kinematic (may not be moved)
        if (rbTouchingBody == null || rbTouchingBody.isKinematic || hit.moveDirection.y < -0.3f) {
            return;
        }

        //if (Input.GetKeyDown(KeyCode.E)) {
        //    Debug.Log("PRESSED E");
        //    //GameObject box = hit.collider.gameObject;
        //    FixedJoint boxJoint = hit.collider.gameObject.GetComponent<FixedJoint>();
        //    boxJoint.connectedBody = gameObject.GetComponent<Rigidbody>(); // Attach the block to the player
        //    //boxJoint.enableCollision = true;
        //} else if (Input.GetKeyUp(KeyCode.E)) {
        //    FixedJoint boxJoint = hit.collider.gameObject.GetComponent<FixedJoint>();
        //    boxJoint.connectedBody = null;
        //    //boxJoint.enableCollision = false;
        //}

        if (Input.GetKey(KeyCode.E)) {
            // Make the hit object move in the direction of the player
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            //Vector3 pushDir = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, 0, gameObject.GetComponent<Rigidbody>().velocity.z);
            //pushDir = pushDir.normalized;
            rbTouchingBody.velocity = pushDir * fltPushPower;
        }
        
    }
}