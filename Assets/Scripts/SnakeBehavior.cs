using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeBehavior : MonoBehaviour
{ 
    public float speed = 5;
    public float touchSensitivity = 1;
    private TouchAxisCtrl m_Touch;
    [SerializeField]
    private TrailRenderer m_Trail;
    private bool m_bAlive = true;

    private float m_Hue = 0f;
    void Start()
    {
        m_Touch = FindObjectOfType<TouchAxisCtrl>();
        m_Touch.OnTouch += OnTouch;
    }

    private void OnTouch()
    {
        if (!m_bAlive)
        {
            SceneManager.LoadScene(0); //TEMP
        }
    }
    public void SetDead()
    {
        m_bAlive = false;
    }
    void Update()
    {
        if (m_bAlive)
        {
            Vector3 pos = transform.position;
            pos.y = pos.y + speed * Time.deltaTime;
            pos.x = pos.x + m_Touch.GetAxis().x * touchSensitivity * Time.deltaTime;
            transform.position = pos;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("Hit");
    }

    public void SetHue(float _hue)
    {
        m_Hue = _hue;
        print("New Hue: " + m_Hue);
        Color color = Color.HSVToRGB(m_Hue, 1, 1);
        Wrj.Utils.MapToCurve.Ease.ChangeColor(transform, color, .25f);
        Wrj.Utils.MapToCurve.Ease.ChangeColor(m_Trail.transform, color, .25f);
    }
    public float GetHue()
    {
        return m_Hue;
    }
}
