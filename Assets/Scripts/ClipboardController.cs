using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClipboardController : MonoBehaviour
{
    public GameObject AssignmentItemPrefab;
    public GameObject AssignmentContainer;
    public GameObject ProductItemPrefab;
    public GameObject ProductContainer;
    public CraftingRecipe craftingRecipe;

    private bool hasTriggered = false;

    private void OnEnable()
    {
        clearContainer();
        previewAssignments();
    }

    void previewAssignments()
    {
        List<AssignmentManager.Demand> demands = AssignmentManager.getInstance().demands;   
        demands.ForEach((d) => {
            initContainer(AssignmentItemPrefab, AssignmentContainer, new ClipboardDetailStruct(
                d.item.name,
                d.numberOfDemands + " / " + d.satisfied,
                d.item.image,
                () => craftingRecipe.previewRecipe(d.item)
            ));
        });
    }

    public void previewProductsTriggerOnce()
    {
        if (!hasTriggered)
        {
            hasTriggered = true;
            previewProducts();
        }
    }

    void previewProducts()
    {
        List<ItemResourceManager.ItemStruct> items = ItemResourceManager.getInstance().getAllCraftables();

        items.ForEach((i) =>
        {
            initContainer(ProductItemPrefab, ProductContainer, new ClipboardDetailStruct(
                i.name,
                "Price: " + i.price,
                i.image,
                () => craftingRecipe.previewRecipe(i)
            ));
        });
    }

    void clearContainer()
    {
        foreach (Transform child in AssignmentContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public static void initContainer(GameObject prefab, GameObject container, ClipboardDetailStruct item)
    {

        GameObject obj = Instantiate(prefab, container.transform);

        obj.transform.Find("title")
            .GetComponent<TextMeshProUGUI>()
            .SetText(item.title);

        obj.transform.Find("subtitle")
            .GetComponent<TextMeshProUGUI>()
            .SetText(item.subtitle);

        obj.transform.Find("Image").GetComponent<Image>().sprite = item.sprite;
        obj.GetComponent<Button>().onClick.AddListener(item.action);
    }

    public struct ClipboardDetailStruct
    {
        public string title, subtitle;
        public Sprite sprite;
        public UnityAction action;

        public ClipboardDetailStruct(string title, string subtitle, Sprite sprite, UnityAction action)
        {
            this.title = title;
            this.subtitle = subtitle;
            this.sprite = sprite;
            this.action = action;
        }
    }



}
