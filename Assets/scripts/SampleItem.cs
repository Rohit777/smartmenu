using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleItem : MonoBehaviour
{
    public Button itembtn;
    public Button wishlistbtn;

    public Text itemName;
    public Text description;
    public Image itemImage;
    public Text itemPrice;
    public Image Artag;
    private item Item;
    private addbuttons addbuttons;
    // Start is called before the first frame update
    void Start()
    {
        wishlistbtn.onClick.AddListener(addclick);
        itembtn.onClick.AddListener(changeScene);
    }


    public void setup(item currentItem, addbuttons currentItemList)
    {
        Item = currentItem;
        itemName.text = Item.itemName;
        description.text = Item.itemDescription;
        itemPrice.text = Item.price.ToString();
        itemImage.sprite = Item.itemimage;
        if (!Item.Arsuported)
        {
            Artag.enabled = false;
        }
        addbuttons = currentItemList;
    }

    public void addclick()
    {
        addbuttons.Additem(Item);
        addbuttons.RefreshDisplay();
    }

    public void changeScene()
    {
        if (Item.Arsuported)
        {
            Debug.Log("hello");
            addbuttons.arbtnpressed();
        }     
    }
}
