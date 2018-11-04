using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour {
    public GameObject SegmentSpawnPoint;
    public ColorSwitcher InitialColorBar;

    void Awake () {
        SegmentSpawnPoint.GetComponent<Renderer>().enabled = false;
        InitialColorBar.OnSnakeColorSet += OnEnterSegment;
	}

    private void OnEnterSegment()
    {
        SegmentGenerator.instance.InstantiateRandomSegment(SegmentSpawnPoint.transform.position);
    }
}
