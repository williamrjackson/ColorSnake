using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Obstacle))]
[ExecuteInEditMode]

public class ObstacleCustomInspector : Editor {
    public override void OnInspectorGUI()
    {
        if (Application.isPlaying)
            return;

        Obstacle targetObst = (Obstacle)target;

        targetObst.hue = EditorGUILayout.Slider(targetObst.hue, -.001f, 1f);
        Color resultColor = Color.white;
        if (targetObst.hue >= 0)
        {
            resultColor = Color.HSVToRGB(targetObst.hue, 1, 1);
        }
        EditorGUILayout.ColorField(resultColor);
        targetObst.GetComponent<SpriteRenderer>().color = resultColor;
        Undo.RecordObject(targetObst, targetObst.name + "Hue Modified");
    }
}
