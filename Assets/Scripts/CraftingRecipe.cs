using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ItemResourceManager;

public class CraftingRecipe : MonoBehaviour
{

    public GameObject container;
    public GameObject craftingRecipePrefab;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    private CanvasGroup canvas;
    public GameObject itemViewer;
    public Text name;
    public Text descripton;
    public Text price;
    public Image picture;

    public void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    public void previewRecipe(ItemStruct item)
    {
        enableWindow(true);
        clearContainer();
        title.SetText(item.name+" Combination");
        description.SetText(item.description);
        foreach (string id in item.combination)
        {
            createRecipeItem(getInstance().getItemById(id));
        }
    }


    public void enableWindow(bool show)
    {
        canvas.alpha = show ? 1 : 0;
        canvas.interactable = show;
        canvas.blocksRaycasts = show;
    }

    private void clearContainer()
    {
        foreach (Transform child in container.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void createRecipeItem(ItemStruct item)
    {
        GameObject obj = Instantiate(craftingRecipePrefab, container.transform);
        obj.GetComponentInChildren<TextMeshProUGUI>().SetText(item.name);
        obj.transform.Find("image").GetComponent<Image>().sprite = item.image;
        obj.GetComponent<Button>().onClick.AddListener(() =>
        {
            name.text = item.name;
            descripton.text = item.description;
            price.text = "Price: P " + item.price.ToString();
            picture.sprite = item.image;
            itemViewer.SetActive(true);
        });
    }
}
