using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOscillate : MonoBehaviour {
    public Vector3 range;
    public float rate = 1;
    public float triggerProximity = 0;

    private bool m_bIsOscillating = false;
    private PlayerMovement m_Player;

	// Use this for initialization
	void Start () {
        m_Player = FindObjectOfType<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_bIsOscillating)
            return;

        if (triggerProximity == 0)
        {
            StartOsc();
        }
        else if (Vector3.Distance(transform.position, m_Player.transform.position) <= triggerProximity)
        {
            StartOsc();
        }
	}

    bool m_ToggleDir = false;
    private void StartOsc()
    {
        m_bIsOscillating = true;
        Vector3 targetPos = transform.position + range;
        if (m_ToggleDir)
        {
            targetPos = transform.position - range;
        }
        Wrj.Utils.MapToCurve.EaseIn.MoveWorld(transform, targetPos, rate, mirrorCurve: true, mirrorPingPong: 1, onDone: StartOsc);
        m_ToggleDir = !m_ToggleDir;
    }
}
