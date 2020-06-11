using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uibehaviour : MonoBehaviour
{
    static public string btnName;

    public void BtnPressed(Button button)
    {
        btnName = button.name;
    }

    public string itemselected()
    {
        return btnName;
    }
}
