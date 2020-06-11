using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class horizontalSampleBtns : MonoBehaviour
{
    public Button itembtn;

    public Text itemName;
    public Text description;
    public Image itemImage;
    public Text itemPrice;
   
    private item Item;
    private addbuttons addbuttons;

    public void setup(item currentItem, addbuttons currentItemList)
    {
        Item = currentItem;
        itemName.text = Item.itemName;
        description.text = Item.itemDescription;
        itemPrice.text = Item.price.ToString();
        itemImage.sprite = Item.itemimage;

        addbuttons = currentItemList;
    }
}
