using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 maxPos;
    public Vector2 minPos;

    void Update()
    {
        if (transform.position != target.position) {

            Vector3 tragetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            tragetPos.x = Mathf.Clamp(tragetPos.x, minPos.x, maxPos.x);
            tragetPos.y = Mathf.Clamp(tragetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, tragetPos, smoothing);
        }
    }
}