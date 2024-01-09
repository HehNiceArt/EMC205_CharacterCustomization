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

        if (GUILayout.Button("NEXT HAIR STYLE"))
        {
            gameManager.NextHair();
        }
        if (GUILayout.Button("PREVIOUS HAIR STYLE"))
        {
            gameManager.PreviousButton();
        }
        GUILayout.Space(5);
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
