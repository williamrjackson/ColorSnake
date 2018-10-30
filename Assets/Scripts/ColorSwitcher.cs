using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorSwitcher : MonoBehaviour {
    public float hue;

    public UnityAction OnSnakeColorSet;
	// Use this for initialization
	void Start () {
        StartCoroutine(Flashy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMovement>())
        {
            col.GetComponent<PlayerMovement>().SetHue(hue);
            if (OnSnakeColorSet != null)
                OnSnakeColorSet();
        }
    }

    private IEnumerator Flashy()
    {
        Color appliedColor = Color.HSVToRGB(1, 1, 1);
        float h, s, v;
        while(true)
        {
            Wrj.Utils.MapToCurve.Ease.ChangeColor(transform, appliedColor, .025f);
            Color.RGBToHSV(appliedColor, out h, out s, out v);
            h += .1f;
            appliedColor = Color.HSVToRGB(h, s, v);
            yield return new WaitForSeconds(.03f);
        }

    }
}
