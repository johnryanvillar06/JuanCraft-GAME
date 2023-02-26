using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSlot : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isLock;
    public bool ignoreLocation;
    public Vector3 locationOfItem;

    public delegate void OnPlaced(Item item);
    public delegate void OnRemove(Item item);
    public event OnPlaced onPlaced;
    public event OnRemove onRemove;

    private Item item;

    void Start()
    {
        
        if (!ignoreLocation && locationOfItem.x == 0 && locationOfItem.y == 0)
        {
           // CraftingBoard board = new CraftingBoard;
            
            locationOfItem = GetComponent<Renderer>().bounds.center;
        }

        if(gameObject?.GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }

        onPlaced += centerItem;
    }

    private void LateUpdate()
    {
        if(item != null && item.transform.parent != transform)
        {
            onRemove?.Invoke(item);
            removeItem();
        }
    }

    public void removeItem()
    {
        SoundManager.getInstance()?.playOnce("item_pick");
        item = null;
    }

    // Update is called once per frame
    public void placeItem(Item item)
    {
        this.item = item;
        SoundManager.getInstance()?.playOnce("item_drop");
        onPlaced?.Invoke(item);

    }

    void centerItem(Item item)
    {
        if (!ignoreLocation)
        {
            item.gameObject.transform.position = locationOfItem;
        }
        item.gameObject.transform.SetParent(transform);
    }

    public void removeCenterItem()
    {
        onPlaced -= centerItem;
    }

    public bool hasItem()
    {
        return item?.name != null;
    }

    public Item getItem()
    {
        return item;
    }
}
        