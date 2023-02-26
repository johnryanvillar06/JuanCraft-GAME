using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemResourceManager;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemStruct item;

    public void setItem(ItemStruct item)
    {
        this.item = item;
        this.item.name = this.item.name.Trim() == "" ? toReadableString(this.item.name) : this.item.name;
        GetComponent<SpriteRenderer>().sprite = item.image;
    }

    public string toReadableString(String id)
    {
        return id.Replace("_", " ").ToUpper();
    }

    public ItemStruct getItem()
    {
        return item;
    }
}
