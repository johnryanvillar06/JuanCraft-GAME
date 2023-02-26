using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemResourceManager;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> itemList;
    public GameObject prefabSpawnPoint;
    public int amountToPool;
    public int randomAttempts = 5;
    public LayerMask itemLayer;

    private void Awake()
    {
        itemList = new List<GameObject>();
    }

    void Start()
    {
        StartCoroutine(conveyorCoroutine());
    }

    bool hasItemOnSpawnPoint()
    {
        Collider2D collision = Physics2D.OverlapCircle(
            prefabSpawnPoint.transform.position,
            prefabSpawnPoint.GetComponent<Renderer>().bounds.size.x /2);

        return collision?.GetComponent<Item>() != null;
    }

    public void generateItem()
    {
        GameObject obj = Instantiate(prefabSpawnPoint, prefabSpawnPoint.transform.parent);
        obj.transform.position = prefabSpawnPoint.transform.position;

        Item item = obj.AddComponent<Item>();
        ItemStruct itemDetails = getResource().getRandomMaterial(randomAttempts);
        item.setItem(itemDetails);

        obj.SetActive(true);

        itemList.Add(obj);
        SoundManager.getInstance()?.playOnce("generate_item");
    }

    public ItemResourceManager getResource()
    {
        return GameObject.FindGameObjectWithTag("Manager")?.GetComponent<ItemResourceManager>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(prefabSpawnPoint.transform.position,
            prefabSpawnPoint.GetComponent<Renderer>().bounds.size.x / 2
            );
    }

    IEnumerator conveyorCoroutine() {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!hasItemOnSpawnPoint() && getResource())
            {                
                generateItem();
            }
        }
    }
}
