using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform[] slots;
    public bool[] isFull;

    public Transform slotHolder;

    public int currentSlot;

    private void Start()
    {
        UpdateSlot();
    }

    private void UpdateSlot()
    {
        slots = new Transform[slotHolder.childCount];
        isFull = new bool[slotHolder.childCount];

        for (int i = 0; i< slotHolder.childCount; i++)
        {
            slots[i] = slotHolder.GetChild(i);
            slots[i].GetComponent<slot>().ID = i;
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].childCount < 1)
            {
                isFull[i] = false;
            }
            else if (slots[i].childCount > 0)
            {
                isFull[i] = true;
            }
        }
    }
    public void AddItem(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i] == false)
            {
                Instantiate(item, slots[i]);
                UpdateSlot();
                break;
            }
        }
    }
    public void RemoveItem ()
    {
        Destroy(slots[currentSlot].GetChild(0).gameObject);
        if (slots[currentSlot].childCount < 1)
        {
            return;
            
        }
        
    }
}
