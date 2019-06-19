using UnityEngine;
using System.Collections;

public class PlayerPush : MonoBehaviour
{
    public float fltPushPower = 2f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rbBody = hit.collider.attachedRigidbody;

        if (rbBody == null || rbBody.isKinematic || hit.moveDirection.y < -0.3f) {
            return;
        }

        Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
        rbBody.velocity = pushDir * fltPushPower;
    }
}