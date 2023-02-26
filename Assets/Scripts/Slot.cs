using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    private Inventory manager;

    public int ID;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Inventory>();
    }
    public void SelectSlot()
    {       
        manager.currentSlot = ID;
    }
  
}
