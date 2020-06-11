using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class wishlistaddbtn : MonoBehaviour
{
    itemScrollList ItemScrollList;
    public GameObject itemlistdata;
    public Transform contentPanel;
    public Text TotalBill;
    public GameObject prefab;
    public SimpleObjectPool buttonObjectPool;
    public GameObject Arview;
    public GameObject menuItem;

    private void Start()
    {
        ItemScrollList = itemlistdata.GetComponent<itemScrollList>();
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        RemoveButtons();
        addwishlistbtn();
        Resetvalue();
        calculateBill();
    }

    private void RemoveButtons()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    public void arbtnpressed()
    {
        menuItem.SetActive(false);
        Arview.SetActive(true);
    }

    public void addwishlistbtn()
    {
        for (int i = 0; i < ItemScrollList.wishlist.Count; i++)
        {
            item Item = ItemScrollList.wishlist[i];
            GameObject newwishButton = buttonObjectPool.GetObject(prefab);
            newwishButton.transform.SetParent(contentPanel, false);
            wishlistSampleBtn wishlistSampleBtn = newwishButton.GetComponent<wishlistSampleBtn>();
            wishlistSampleBtn.setup(Item, this);
        }
    }

    public void RemoveItem(item itemToremove)
    {
        ItemScrollList.wishlist.Remove(itemToremove);
    }

    public void Resetvalue()
    {
        ItemScrollList.bill = 0;
    }
    public void calculateBill()
    {
        for(int i = 0; i< ItemScrollList.wishlist.Count; i++)
        {
            ItemScrollList.bill = ItemScrollList.bill + ItemScrollList.wishlist[i].price * ItemScrollList.wishlist[i].count;
            TotalBill.text = ItemScrollList.bill.ToString();
        }
    }

    public void plus(item itemcount)
    {
        int count = 0;
        count++;
        itemcount.count = itemcount.count + count;
        ItemScrollList.bill = ItemScrollList.bill + count * itemcount.price;
        TotalBill.text = ItemScrollList.bill.ToString();
    }

    public void minus(item itemcount)
    {
        if(itemcount.count > 0)
        {
            int count = 0;
            count++;
            itemcount.count = itemcount.count - count;
            ItemScrollList.bill = ItemScrollList.bill - count * itemcount.price;
            TotalBill.text = ItemScrollList.bill.ToString();
        }
        
    }
}
