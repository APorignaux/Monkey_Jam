using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public Transform camera;

    void Start()
    {
        camera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, camera.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed);
    }
}
