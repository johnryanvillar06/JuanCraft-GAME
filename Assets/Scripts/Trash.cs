using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TableSlot slot = GetComponent<TableSlot>();
        slot.onPlaced += (Item item) =>
        {
            slot.removeItem();
            Destroy(item.gameObject);
        };
    }
}
