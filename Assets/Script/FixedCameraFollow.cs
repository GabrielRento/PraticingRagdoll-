using UnityEngine;

public class FixedCameraFollow : MonoBehaviour
{
    public Transform target;   // ex: Hips
    public Vector3 offset;

    private Quaternion fixedRotation;

    void Start()
    {
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.rotation = fixedRotation;
    }
}