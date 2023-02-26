using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static PreSetupManager;

public class ItemResourceManager : MonoBehaviour
{

    public List<ItemStruct> itemList;
    public List<ItemStruct> furnaceItemList;

    public List<ItemStruct> recentRandomItems;

    [System.Serializable]
    public struct ItemStruct {
        [Tooltip("Use snake format when writing item id, it'll automatically be converted to a readable name.")]
        public string id;
        public string name;
        public string description;
        public Sprite image;
        public int price;
        public string[] combination;
    }

    private static ItemResourceManager instance;


    public void Start()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Debug.LogError("ItemResourceManager should only be instantiate once.");
        }
    }

    public static ItemResourceManager getInstance()
    {
        return instance;
    }

    public List<ItemStruct> getRawMaterials()
    {
        return itemList.Where(i => i.combination.Length == 0).Cast<ItemStruct>().ToList();
    }

    public ItemStruct getRandomMaterial(int randomAttempts)
    {
        List<ItemStruct> list = getRawMaterials();
        for(int i = 0 ; i < randomAttempts; i++)
        {
            ItemStruct item = list[Random.Range(0, list.Count)];
            if (!hasItemAlreadyPicked(item.id))
            {
                recentRandomItems.Add(item);
                return item;
            }
        }
        recentRandomItems.Clear();
        return list[Random.Range(0, list.Count)];
    }

    private bool hasItemAlreadyPicked(string id)
    {
        return recentRandomItems.Find((i) => i.id.Equals(id)).name != null;
    }

    public List<ItemStruct> getCraftables()
    {
        return itemList.Where(i => i.combination.Length != 0).Cast<ItemStruct>().ToList();
    }

    public List<ItemStruct> getCraftables(Difficulty difficulty)
    {
        return itemList.Where(i => i.combination.Length == (int)difficulty).Cast<ItemStruct>().ToList();
    }

    public ItemStruct getFurnaceProduct(ItemStruct item)
    {
        return furnaceItemList.Find(i => i.combination.SequenceEqual(new string[] {item.id}));
    }

    public List<ItemStruct> getFurnaceProducts()
    {
        return furnaceItemList;
    }

    public ItemStruct getItemById(string id)
    {
        return getAllCraftables().Where(i => i.id.Equals(id)).Single();
    }

    public List<ItemStruct> getAllCraftables()
    {
        List<ItemStruct> items = new List<ItemStruct>(itemList.ToArray());
        items.AddRange(furnaceItemList);

        return items;
    }
}
