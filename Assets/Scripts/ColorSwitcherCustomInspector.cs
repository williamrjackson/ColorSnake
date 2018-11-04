using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ColorSwitcher))]
[ExecuteInEditMode]

public class ColorSwitcherCustomInspector : Editor {
    private Material instancedMaterial;
    private ColorSwitcher targetSwitcher;

    public void Awake()
    {
        targetSwitcher = (ColorSwitcher)target;
        instancedMaterial = new Material(targetSwitcher.GetComponent<SpriteRenderer>().sharedMaterial);
        targetSwitcher.GetComponent<SpriteRenderer>().sharedMaterial = instancedMaterial;

    }
    public override void OnInspectorGUI()
    {
        if (Application.isPlaying)
            return;
        if (targetSwitcher == null)
            Awake();

        targetSwitcher.hue = EditorGUILayout.Slider(targetSwitcher.hue, 0, 1);
        Color resultColor = Color.HSVToRGB(targetSwitcher.hue, 1, 1);
        EditorGUILayout.ColorField(resultColor);
        targetSwitcher.GetComponent<SpriteRenderer>().sharedMaterial.SetColor("_Color", resultColor);
        Undo.RecordObject(targetSwitcher, targetSwitcher.name + " Hue Modified");
    }
}
