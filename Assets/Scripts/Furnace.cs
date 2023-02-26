using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemResourceManager;

public class Furnace : MonoBehaviour
{


    private TableSlot slot;
    public GameObject craftedPrefab;

    // Start is called before the first frame update
    void Start()
    {
        slot = GetComponent<TableSlot>();

        slot.onPlaced += (Item item) =>
        {
            
            ItemStruct furnaceProduct = ItemResourceManager.getInstance().getFurnaceProduct(item.getItem());
            if(furnaceProduct.id != null)
            {
                VideoManager.getInstance().playVideo("to_furnace");
                slot.removeItem();
                Destroy(item.gameObject);

                CraftingBoard.generateItem(slot, craftedPrefab, furnaceProduct);   
            }
        };
    }
}
