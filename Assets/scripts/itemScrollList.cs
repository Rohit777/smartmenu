using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class item
{
    public string itemName;
    public bool Arsuported;
    public string itemDescription;
    public int price;
    public int count = 1;
    public Sprite itemimage;
}

[System.Serializable]
public class ListWrapper
{
    public string categoryName;
    public List<item> itemlist;
}


public class itemScrollList : MonoBehaviour
{
    public int bill;
    public List<ListWrapper> Itemlist = new List<ListWrapper>();
    public List<item> wishlist;
    public GameObject tutroial;
    public GameObject restrunt;

    private void Start()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            Debug.Log("First Time Opening");

            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

            //Do your stuff here
            tutroial.SetActive(true);
        }
        else
        {
            Debug.Log("NOT First Time Opening");

            //Do your stuff here
            restrunt.SetActive(true);
        }
    }
}
