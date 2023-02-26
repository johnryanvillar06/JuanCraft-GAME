using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform holdspot;
    public float actionRadius = 0.2f;
    public LayerMask pickUpMask;
    public LayerMask dropMask;

    public Vector3 Direction { get; set; }


    private GameObject itemholding;
    public GameObject pickupbutton;
    public GameObject viewbutton;
    public GameObject Slot;
    public float pickupOffset = 0;
    private TableSlot tableSlot;
    private Collider2D collision;
    
   


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            action();
        }
    }

 

    Vector3 offsetDirection(Vector3 direction, float offset)
    {
        direction.x = direction.x * offset;
        direction.y = direction.y * offset;

        return direction;
    }


    public void action() {

        tableSlot = getDropPointer()?.GetComponent<TableSlot>();
      
        if (itemholding != null && tableSlot && !getPickUpPointer())
        {
            if (!tableSlot.hasItem() && !tableSlot.isLock)
            {
                drop();
            }
            
        }
        else if(itemholding == null)
        {
            carry();

        }   
    }

    private void drop()
    {
        itemholding.GetComponent<Rigidbody2D>().simulated = true;
        itemholding.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        tableSlot.placeItem(itemholding.GetComponent<Item>());
        itemholding = null;

    }

    private Collider2D getPickUpPointer()
    {
        return Physics2D.OverlapCircle(transform.position + offsetDirection(Direction, pickupOffset), .2f, pickUpMask);
    }

    private Collider2D getDropPointer()
    {
        return Physics2D.OverlapCircle(transform.position + offsetDirection(Direction, pickupOffset), .2f, dropMask);
    }

    private void carry()
    {

        if (collision = getPickUpPointer())
        {
            itemholding = collision.gameObject;
            itemholding.transform.position = holdspot.position;
            itemholding.transform.parent = transform.GetChild(0);
            itemholding.SetActive(true);
            itemholding.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offsetDirection(Direction, pickupOffset), .2f);
    }

    public GameObject GetItemCarried()
    {
        return itemholding;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Box":
                //pickupbutton.SetActive(true);
                //viewbutton.SetActive(true);
                break;
            case "CraftingBoard":
                //pickupbutton.SetActive(true);
                //viewbutton.SetActive(true);
                break;

        }
        if (tableSlot != null)
        {
            return;
        } 
    }


    void OnTriggerExit2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Box":
                //pickupbutton.SetActive(false);
                //viewbutton.SetActive(false);
                break;
            case "CraftingBoard":
                //pickupbutton.SetActive(false);
                //viewbutton.SetActive(false);
                break;
        }
    }
}

