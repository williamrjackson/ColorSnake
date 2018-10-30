using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour {
    public static SegmentGenerator instance;

    public Wrj.WeightedGameObjects segments;

    private int m_level = 0;
    private List<Segment> segmentList;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        segmentList = new List<Segment>();
    }
    public void InstantiateRandomSegment(Vector3 spawnPosition)
    {
        m_level++;
        Segment randomSeg = Instantiate(segments.GetRandom(), spawnPosition, Quaternion.identity).GetComponent<Segment>();
        randomSeg.name = m_level.ToString();
        QueueDequeue(randomSeg);
    }
    private void QueueDequeue(Segment newSegment)
    {
        segmentList.Add(newSegment);
        if (segmentList.Count > 4)
        {
            Segment destroySeg = segmentList[0];
            segmentList.RemoveAt(0);
            Destroy(destroySeg.gameObject);
        }
    }
}
