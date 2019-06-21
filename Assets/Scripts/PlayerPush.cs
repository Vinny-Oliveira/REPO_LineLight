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

        // 
        Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
        rbTouchingBody.velocity = pushDir * fltPushPower;
    }
}