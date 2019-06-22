using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockKinematics : MonoBehaviour
{
    public float fltPushPower = 2f;

    /// <summary>
    /// Allow the block to move when the player is touching it
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.Space)) {
            Debug.Log("Collided");
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    /// <summary>
    /// Make the block move if it is grabbed by the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (Input.GetKeyDown(KeyCode.Space)) { // Allow the block to be movable
                Debug.Log("Block grabbed");
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            } else if (Input.GetKeyUp(KeyCode.Space)) {
                Debug.Log("Block released"); // Release the block and make it immovable
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            } else if (Input.GetKey(KeyCode.Space) && !gameObject.GetComponent<Rigidbody>().isKinematic) {
                Vector3 pushDir = new Vector3(collision.gameObject.GetComponent<Rigidbody>().velocity.x, 0, collision.gameObject.GetComponent<Rigidbody>().velocity.z);
                pushDir = pushDir.normalized;
                Debug.Log(pushDir);
                gameObject.GetComponent<Rigidbody>().velocity = pushDir * fltPushPower;
            }
        }
    }

    /// <summary>
    /// Do not allow the block to move if the player is not touching it
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            //Debug.Log("Separated");
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
