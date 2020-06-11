using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addbuttons : MonoBehaviour
{
    Uibehaviour uibehaviour;
    public string scrolltype;
    itemScrollList ItemScrollList;
    public GameObject itemlistdata;
    public Transform contentPanel;
    public Text heading;
    public GameObject menuItem;
    public GameObject Arview;
    public GameObject prefab;
    public SimpleObjectPool buttonObjectPool;
    int currentprice;
    int categoryIndex;
    // Start is called before the first frame update
    void Start()
    {
        ItemScrollList = itemlistdata.GetComponent<itemScrollList>();
        uibehaviour = itemlistdata.GetComponent<Uibehaviour>();
        RefreshDisplay();
        
    }

    public void RefreshDisplay()
    {
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }
    private void AddButtons()
    {
        for (int i = 0; i < ItemScrollList.Itemlist.Count; i++)
        {
            if (ItemScrollList.Itemlist[i].categoryName == uibehaviour.itemselected())
            {
                categoryIndex = i;
                heading.text = ItemScrollList.Itemlist[i].categoryName;
                for (int j = 0; j < ItemScrollList.Itemlist[i].itemlist.Count; j++)
                {
                    item Item = ItemScrollList.Itemlist[i].itemlist[j];
                    GameObject newButton = buttonObjectPool.GetObject(prefab);
                    if (scrolltype == "vertical")
                    {
                       
                        newButton.transform.SetParent(contentPanel, false);
                        SampleItem sampleItem = newButton.GetComponent<SampleItem>();
                        sampleItem.setup(Item, this);
                    }
                    else if(scrolltype == "horizontal" && ItemScrollList.Itemlist[i].itemlist[j].Arsuported)
                    {
                        newButton.transform.SetParent(contentPanel, false);
                        horizontalSampleBtns HorizontalSampleBtns = newButton.GetComponent<horizontalSampleBtns>();
                        HorizontalSampleBtns.setup(Item, this);
                    }
                }
            }


        }
    }

    public void arbtnpressed()
    {
        menuItem.SetActive(false);
        Arview.SetActive(true);
    }

    public void Additem(item itemToAdd)
    {

        for (int item = 0; item < ItemScrollList.wishlist.Count; item++)
        {
            if (ItemScrollList.wishlist[item].itemName == itemToAdd.itemName)
            {
                itemToAdd.count++;
                return;
            }
        }
        ItemScrollList.wishlist.Add(itemToAdd);
    }

}
