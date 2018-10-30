using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ColorSwitcher))]
[ExecuteInEditMode]

public class ColorSwitcherCustomInspector : Editor {
    public override void OnInspectorGUI()
    {
        if (Application.isPlaying)
            return;

        ColorSwitcher targetSwitcher = (ColorSwitcher)target;

        targetSwitcher.hue = EditorGUILayout.Slider(targetSwitcher.hue, 0, 1);
        Color resultColor = Color.HSVToRGB(targetSwitcher.hue, 1, 1);
        EditorGUILayout.ColorField(resultColor);
        targetSwitcher.GetComponent<SpriteRenderer>().sharedMaterial.SetColor("_Color", resultColor);

        EditorUtility.SetDirty(targetSwitcher);
    }
}
