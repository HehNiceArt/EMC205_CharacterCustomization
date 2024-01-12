using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CharacterCustomization : MonoBehaviour
{
    [Header("KIRA MODEL")]
    public KiraHairTypeDatas kiraHairTypes;
    public KiraClotheTypeDatas kiraClotheTypes;
    public KiraPantTypeDatas kiraPantTypes;

    [Space(10)]

    [Header("LIAM MODEL")]
    public LiamHairTypeDatas liamHairTypes;
    public LiamClotheTypeDatas liamClotheTypes;
    public LiamPantTypeDatas liamPantTypes;

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
                if (currentIndex > hairParts.Length)
                {
                    currentIndex = 0;
                }
            }
            public void HairDecrement()
            {
                currentIndex = currentIndex - 1;
                if (currentIndex <= -1)
                {
                    currentIndex = hairParts.Length;
                }
            }
        }

        [System.Serializable]
        public class KiraClotheTypeDatas
        {
            public GameObject[] clothesParts;
            public Button nextBTN;
            public Button prevBTN;
            public int currentIndex;

            public void ClotheIncrement()
            {
                currentIndex = currentIndex + 1;
                //Debug.Log(clothesParts.Length);
                if (currentIndex >= clothesParts.Length)
                {
                    currentIndex = 0;
                }
            }
            public void ClotheDecrement()
            {
                currentIndex = currentIndex - 1;
                if (currentIndex <= -1)
                {
                    currentIndex = clothesParts.Length;
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

            public void PantIncrement()
            {
                currentIndex = currentIndex + 1;
                if (currentIndex >= pantParts.Length)
                {
                    currentIndex = 0;
                }
            }
            public void PantDecrement()
            {
                currentIndex = currentIndex - 1;
                if (currentIndex <= -1)
                {
                    currentIndex = pantParts.Length;
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
        public int currentIndex;
    }
    [System.Serializable]
    public class LiamClotheTypeDatas
    {
        public GameObject[] clotheParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;
    }
    [System.Serializable]
    public class LiamPantTypeDatas
    {
        public GameObject[] pantParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;
    }
    #endregion
}







