using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Obstacle : MonoBehaviour {
    public float hue;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        print("Obstacle Hit: " + hue);
        if (col.GetComponent<SnakeBehavior>() && col.GetComponent<SnakeBehavior>().GetHue() != hue)
        {
            print("dead");
            col.GetComponent<SnakeBehavior>().SetDead();
        }
        else
        {
            return;
        }
    }
}
