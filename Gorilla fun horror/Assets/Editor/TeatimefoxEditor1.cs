using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(MonoBehaviour), true)]
public class TeatimefoxEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Type targetType = target.GetType();
        if (targetType.Namespace == "teatimefox")
        {
            EditorGUILayout.Space(10);

            GUIStyle labelStyle = new GUIStyle(EditorStyles.boldLabel);
            labelStyle.fontSize = 12;
            labelStyle.normal.textColor = Color.white;

            EditorGUILayout.BeginVertical("box");
            GUILayout.Label("Made by teatimefox", labelStyle);

            if (GUILayout.Button("Join the Discord!"))
            {
                Application.OpenURL("https://discord.gg/DWZGAqFVz6");
            }

            EditorGUILayout.EndVertical();
        }
    }
}
