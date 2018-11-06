using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform2D : MonoBehaviour {
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
        Vector3 targetByAxis = new Vector3();
        if (horizontal)
        {
            targetByAxis.x = targetObject.position.x;
        }
        else
        {
            targetByAxis.x = transform.position.x - offset.x;
        }
        if (vertical)
        {
            targetByAxis.y = targetObject.position.y;
        }
        else
        {
            targetByAxis.y = transform.position.y - offset.y;
        }
        Vector3 targetPosition = new Vector3(targetByAxis.x + offset.x, targetByAxis.y + offset.y, targetByAxis.z + offset.z);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}
