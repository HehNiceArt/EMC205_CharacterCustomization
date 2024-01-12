using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GameManager)), CanEditMultipleObjects]
public class CharacterCustomizationManager : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GameManager gameManager = (GameManager)target;

        GUILayout.Space(15);
        if (GUILayout.Button("RESET HIDDEN GAMEOBJECTS"))
        {
            gameManager.ResetHidden();
        }
        
        if (GUILayout.Button("HIDE GAMEOBJECTS"))
        {
            gameManager.HideExcessPart();
        }
    }

}
