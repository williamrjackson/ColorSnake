using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform targetObject;
	public float smoothTime = 0.3F;
    public bool vertical = true;
    public bool horizontal = true;

	private Vector3 offset;
	private Vector3 velocity = Vector3.zero;

	void Start()
	{
		offset = new Vector3 (transform.position.x - targetObject.position.x, transform.position.y - targetObject.position.y, transform.position.z - targetObject.position.z);
	}

	void LateUpdate () {
        Vector3 carByAxis = new Vector3();
        if (horizontal)
        {
            carByAxis.x = targetObject.position.x;
        }
        else
        {
            carByAxis.x = transform.position.x - offset.x;
        }
        if (vertical)
        {
            carByAxis.y = targetObject.position.y;
        }
        else
        {
            carByAxis.y = transform.position.y - offset.y;
        }
        Vector3 targetPosition = new Vector3(carByAxis.x + offset.x, carByAxis.y + offset.y, carByAxis.z + offset.z);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
