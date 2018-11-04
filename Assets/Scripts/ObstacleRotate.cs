using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour {
    public float degreesPerSecond;
    public float triggerProximity = 0;

    private bool m_bIsRotating = false;
    private SnakeBehavior m_Player;
    // Use this for initialization
    void Start()
    {
        m_Player = FindObjectOfType<SnakeBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bIsRotating)
        {
            transform.localEulerAngles += Vector3.back * degreesPerSecond * Time.deltaTime;
            return;
        }
        if (triggerProximity == 0 || (Vector3.Distance(transform.position, m_Player.transform.position) <= triggerProximity))
        {
            m_bIsRotating = true;
        }
    }
}
