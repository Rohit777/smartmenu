using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wishlistSampleBtn : MonoBehaviour
{
    public Button itembtn;
    public Button deletebtn;
    public Text itemcount;
    public Button plus;
    public Button minus;
    public Text itemName;
    public Text description;
    public Image itemImage;
    public Text itemPrice;
    public Image Artag;
    private item Item;
    private wishlistaddbtn Wishlistaddbtns;
    // Start is called before the first frame update
    void Start()
    {
        deletebtn.onClick.AddListener(addClick);
        plus.onClick.AddListener(increse);
        minus.onClick.AddListener(decrease);
        itembtn.onClick.AddListener(changeScene);
    }


    public void setup(item currentItem, wishlistaddbtn currentItemList)
    {
        Item = currentItem;
        itemcount.text = Item.count.ToString();
        itemName.text = Item.itemName;
        description.text = Item.itemDescription;
        itemPrice.text = Item.price.ToString();
        itemImage.sprite = Item.itemimage;
        if (!Item.Arsuported)
        {
            Artag.enabled = false;
        }

        Wishlistaddbtns = currentItemList;
    }

    public void addClick()
    {
        Wishlistaddbtns.RemoveItem(Item);
        Wishlistaddbtns.RefreshDisplay();
    }

    public void increse()
    {
        Wishlistaddbtns.plus(Item);
        itemcount.text = Item.count.ToString();
    }

    public void decrease()
    {
        Wishlistaddbtns.minus(Item);
        itemcount.text = Item.count.ToString();
    }

    public void changeScene()
    {
        if (Item.Arsuported)
        {
            Wishlistaddbtns.arbtnpressed();
        }
    }

}
