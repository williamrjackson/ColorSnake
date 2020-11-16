using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour {
    public static SegmentGenerator instance;

    public int repeatThreshold = 2;
    public List<Segment> segments;

    private int m_level = 0;
    private List<Segment> segmentList;
    private Stack<string> lastUsed;

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
        lastUsed = new Stack<string>();
    }
 
    public void InstantiateRandomSegment(Vector3 spawnPosition)
    {
        m_level++;
        Segment randomSeg = segments.GetRandom<Segment>();
        while (lastUsed.Contains(randomSeg.name))
        {
            randomSeg = segments.GetRandom<Segment>();
        }
        lastUsed.Push(randomSeg.name);
        if (lastUsed.Count > repeatThreshold)
        {
            lastUsed.Pop();
        }
        Segment newSeg = Instantiate(segments.GetRandom<Segment>(), spawnPosition, Quaternion.identity);
        newSeg.name = m_level.ToString();
        QueueDequeue(newSeg);
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
