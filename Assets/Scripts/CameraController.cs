using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform mainCube;
    private float distanceZ;
    private Vector3 target;

    private void Start()
    {
        distanceZ = mainCube.position.z - transform.position.z;
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        transform.position = Vector3.Lerp(transform.position, TargetPosition(), 0.5f);
    }

    private Vector3 TargetPosition()
    {
        target = new Vector3(transform.position.x, transform.position.y, mainCube.position.z - distanceZ);
        return target;
    }
}
