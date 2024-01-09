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
        public int currentIndex;

        public int CurrentIndex
        {
            get { return currentIndex; } 
            set { currentIndex = (value + hairParts.Length) % hairParts.Length; }
        }
    }
    [System.Serializable]
    public class ClotheTypeDatas
    {
        public GameObject[] clothesParts;
        [SerializeField] private Button nextBTN;
        [SerializeField] private Button prevBTN;
        [SerializeField] private int currentIndex;
    }
    [System.Serializable]
    public class PantTypeDatas
    {
        public GameObject[] pantParts;
        [SerializeField] private Button nextBTN;
        [SerializeField] private Button prevBTN;
        [SerializeField] private int currentIndex;
    }

}







