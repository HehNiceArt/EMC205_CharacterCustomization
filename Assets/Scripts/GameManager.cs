using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterCustomization charCustom;
    public GameObject modelPrefabs;

    private void Start()
    {
        HideExcessPart();
        charCustom.hairTypes.nextBTN.onClick.AddListener(NextHair);
        charCustom.hairTypes.nextBTN.onClick.AddListener(charCustom.hairTypes.HairIncrement);

        charCustom.hairTypes.prevBTN.onClick.AddListener(PreviousHair);
        charCustom.hairTypes.prevBTN.onClick.AddListener(charCustom.hairTypes.HairDecrement);

        charCustom.clotheTypes.nextBTN.onClick.AddListener(NextClothe);
        charCustom.clotheTypes.nextBTN.onClick.AddListener(charCustom.clotheTypes.ClotheIncrement);

        charCustom.clotheTypes.prevBTN.onClick.AddListener(PreviousClothe);
        charCustom.clotheTypes.prevBTN.onClick.AddListener(charCustom.clotheTypes.ClotheDecrement);

    }
    #region For Inspector Only
    //Resets the visibility of the children models
    public void ResetHidden()
    {
        foreach (Transform child in modelPrefabs.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void HideExcessPart()
    {
        for (int i = 1; i < charCustom.hairTypes.hairParts.Length; i++)
        {
            charCustom.hairTypes.hairParts[i].SetActive(false);
        }
        for (int i = 1; i < charCustom.clotheTypes.clothesParts.Length; i++)
        {
            charCustom.clotheTypes.clothesParts[i].SetActive(false);
        }
        for (int i = 1; i < charCustom.pantTypes.pantParts.Length; i++)
        {
            charCustom.pantTypes.pantParts[i].SetActive(false);
        }
    }
    #endregion

    #region Customization Functions
    public void NextHair()
    {
        int index = charCustom.hairTypes.currentIndex;
        //Deactivates current visible hair
        SetHairToggle(index, false);
        //move to next index
        index++;
        //Activates next hair
        SetHairToggle(index, true);
    }

    public void PreviousHair()
    {
        int index = charCustom.hairTypes.currentIndex;
        SetHairToggle(index, false);
        index--;
        SetHairToggle(index, true);
    }

    public void NextClothe()
    {
        int index = charCustom.clotheTypes.currentIndex;
        SetClotheToggle(index, false);
        index++;
        SetClotheToggle(index, true);
    }
    public void PreviousClothe()
    {
        int index = charCustom.clotheTypes.currentIndex;
        SetClotheToggle(index, false);
        index--;
        SetClotheToggle(index, true);
    }
    #endregion
    /// <summary>
    /// Determines whether it actives or deactivates the current model 
    /// </summary>
    void SetHairToggle(int index, bool isActive)
    {
        if (index >= 0 && index < charCustom.hairTypes.hairParts.Length)
        {
            for (int i = 0; i < charCustom.hairTypes.hairParts.Length; i++)
                charCustom.hairTypes.hairParts[index].SetActive(isActive);
        }
        if(!isActive && (index == charCustom.hairTypes.hairParts.Length))
        {
            charCustom.hairTypes.hairParts[0].SetActive(true);
        }
    } 
    void SetClotheToggle(int index, bool isActive)
    {
        if (index >= 0 && index < charCustom.clotheTypes.clothesParts.Length)
        {
            for (int i = 0; i < charCustom.clotheTypes.clothesParts.Length; i++)
            {
                //Debug.Log(index);
                charCustom.clotheTypes.clothesParts[index].SetActive(isActive);
            }
            if(!isActive && (index == charCustom.clotheTypes.clothesParts.Length))
            {
                charCustom.clotheTypes.clothesParts[0].SetActive(true);
            }
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
        }
    }
}
