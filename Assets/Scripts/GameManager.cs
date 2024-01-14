using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public KiraCharacterCustomization kiracustom;
    public LiamCharacterCustomization liamcustom;
    public GameObject kiraPrefab;
    public GameObject liamPrefab;
    public Button switchSex;

    private void Start()
    {
        HideExcessPart();
        Button changeSex = switchSex;
        changeSex.onClick.AddListener(SwitchSex);
        Initialize();
    }
    void SwapModel()
    {

    }
    private void Initialize()
    {
        #region Kira
        if (kiraPrefab.activeInHierarchy)
        {
            Button kiraHairNextBTN = kiracustom.kiraHairTypes.nextBTN;
            kiraHairNextBTN.onClick.AddListener(NextHair);
            kiraHairNextBTN.onClick.AddListener(kiracustom.kiraHairTypes.HairIncrement);

            Button kiraHairPreviousBTN = kiracustom.kiraHairTypes.prevBTN;
            kiraHairPreviousBTN.onClick.AddListener(PreviousHair);
            kiraHairPreviousBTN.onClick.AddListener(kiracustom.kiraHairTypes.HairDecrement);

            Button kiraClothesNextBTN = kiracustom.kiraClotheTypes.nextBTN;
            kiraClothesNextBTN.onClick.AddListener(NextClothe);
            kiraClothesNextBTN.onClick.AddListener(kiracustom.kiraClotheTypes.ClotheIncrement);

            Button kiraClothesPreviousBTN = kiracustom.kiraClotheTypes.prevBTN;
            kiraClothesPreviousBTN.onClick.AddListener(PreviousClothe);
            kiraClothesPreviousBTN.onClick.AddListener(kiracustom.kiraClotheTypes.ClotheDecrement);

            Button kiraPantNextBTN = kiracustom.kiraPantTypes.nextBTN;
            kiraPantNextBTN.onClick.AddListener(NextPant);
            kiraPantNextBTN.onClick.AddListener(kiracustom.kiraPantTypes.PantIncrement); ;

            Button kiraPantPreviousBTN = kiracustom.kiraPantTypes.prevBTN;
            kiraPantPreviousBTN.onClick.AddListener(PreviousPant);
            kiraPantPreviousBTN.onClick.AddListener(kiracustom.kiraPantTypes.PantDecrement); ;
        }
        #endregion
        #region Liam
        if (liamPrefab.activeInHierarchy)
        {
            Button liamHairNextBTN = liamcustom.liamHairTypes.nextBTN;
            liamHairNextBTN.onClick.AddListener(NextHair);
            liamHairNextBTN.onClick.AddListener(liamcustom.liamHairTypes.HairIncrement);

            Button liamHairPreviousBTN = liamcustom.liamHairTypes.prevBTN;
            liamHairPreviousBTN.onClick.AddListener(PreviousHair);
            liamHairPreviousBTN.onClick.AddListener(liamcustom.liamHairTypes.HairDecrement);

            Button liamClotheNextBTN = liamcustom.liamClotheTypes.nextBTN;
            liamClotheNextBTN.onClick.AddListener(NextClothe);
            liamClotheNextBTN.onClick.AddListener(liamcustom.liamClotheTypes.ClotheIncrement);

            Button liamClothePreviousBTN = liamcustom.liamClotheTypes.prevBTN;
            liamClothePreviousBTN.onClick.AddListener(PreviousClothe);
            liamClothePreviousBTN.onClick.AddListener(liamcustom.liamClotheTypes.ClotheDecrement);

            Button liamPantNextBTN = liamcustom.liamPantTypes.nextBTN;
            liamPantNextBTN.onClick.AddListener(NextPant);
            liamPantNextBTN.onClick.AddListener(liamcustom.liamPantTypes.PantIncrement);

            Button liamPantPreviousBTN = liamcustom.liamPantTypes.prevBTN;
            liamPantPreviousBTN.onClick.AddListener(PreviousPant);
            liamPantPreviousBTN.onClick.AddListener(liamcustom.liamPantTypes.PantDecrement);
        }
        #endregion
        
    }
    bool isGameObjectActive = true;
    public void SwitchSex()
    {
        isGameObjectActive = !isGameObjectActive;
        SetActiveObject();
    }
    void SetActiveObject()
    {
        kiraPrefab.SetActive(isGameObjectActive);
        liamPrefab.SetActive(!isGameObjectActive);
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
        int kiraHairPartsLength = kiracustom.kiraHairTypes.hairParts.Length;
        int kiraClothePartsLength = kiracustom.kiraClotheTypes.clothesParts.Length;
        int kiraPantPartsLength = kiracustom.kiraPantTypes.pantParts.Length;
        GameObject[] kiraHairParts = kiracustom.kiraHairTypes.hairParts;
        GameObject[] kiraClotheParts = kiracustom.kiraClotheTypes.clothesParts;
        GameObject[] kiraPantParts = kiracustom.kiraPantTypes.pantParts;
        for (int i = 1; i < kiraHairPartsLength; i++) { kiraHairParts[i].SetActive(false); }
        for (int i = 1; i < kiraClothePartsLength; i++) { kiraClotheParts[i].SetActive(false); }
        for (int i = 1; i < kiraPantPartsLength; i++) { kiraPantParts[i].SetActive(false); }
        #endregion
        #region Liam
        int liamHairPartsLength = liamcustom.liamHairTypes.hairParts.Length;
        int liamClothePartsLength = liamcustom.liamClotheTypes.clotheParts.Length;
        int liamPantPartsLength = liamcustom.liamPantTypes.pantParts.Length;
        GameObject[] liamHairParts = liamcustom.liamHairTypes.hairParts;
        GameObject[] liamClotheParts = liamcustom.liamClotheTypes.clotheParts;
        GameObject[] liamPantParts = liamcustom.liamPantTypes.pantParts;
        for(int i = 0; i < liamHairPartsLength; i++) { liamHairParts[i].SetActive(false); }
        for(int i = 0;i < liamClothePartsLength; i++) { liamClotheParts[i].SetActive(false); }
        for(int i = 0; i < liamPantPartsLength; i++) { liamPantParts[i].SetActive(false); }
        #endregion
    }
    #endregion

    #region Customization Functions
    public void NextHair()
    {
        int kiraIndex = kiracustom.kiraHairTypes.currentIndex;
        int liamIndex = liamcustom.liamHairTypes.currentIndex;
        //Deactivates current visible hair
        SetHairToggle(kiraIndex, false);
        SetLiamHairToggle(liamIndex, false);
        //move to next index
        kiraIndex++;
        liamIndex++;
        //Activates next hair
        SetHairToggle(kiraIndex, true);
        SetLiamHairToggle(liamIndex, true);
    }
    public void PreviousHair()
    {
        int kiraIndex = kiracustom.kiraHairTypes.currentIndex;
        int liamIndex = liamcustom.liamHairTypes.currentIndex;
        SetHairToggle(kiraIndex, false);
        SetHairToggle(liamIndex, false);
        kiraIndex--;
        liamIndex--;
        SetHairToggle(kiraIndex, true);
        SetHairToggle(liamIndex, true);
    }
    public void NextClothe()
    {
        int kiraIndex = kiracustom.kiraClotheTypes.currentIndex;
        int liamIndex = liamcustom.liamClotheTypes.currentIndex;
        SetClotheToggle(kiraIndex, liamIndex, false);
        //SetClotheToggle(index, false);
        kiraIndex++;
        liamIndex++;
        SetClotheToggle(kiraIndex, liamIndex, true);
    }
    public void PreviousClothe()
    {
        int kiraIndex = kiracustom.kiraClotheTypes.currentIndex;
        int liamIndex = liamcustom.liamClotheTypes.currentIndex;
        SetClotheToggle(kiraIndex, liamIndex, false);
        //SetClotheToggle(index);
        kiraIndex--;
        liamIndex--;
        SetClotheToggle(kiraIndex, liamIndex, true);
    }
    public void NextPant()
    {
        int kiraIndex = kiracustom.kiraPantTypes.currentIndex;
        int liamIndex = liamcustom.liamPantTypes.currentIndex;
        SetPantToggle(kiraIndex, liamIndex, false);
        kiraIndex++;
        liamIndex++ ;   
        SetPantToggle(kiraIndex, liamIndex, true);
    }
    public void PreviousPant()
    {
        int kiraIndex = kiracustom.kiraPantTypes.currentIndex;
        int liamIndex = liamcustom.liamPantTypes.currentIndex;
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
    public void SetHairToggle(int kiraIndex, bool isActive)
    {
        int kiraHairLength = kiracustom.kiraHairTypes.hairParts.Length;
        GameObject[] kiraHairParts = kiracustom.kiraHairTypes.hairParts;
            if (kiraIndex >= 0 && kiraIndex < kiraHairLength)
            {
                for (int i = 0; i <= kiraHairLength; i++)
                    kiraHairParts[kiraIndex].SetActive(isActive);
            }
            if (!isActive && (kiraIndex == kiraHairLength)) { kiraHairParts[0].SetActive(true); }
           
    } 
    public void SetLiamHairToggle(int liamIndex, bool isActive)
    {
        int liamHairLength = liamcustom.liamHairTypes.hairParts.Length;
        GameObject[] liamHairParts = liamcustom.liamHairTypes.hairParts;

        if (liamIndex >= 0 && liamIndex < liamHairLength)
        {
            for (int i = 0; i <= liamHairLength; i++)
                liamHairParts[liamIndex].SetActive(isActive);
        }
        if (!isActive && (liamIndex == liamHairLength)) { liamHairParts[0].SetActive(true); }
    }
    public void SetClotheToggle(int kiraIndex, int liamIndex, bool isActive)
    {
        int kiraClotheLength = kiracustom.kiraClotheTypes.clothesParts.Length;
        GameObject[] kiraClotheParts = kiracustom.kiraClotheTypes.clothesParts;

        int liamClotheLength = liamcustom.liamClotheTypes.clotheParts.Length;
        GameObject[] liamClotheParts = liamcustom.liamClotheTypes.clotheParts;

            if (kiraIndex >= 0 && kiraIndex < kiraClotheLength)
            {
                for (int i = 0; i < kiraClotheLength; i++)
                    kiraClotheParts[kiraIndex].SetActive(isActive);
                if(!isActive && (kiraIndex == kiraClotheLength)) { kiraClotheParts[0].SetActive(true);}
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
        int kiraPantLength = kiracustom.kiraPantTypes.pantParts.Length;
        GameObject[] kiraPantParts = kiracustom.kiraPantTypes.pantParts;

        int liamPantLength = liamcustom.liamPantTypes.pantParts.Length;
        GameObject[] liamPantParts = liamcustom.liamPantTypes.pantParts;

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
