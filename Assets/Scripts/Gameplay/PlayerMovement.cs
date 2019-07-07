using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float fltSpeed;
    public Rigidbody rbPlayer;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        // Make the player move by changing the speed of its rigidbody
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal") * fltSpeed, 0, Input.GetAxis("Vertical") * fltSpeed);
        rbPlayer.velocity = moveDir;
    }
}
