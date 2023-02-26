using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemResourceManager;
using System.Linq;
using System;

public class CraftingBoard : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject craftingPoint;
    public GameObject craftedPrefab;

    public List<TableSlot> slots;

    public GameObject clipvid;



    private List<Item> itemsToMerge = new List<Item>();
    private TableSlot craftingSlot;

    void Start()
    {
        foreach (TableSlot slot in slots)
        {
            slot.onPlaced += onPlace;
            slot.onRemove += onRemove;
        }
        craftingSlot = craftingPoint.GetComponent<TableSlot>();
        craftingSlot.onRemove += onCraftedItemTaken;
    }

    void onCraftedItemTaken(Item item)
    {

        foreach (TableSlot slot in slots)
        {
            slot.removeItem();
        }

        foreach (Item i in itemsToMerge)
        {
            Destroy(i.gameObject);
        }

        itemsToMerge.Clear();
    }

    void onPlace(Item item)
    {
        itemsToMerge.Add(item);
        craft();
    }

    void onRemove(Item item)
    {
        itemsToMerge.Remove(item);
        craft();
    }

    string[] toArrayString()
    {
        return (from item in itemsToMerge select item.getItem().id).ToArray();
    }

    void craft()
    {
        emptyCraftingPoint();
        List<ItemStruct> craftables = getInstance().getCraftables();
        ItemStruct item = craftables.Find((i) => hasCombination(i.combination, toArrayString()));

        if (item.name != null)
        {
            generateItem(craftingSlot, craftedPrefab, item);
            if (craftingPoint)
            {
                VideoManager.getInstance().playVideo("scissors");
                SoundManager.getInstance()?.playOnce("craft");
            }
        }
    }



    void emptyCraftingPoint()
    {
        if (craftingSlot.hasItem())
        {
            Destroy(craftingSlot.getItem().gameObject);
            craftingSlot.removeItem();
        }

    }

    public static void generateItem(TableSlot craftingSlot, GameObject craftedPrefab, ItemStruct itemDetails)
    {
        GameObject obj = Instantiate(craftedPrefab, craftingSlot.gameObject.transform.position, Quaternion.identity);
        obj.transform.transform.parent = craftingSlot.transform;

        obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Item item = obj.AddComponent<Item>();
        item.setItem(itemDetails);

        obj.SetActive(true);
      
        craftingSlot.placeItem(item);
    }


    bool hasCombination(string[] x, string[] y)
    {
        return Enumerable.SequenceEqual(x.OrderBy(t => t), y.OrderBy(t => t));
    }

}
