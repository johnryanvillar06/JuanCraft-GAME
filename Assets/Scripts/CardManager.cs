using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ItemResourceManager;

public class CardManager : MonoBehaviour
{
    public Text name;
    public Text descripton;
    public Text price;
    public Image picture;
    public GameObject itemViewer;

    public void view()
    {
        PickUp player = GameObject.FindGameObjectWithTag("Player").
            GetComponent<PickUp>();

        if (player.GetItemCarried() != null)
        {
            ItemStruct item = player.GetItemCarried().GetComponent<Item>().getItem();
            name.text = item.name;
            descripton.text = item.description;
            price.text = "Price: P " + item.price.ToString();
            picture.sprite = item.image;
            itemViewer.SetActive(true);
        }
    }
 
}
