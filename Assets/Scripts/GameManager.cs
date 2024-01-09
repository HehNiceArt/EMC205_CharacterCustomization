using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterCustomization charCustom;
    public GameObject modelPrefabs;

    private void Start()
    {
        HideExcessPart();
        charCustom.hairTypes.nextBTN.onClick.AddListener(NextHair);
        charCustom.hairTypes.prevBTN.onClick.AddListener(PreviousButton);
    }
    public void PreviousButton()
    {
        Debug.Log("PREVIOUS");
    }
    //Resets the visibility of the children models
    public void ResetHidden()
    {
        foreach(Transform child in modelPrefabs.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void HideExcessPart()
    {
        for(int i = 1; i < charCustom.hairTypes.hairParts.Length; i++)
        {
            charCustom.hairTypes.hairParts[i].SetActive(false);
        }
        for(int i = 1; i < charCustom.clotheTypes.clothesParts.Length; i++)
        {
            charCustom.hairTypes.hairParts[i].SetActive(false) ;
        }
        for(int i = 1; i < charCustom.pantTypes.pantParts.Length; i++)
        {
            charCustom.pantTypes.pantParts[i].SetActive(false) ;
        }
    }
    public void NextHair()
    {
        int index = charCustom.hairTypes.CurrentIndex;
        //Deactivates current visible hair
        SetActiveModel(index, false);
        //move to next index
        //index = (index + 1) % charCustom.hairTypes.hairParts.Length;
        index++;
         print(index);
        //Actiavets next hair
        SetActiveModel(index, true);
    }
    //Determines whether it actives or deactivates the current model
    void SetActiveModel(int index, bool isActive)
    {
            if (index >= 0 && index < charCustom.hairTypes.hairParts.Length)
            {
                for(int i = 0; i < charCustom.hairTypes.hairParts.Length; i++)
                charCustom.hairTypes.hairParts[index].SetActive(isActive);
            }
    }
}
