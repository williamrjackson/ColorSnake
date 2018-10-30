using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOnScreen : MonoBehaviour
{
    [Range(-1, 2)]
    public float xOffset = .5f;
    public bool xIgnore;
    public bool xOnUpdate;
    [Range(-1, 2)]
    public float yOffset = .5f;
    public bool yIgnore;
    public bool yOnUpdate;

    private void Start()
    {
        if (!xIgnore)
            SetPositionX();
        if (!yIgnore)
            SetPositionY();
    }

    void Update()
    {
        if (yOnUpdate && !yIgnore)
        {
            SetPositionY();
        }
        if (xOnUpdate && !xIgnore)
        {
            SetPositionX();
        }
    }

    void SetPositionX()
    {
        float screenX = Camera.main.ScreenToWorldPoint(new Vector3(Mathf.LerpUnclamped(0, Screen.width, xOffset), transform.position.y, transform.position.z)).x;
        transform.position = new Vector3(screenX, transform.position.y, transform.position.z);
    }
    void SetPositionY()
    {
        float screenY = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, Mathf.LerpUnclamped(0, Screen.height, yOffset), transform.position.z)).y;
        transform.position = new Vector3(transform.position.x, screenY, transform.position.z);
    }

}