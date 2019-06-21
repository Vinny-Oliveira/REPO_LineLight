using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockKinematics : MonoBehaviour
{
    /// <summary>
    /// Allow the block to move when the player is touching it
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            //Debug.Log("Collided");
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
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
