using UnityEditor;
using UnityEngine;

public class SnapToGround : MonoBehaviour
{
    /// <summary>
    /// This script makes objects snap to the bottom plane when the user presses Ctrl + G
    /// </summary>
    [MenuItem("Custom/Snap To Ground %g")]
    public static void Ground()
    {
        foreach (var transform in Selection.transforms) // Loop through all objects selected in the hierarchy
        {
            var hits = Physics.RaycastAll(transform.position + Vector3.up, Vector3.down, 10f); // Check for objects beneath it
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject == transform.gameObject) { // Avoid collision with self
                    continue;
                } else if (hit.collider.gameObject.transform.parent.gameObject == transform.gameObject) { // Avoid collision with children
                    continue;
                }

                // Snap to ground position
                transform.position = new Vector3(hit.point.x, hit.point.y + (transform.gameObject.transform.localScale.y / 2), hit.point.z);
                break;
            }
        }
    }

}