using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    public HairTypeDatas hairTypes;
    public ClotheTypeDatas clotheTypes;
    public PantTypeDatas pantTypes;

    [System.Serializable]
    public class HairTypeDatas
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
    public class ClotheTypeDatas
    {
        public GameObject[] clothesParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;

        public void ClotheIncrement()
        {
            currentIndex = currentIndex + 1;
            //Debug.Log(clothesParts.Length);
            if(currentIndex >= clothesParts.Length)
            {
                currentIndex = 0;
            }
        }
        public void ClotheDecrement()
        {
            currentIndex = currentIndex - 1;
            if (currentIndex <= -1)
            {
                currentIndex = clothesParts.Length - 1;
            }
        }
    }
    [System.Serializable]
    public class PantTypeDatas
    {
        public GameObject[] pantParts;
        public Button nextBTN;
        public Button prevBTN;
        public int currentIndex;

    }

}







