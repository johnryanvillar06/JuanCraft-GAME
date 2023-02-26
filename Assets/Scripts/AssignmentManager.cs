using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ItemResourceManager;
using static PreSetupManager;

public class AssignmentManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<CustomDemand> customDemands;
    public double demandPointsMultiplier = 1.5;
    [Header("Don't touch this, READ ONLY.")]
    public List<Demand> demands;
    
    

    private static AssignmentManager instance;

    private ItemResourceManager resourceManager;
    


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("AssignmentManager should only be instantiated once.");
        }


        resourceManager = GetComponent<ItemResourceManager>();
        initDemands();
        
    }

    public static AssignmentManager getInstance()
    {
        return instance;
    }

    void initDemands()
    {
        customDemands.ForEach((c) =>
        {
            Demand demand = new Demand();
            demand.item = resourceManager.getItemById(c.itemID);
            demand.numberOfDemands = c.numberOfDemands;
            demands.Add(demand);
        });

    }

    int adjustMaxIndex(List<ItemStruct> items, int numberOfDemands)
    {
        if (numberOfDemands > items.Count)
        {
            numberOfDemands = items.Count;
        }

        return numberOfDemands;
    }

    public bool isInDemand(ItemStruct item)
    {
        return demands.Find(d => d.item.id.Equals(item.id) && d.isSatisfied()) != null;
    }

    public int getPoints(ItemStruct item)
    {
        if (isInDemand(item))
        {
            return (int)(item.price * demandPointsMultiplier);
        }else
        {
            return item.price;
        }
    } 

    public void satisfyDemand(ItemStruct item)
    {
        demands.Find(d => d.item.id.Equals(item.id))?.satisfy();
    }

    public bool hasFulfilled()
    {
        double totalDemand = demands.Select(d => d.numberOfDemands).Sum();
        double totalSatisfied = demands.Select(d => d.satisfied).Sum();

        return totalDemand == totalSatisfied;
    }

    public int getOverallProgress()
    {
        double totalDemand = demands.Select(d => d.numberOfDemands).Sum();
        double totalSatisfied = demands.Select(d => d.satisfied).Sum();

        return (int)(totalSatisfied / totalDemand * 100);
    }

    [System.Serializable]
    public class Demand
    {
        public ItemStruct item;
        public int numberOfDemands;
        public int satisfied;

        public bool isSatisfied()
        {
            return satisfied < numberOfDemands;
        }

        public void satisfy()
        {
            satisfied++;
        }
    }

    [System.Serializable]
    public struct CustomDemand
    {
        public string itemID;
        [Range(1,100)]
        public int numberOfDemands;
    }
}
