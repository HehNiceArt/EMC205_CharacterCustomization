using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        if(kiraPrefab.activeInHierarchy)
        {
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
        }
        #endregion
        #region Liam
        if (liamPrefab.activeInHierarchy)
        {
            Button liamHairNextBTN = charCustom.liamHairTypes.nextBTN;
            liamHairNextBTN.onClick.AddListener(NextHair);
            liamHairNextBTN.onClick.AddListener(charCustom.liamHairTypes.HairIncrement);

            Button liamHairPreviousBTN = charCustom.liamHairTypes.prevBTN;
            liamHairPreviousBTN.onClick.AddListener(PreviousHair);
            liamHairPreviousBTN.onClick.AddListener(charCustom.liamHairTypes.HairDecrement);

            Button liamClotheNextBTN = charCustom.liamClotheTypes.nextBTN;
            liamClotheNextBTN.onClick.AddListener(NextClothe);
            liamClotheNextBTN.onClick.AddListener(charCustom.liamClotheTypes.ClotheIncrement);

            Button liamClothePreviousBTN = charCustom.liamClotheTypes.prevBTN;
            liamClothePreviousBTN.onClick.AddListener(PreviousClothe);
            liamClothePreviousBTN.onClick.AddListener(charCustom.liamClotheTypes.ClotheDecrement);

            Button liamPantNextBTN = charCustom.liamPantTypes.nextBTN;
            liamPantNextBTN.onClick.AddListener(NextPant);
            liamPantNextBTN.onClick.AddListener(charCustom.liamPantTypes.PantIncrement);

            Button liamPantPreviousBTN = charCustom.liamPantTypes.prevBTN;
            liamPantPreviousBTN.onClick.AddListener(PreviousPant);
            liamPantPreviousBTN.onClick.AddListener(charCustom.liamPantTypes.PantDecrement);
        }
        #endregion
    }
    #region For Inspector Only
    //Resets the visibility of the children models
    public void ResetHidden()
    {
        foreach (Transform child in kiraPrefab.transform) { child.gameObject.SetActive(true); }
        foreach(Transform child in liamPrefab.transform) { child.gameObject.SetActive(true); }
    }

    public void HideExcessPart()
    {
        #region Kira
        int kiraHairPartsLength = charCustom.kiraHairTypes.hairParts.Length;
        int kiraClothePartsLength = charCustom.kiraClotheTypes.clothesParts.Length;
        int kiraPantPartsLength = charCustom.kiraPantTypes.pantParts.Length;
        GameObject[] kiraHairParts = charCustom.kiraHairTypes.hairParts;
        GameObject[] kiraClotheParts = charCustom.kiraClotheTypes.clothesParts;
        GameObject[] kiraPantParts = charCustom.kiraPantTypes.pantParts;
        for (int i = 1; i < kiraHairPartsLength; i++) { kiraHairParts[i].SetActive(false); }
        for (int i = 1; i < kiraClothePartsLength; i++) { kiraClotheParts[i].SetActive(false); }
        for (int i = 1; i < kiraPantPartsLength; i++) { kiraPantParts[i].SetActive(false); }
        #endregion
        #region Liam
        int liamHairPartsLength = charCustom.liamHairTypes.hairParts.Length;
        int liamClothePartsLength = charCustom.liamClotheTypes.clotheParts.Length;
        int liamPantPartsLength = charCustom.liamPantTypes.pantParts.Length;
        GameObject[] liamHairParts = charCustom.liamHairTypes.hairParts;
        GameObject[] liamClotheParts = charCustom.liamClotheTypes.clotheParts;
        GameObject[] liamPantParts = charCustom.liamPantTypes.pantParts;
        for(int i = 0; i < liamHairPartsLength; i++) { liamHairParts[i].SetActive(false); }
        for(int i = 0;i < liamClothePartsLength; i++) { liamClotheParts[i].SetActive(false); }
        for(int i = 0; i < liamPantPartsLength; i++) { liamPantParts[i].SetActive(false); }
        #endregion
    }
    #endregion

    #region Customization Functions
    public void NextHair()
    {
        int kiraIndex = charCustom.kiraHairTypes.currentIndex;
        int liamIndex = charCustom.liamHairTypes.currentIndex;
        //Deactivates current visible hair
        SetHairToggle(kiraIndex, liamIndex, false);
        //move to next index
        kiraIndex++;
        liamIndex++;
        //Activates next hair
        SetHairToggle(kiraIndex, liamIndex, true);
    }
    public void PreviousHair()
    {
        int kiraIndex = charCustom.kiraHairTypes.currentIndex;
        int liamIndex = charCustom.kiraHairTypes.currentIndex;
        SetHairToggle(kiraIndex, liamIndex, false);
        kiraIndex--;
        liamIndex--;
        SetHairToggle(kiraIndex, liamIndex, true);
    }
    public void NextClothe()
    {
        int kiraIndex = charCustom.kiraClotheTypes.currentIndex;
        int liamIndex = charCustom.liamClotheTypes.currentIndex;
        SetClotheToggle(kiraIndex, liamIndex, false);
        //SetClotheToggle(index, false);
        kiraIndex++;
        liamIndex++;
        SetClotheToggle(kiraIndex, liamIndex, true);
    }
    public void PreviousClothe()
    {
        int kiraIndex = charCustom.kiraClotheTypes.currentIndex;
        int liamIndex = charCustom.liamClotheTypes.currentIndex;
        SetClotheToggle(kiraIndex, liamIndex, false);
        //SetClotheToggle(index);
        kiraIndex--;
        liamIndex--;
        SetClotheToggle(kiraIndex, liamIndex, true);
    }
    public void NextPant()
    {
        int kiraIndex = charCustom.kiraPantTypes.currentIndex;
        int liamIndex = charCustom.liamPantTypes.currentIndex;
        SetPantToggle(kiraIndex, liamIndex, false);
        kiraIndex++;
        liamIndex++ ;   
        SetPantToggle(kiraIndex, liamIndex, true);
    }
    public void PreviousPant()
    {
        int kiraIndex = charCustom.kiraPantTypes.currentIndex;
        int liamIndex = charCustom.liamPantTypes.currentIndex;
        SetPantToggle(kiraIndex,liamIndex, false);
        kiraIndex--;
        liamIndex-- ;
        SetPantToggle(kiraIndex, liamIndex, true);

    }
    #endregion

    /// <summary>
    /// Determines whether it actives or deactivates the current model 
    /// </summary>
    #region Toggles
    public void SetHairToggle(int kiraIndex, int liamIndex, bool isActive)
    {
        int kiraHairLength = charCustom.kiraHairTypes.hairParts.Length;
        GameObject[] kiraHairParts = charCustom.kiraHairTypes.hairParts;

        int liamHairLength = charCustom.liamHairTypes.hairParts.Length;
        GameObject[] liamHairParts = charCustom.liamHairTypes.hairParts;

            if (kiraIndex >= 0 && kiraIndex < kiraHairLength)
            {
                for (int i = 0; i <= kiraHairLength; i++)
                    kiraHairParts[kiraIndex].SetActive(isActive);
            }
            if ((kiraIndex == kiraHairLength) || kiraIndex == 0) { kiraHairParts[0].SetActive(true); }
            else { kiraHairParts[0].SetActive(false); }

            //Debug.Log("TOGGLE: " + liamIndex);
            if (liamIndex >= 0 && liamIndex < liamHairLength)
            {
                for (int i = 0; i < liamHairLength; i++)
                    liamHairParts[liamIndex].SetActive(isActive);
            }
            if (!isActive && (liamIndex == liamHairLength)) { liamHairParts[0].SetActive(true); }
    } 
    public void SetClotheToggle(int kiraIndex, int liamIndex, bool isActive)
    {
        int kiraClotheLength = charCustom.kiraClotheTypes.clothesParts.Length;
        GameObject[] kiraClotheParts = charCustom.kiraClotheTypes.clothesParts;

        int liamClotheLength = charCustom.liamClotheTypes.clotheParts.Length;
        GameObject[] liamClotheParts = charCustom.liamClotheTypes.clotheParts;

            if (kiraIndex >= 0 && kiraIndex < kiraClotheLength)
            {
                for (int i = 0; i < kiraClotheLength; i++)
                    kiraClotheParts[kiraIndex].SetActive(isActive);
                if(!isActive && (kiraIndex == kiraClotheLength)) { kiraClotheParts[0].SetActive(true);}
            #region Deprecated  
            //Not the best condition right now but I can't find any other code that
            //functions similarly with just two models
            //switch (kiraIndex)
            //{
            //    case 0:
            //        kiraClotheParts[0].SetActive(true);
            //        kiraClotheParts[1].SetActive(false);
            //        //Debug.Log("CASE 0");
            //        break;
            //    case 1:
            //        kiraClotheParts[0].SetActive(false);
            //        kiraClotheParts[1].SetActive(true);
            //        //Debug.Log("CASE 1");
            //        break;
            //    default:
            //        break;
            //}
            #endregion
            }

            if (liamIndex >= 0 && liamIndex < liamClotheLength)
            {
                for (int i = 0; i < liamClotheLength; i++)
                    liamClotheParts[liamIndex].SetActive(isActive);
                if (!isActive && (liamIndex == liamClotheLength)) { liamClotheParts[0].SetActive(true); }
            }
    }
/// <summary>
/// Teehee
/// Idk anymore why I have this summary
/// </summary>
    public void SetPantToggle(int kiraIndex, int liamIndex, bool isActive)
    {
        int kiraPantLength = charCustom.kiraPantTypes.pantParts.Length;
        GameObject[] kiraPantParts = charCustom.kiraPantTypes.pantParts;

        int liamPantLength = charCustom.liamPantTypes.pantParts.Length;
        GameObject[] liamPantParts = charCustom.liamPantTypes.pantParts;

            if (kiraIndex >= 0 && kiraIndex < kiraPantLength)
            {
                for (int i = 0; i < kiraPantLength; i++)
                    kiraPantParts[kiraIndex].SetActive(isActive);
            }
            if (kiraIndex == 0) { kiraPantParts[0].SetActive(true); }
            else { kiraPantParts[0].SetActive(false); }

            //Debug.Log("wtf god save me why won't this shit decrement mtfkr");
            if(liamIndex >= 0 && liamIndex < liamPantLength)
            {
                for (int i = 0; i < liamPantLength; i++)
                    liamPantParts[liamIndex].SetActive(isActive);
            }
            if(!isActive && (liamIndex == liamPantLength)) { liamPantParts[0].SetActive(true); }
    }
    #endregion
}
