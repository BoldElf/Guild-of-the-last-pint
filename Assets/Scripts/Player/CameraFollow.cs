using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset; 
    public Vector3 rotationOffset; 

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;

            transform.rotation = Quaternion.Euler(rotationOffset);
        }
    }
}
