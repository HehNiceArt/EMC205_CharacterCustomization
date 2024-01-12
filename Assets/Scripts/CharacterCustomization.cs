using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;

public class CharacterCustomization : MonoBehaviour
{
    [Header("KIRA MODEL")]
    public KiraHairTypeDatas kiraHairTypes;
    public KiraClotheTypeDatas kiraClotheTypes;
    public KiraPantTypeDatas kiraPantTypes;
    public GameObject kiraPrefab;

    [Space(10)]

    [Header("LIAM MODEL")]
    public LiamHairTypeDatas liamHairTypes;
    public LiamClotheTypeDatas liamClotheTypes;
    public LiamPantTypeDatas liamPantTypes;
    public GameObject liamPrefab;


    #region Kira
    [System.Serializable]
        public class KiraHairTypeDatas
        {
            //public so it makes it readable on HideExcessPart()
            public GameObject[] hairParts;
            public Button nextBTN;
            public Button prevBTN;
            //why is this not incrementing
            public int currentIndex = 0;
            public void HairIncrement()
            {
                currentIndex = currentIndex + 1;
                if (currentIndex > hairParts.Length) { currentIndex = 0; }
            }
            public void HairDecrement()
            {
                currentIndex = currentIndex - 1;
                if (currentIndex < 0) { currentIndex = hairParts.Length; }
            }
        }

        [System.Serializable]
        public class KiraClotheTypeDatas
        {
            public GameObject[] clothesParts;
            public Button nextBTN;
            public Button prevBTN;
            public int currentIndex;

        public GameManager gameManager;
            public void ClotheIncrement()
            {
                currentIndex = currentIndex + 1;
                //Debug.Log(clothesParts.Length);
                if (currentIndex >= clothesParts.Length) { currentIndex = 0;
                int dummyIndex = 0;
                gameManager.SetClotheToggle(currentIndex, dummyIndex, true);
            }
            }
            public void ClotheDecrement()
            {
                currentIndex = currentIndex - 1;
                if (currentIndex < 0) { currentIndex = clothesParts.Length - 1;
                int dummyIndex = 0;
                gameManager.SetClotheToggle(currentIndex, dummyIndex, true);
            }
            }
        }
        [System.Serializable]
        public class KiraPantTypeDatas
        {
            public GameObject[] pantParts;
            public Button nextBTN;
            public Button prevBTN;
            public int currentIndex;

        public GameManager gameManager;
            public void PantIncrement()
            {
                currentIndex = currentIndex + 1;
                if (currentIndex >= pantParts.Length) { currentIndex = 0;
                int dummyIndex = 0;
                gameManager.SetPantToggle(currentIndex, dummyIndex, true);
            }
            }
            public void PantDecrement()
            {
                currentIndex = currentIndex - 1;
                if (currentIndex < 0)
                { currentIndex = pantParts.Length  - 1;
                int dummyIndex = 0;
                gameManager.SetPantToggle(currentIndex, dummyIndex, true);
                }
            }
    }
    #endregion

    #region Liam
    [System.Serializable]
    public class LiamHairTypeDatas 
    {
        public GameObject[] hairParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex = 0;

        public GameManager gameManager;
        public void HairIncrement()
        {
            currentIndex = currentIndex + 1;
            if (currentIndex > hairParts.Length - 1) { currentIndex = 0; 
                int dummyIndex = 0;
                gameManager.SetHairToggle(dummyIndex, currentIndex, true);
            }
        }
        public void HairDecrement()
        {
            currentIndex -= 1;
            if(currentIndex == -1) { currentIndex = hairParts.Length;}
        }
    }
    [System.Serializable]
    public class LiamClotheTypeDatas
    {
        public GameObject[] clotheParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;

        public GameManager gameManager;
        public void ClotheIncrement()
        {
            currentIndex = currentIndex + 1;
            if(currentIndex >= clotheParts.Length) { currentIndex = 0; }
            Debug.Log("A");
        }
        public void ClotheDecrement()
        {
            currentIndex = currentIndex - 1;
            int dummyIndex = 0;
            Debug.Log("B");
            if(currentIndex <= -1) { currentIndex = clotheParts.Length - 1;
                //I forgot the logic on why I wrote this when I was writing it but it works
                //Got it now - when the currentIndex reaches -1, it will loop back to 
                //the max length of the gameobject array - 1 so it's only [0,1,2]
                //Instead of having an extra number i.e. [0,1,2,3]
                //So the solution was to run SetClotheToggle again
                gameManager.SetClotheToggle(dummyIndex, currentIndex, true);
            }
        }
    }
    [System.Serializable]
    public class LiamPantTypeDatas
    {
        public GameObject[] pantParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;

        public GameManager gameManager;
        public void PantIncrement()
        {
            currentIndex = currentIndex + 1;
            if (currentIndex >= pantParts.Length) { currentIndex = 0; }
        }
        public void PantDecrement()
        {
            currentIndex = currentIndex - 1;
            if (currentIndex < 0) { currentIndex = pantParts.Length - 1;
                int dummyIndex = 0;
                gameManager.SetPantToggle(dummyIndex, currentIndex, true);
            }
        }
    }
    #endregion
}







