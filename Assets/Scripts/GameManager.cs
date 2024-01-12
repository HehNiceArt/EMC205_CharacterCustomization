using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CharacterCustomization charCustom;
    public GameObject kiraPrefab;
    public GameObject liamPrefab;
    public Button switchSex;

    private void Start()
    {
        HideExcessPart();

        #region Kira
        Button kiraHairNextBTN = charCustom.kiraHairTypes.nextBTN;
        kiraHairNextBTN.onClick.AddListener(NextHair);
        kiraHairNextBTN.onClick.AddListener(charCustom.kiraHairTypes.HairIncrement);

        Button kiraHairPreviousBTN = charCustom.kiraHairTypes.prevBTN;
        kiraHairPreviousBTN.onClick.AddListener(PreviousHair);
        kiraHairPreviousBTN.onClick.AddListener(charCustom.kiraHairTypes.HairDecrement);

        Button kiraClothesNextBTN = charCustom.kiraClotheTypes.nextBTN;
        kiraClothesNextBTN.onClick.AddListener(NextClothe);
        kiraClothesNextBTN.onClick.AddListener(charCustom.kiraClotheTypes.ClotheIncrement);

        Button kiraClothesPreviousBTN = charCustom.kiraClotheTypes.prevBTN;
        kiraClothesPreviousBTN.onClick.AddListener(PreviousClothe);
        kiraClothesPreviousBTN.onClick.AddListener(charCustom.kiraClotheTypes.ClotheDecrement);

        Button kiraPantNextBTN = charCustom.kiraPantTypes.nextBTN;
        kiraPantNextBTN.onClick.AddListener(NextPant);
        kiraPantNextBTN.onClick.AddListener(charCustom.kiraPantTypes.PantIncrement); ;

        Button kiraPantPreviousBTN = charCustom.kiraPantTypes.prevBTN;
        kiraPantPreviousBTN.onClick.AddListener(PreviousPant);
        kiraPantPreviousBTN.onClick.AddListener(charCustom.kiraPantTypes.PantDecrement); ;
        #endregion
    }
    #region For Inspector Only
    //Resets the visibility of the children models
    public void ResetHidden()
    {
        foreach (Transform child in kiraPrefab.transform)
        {
            child.gameObject.SetActive(true);
        }
        foreach(Transform child in liamPrefab.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void HideExcessPart()
    {
        #region Kira
        int kiraHairPartsLength = charCustom.kiraHairTypes.hairParts.Length;
        int kiraClothePartsLength = charCustom.kiraClotheTypes.clothesParts.Length;
        int kiraPantPartsLength = charCustom.kiraPantTypes.pantParts.Length;
        GameObject[] kiraHairParts = charCustom.kiraHairTypes.hairParts;
        GameObject[] kiraClotheParts = charCustom.kiraPantTypes.pantParts;
        GameObject[] kiraPantParts = charCustom.kiraPantTypes.pantParts;
        for (int i = 1; i < kiraHairPartsLength; i++)
        {
            kiraHairParts[i].SetActive(false);
        }
        for (int i = 1; i < kiraClothePartsLength; i++)
        {
            kiraClotheParts[i].SetActive(false);
        }
        for (int i = 1; i < kiraPantPartsLength; i++)
        {
            kiraPantParts[i].SetActive(false);
        }
        #endregion
        #region Liam
        int liamHairPartsLength = charCustom.liamHairTypes.hairParts.Length;
        #endregion
    }
    #endregion

    #region Customization Functions
    public void NextHair()
    {
        int index = charCustom.kiraHairTypes.currentIndex;
        //Deactivates current visible hair
        SetHairToggle(index, false);
        //move to next index
        index++;
        //Activates next hair
        SetHairToggle(index, true);
    }

    public void PreviousHair()
    {
        int index = charCustom.kiraHairTypes.currentIndex;
        SetHairToggle(index, false);
        index--;
        SetHairToggle(index, true);
    }

    public void NextClothe()
    {
        int index = charCustom.kiraClotheTypes.currentIndex;
        //SetClotheToggle(index, false);
        index++;
        SetClotheToggle(index);
    }
    public void PreviousClothe()
    {
        int index = charCustom.kiraClotheTypes.currentIndex;
        //SetClotheToggle(index);
        index--;
        SetClotheToggle(index);
    }

    public void NextPant()
    {
        int index = charCustom.kiraPantTypes.currentIndex;
        SetPantToggle(index, false);
        index++;
        SetPantToggle(index, true);
    }

    public void PreviousPant()
    {
        int index = charCustom.kiraPantTypes.currentIndex;
        SetPantToggle(index, false);
        index--;
        SetPantToggle(index, true);

    }
    #endregion

    /// <summary>
    /// Determines whether it actives or deactivates the current model 
    /// </summary>
    #region Toggles
    void SetHairToggle(int index, bool isActive)
    {
        int kiraHairLength = charCustom.kiraHairTypes.hairParts.Length;
        GameObject[] kiraHairParts = charCustom.kiraHairTypes.hairParts;

        if (index >= 0 && index < kiraHairLength)
        {
            for (int i = 0; i < kiraHairLength; i++)
                kiraHairParts[index].SetActive(isActive);
        }
        if(!isActive && (index == kiraHairLength))
        {
            kiraHairParts[0].SetActive(true);
        }
    } 
    void SetClotheToggle(int index)
    {
        int kiraClotheLength = charCustom.kiraClotheTypes.clothesParts.Length;
        GameObject[] kiraClotheParts = charCustom.kiraClotheTypes.clothesParts;
        if (index >= 0 && index < kiraClotheLength)
        {
            //Not the best condition right now but I can't find any other code that
            //functions similarly with just two models
                switch (index)
                {
                    case 0:
                        kiraClotheParts[0].SetActive(true);
                        kiraClotheParts[1].SetActive(false);
                        //Debug.Log("CASE 0");
                        break;
                    case 1:
                        kiraClotheParts[0].SetActive(false);
                        kiraClotheParts[1].SetActive(true);
                        //Debug.Log("CASE 1");
                        break;
                    default:
                        break;
                }
            #region Deprecated
            //for (int i = 0; i < charCustom.clotheTypes.clothesParts.Length; i++)
            //{
            //    //Debug.Log(index);
            //    charCustom.clotheTypes.clothesParts[index].SetActive(isActive);
            //}
            //if(!isActive && (index == charCustom.clotheTypes.clothesParts.Length))
            //{
            //    charCustom.clotheTypes.clothesParts[0].SetActive(true);
            //}
            //i don't understand this code block like wtf
            //even though i was the one who wrote it
            //if (isActive && (index == charCustom.clotheTypes.clothesParts.Length))
            //{
            //    charCustom.clotheTypes.clothesParts[0].SetActive(true);
            //}
            //if (isActive == false && (index == 1))
            //{
            //    Debug.Log("A");
            //    charCustom.clotheTypes.clothesParts[0].SetActive(true);
            //}  if (isActive == false && (index == 0))
            //{
            //    Debug.Log("Ab");
            //    charCustom.clotheTypes.clothesParts[1].SetActive(false);
            //}
            #endregion
        }
    }

    private void SetPantToggle(int index, bool isActive)
    {
        int kiraPantLength = charCustom.kiraPantTypes.pantParts.Length;
        GameObject[] kiraPantParts = charCustom.kiraPantTypes.pantParts;
        if (index >= 0 && index < kiraPantLength)
        {
            for (int i = 0; i < kiraPantLength; i++)
                kiraPantParts[index].SetActive(isActive);
        }
        if (index == 0 || (index >= kiraPantLength) || index == -1)
        {
            kiraPantParts[0].SetActive(true);
        }
        else
        {
            kiraPantParts[0].SetActive(false);
        }
    }
    #endregion
}
