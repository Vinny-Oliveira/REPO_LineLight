using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockProperties
{
    public class Block : MonoBehaviour
    {
        /// <summary>
        /// Check if the block is close enough to the other cubes in order to be aligned with them; a constant epsilon is used as a reference value
        /// </summary>
        /// <param name="inStandardCube"></param>
        /// <param name="inSourceCube"></param>
        /// <param name="inEndCube"></param>
        /// <param name="inEpsilon"></param>
        /// <returns></returns>
        public bool isAligned(GameObject inStandardCube, GameObject inSourceCube, GameObject inEndCube, float inEpsilon) {
            float distToSource = Vector3.Distance(inStandardCube.transform.position, inSourceCube.transform.position);
            float distToEnd = Vector3.Distance(inStandardCube.transform.position, inEndCube.transform.position);
            //Debug.Log(distToSource + " , " + distToEnd);

            /* Distance between cube and source cube */                                                                /* Distance between cube and end cube */
            if ((distToSource < inEpsilon) && (distToEnd < inEpsilon))
            {
                Debug.Log("ALIGNED");
                return true;
            }
            else
            {
                Debug.Log("NOT ALIGNED");
                return false;
            }
        }

        /// <summary>
        /// Attach the player to the block's joint
        /// </summary>
        /// <param name="inPlayer"></param>
        public void AttachToPlayer(GameObject inPlayer, FixedJoint inBoxJoint)
        {
            inBoxJoint.connectedBody = inPlayer.GetComponent<Rigidbody>();
            inBoxJoint.enableCollision = true;
        }

        /// <summary>
        /// Detach the player from the block's joint
        /// </summary>
        public void DetachFromPlayer(FixedJoint inBoxJoint)
        {
            inBoxJoint.connectedBody = null;
            inBoxJoint.enableCollision = false;
        }

    }
}
