using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TruckManager : MonoBehaviour
{

    public List<TableSlot> slots;
    public int points;
    public TextMeshProUGUI text;
    public Sprite star;
    public bool acceptDeliveries = true;

    private AssignmentManager assignmentManager;
    private MainManager mainManager;


    void Start()
    {
        assignmentManager = GetComponent<AssignmentManager>();
        mainManager = GetComponent<MainManager>();

        initTruck();

        mainManager.onTimesUp += () => acceptDeliveries = false;
    }

    void initTruck()
    {
        foreach (TableSlot slot in slots)
        {
            slot.onPlaced += (Item item) =>
            {
                if (!acceptDeliveries || hasNoCombination(item)) { return; }
                points += assignmentManager.getPoints(item.getItem());
                assignmentManager.satisfyDemand(item.getItem());
                text.SetText("= " + points.ToString("D4"));
                slot.removeItem();
                Destroy(item.gameObject);
                stopGameOnFulfillment();
                SoundManager.getInstance()?.playOnce("deliver");
            };
        }
    }

    bool hasNoCombination(Item item)
    {
        return item.getItem().combination.Length == 0;
    }

    void stopGameOnFulfillment()
    {
        if (assignmentManager.hasFulfilled())
        {
            mainManager.stopGame();
        }
    }
}
