using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIAssignmentBoard : MonoBehaviour
{

    public GameObject assignmentBoard;
    public Button Item;

    private List<BoardItem> assignmentItems;
    private List<BoardItem> productItems;

    
    public void loadAssignments()
    {
        assignmentItems.ForEach(i =>
        {
            
        });
    }

    private void setItem(BoardItem boardItem)
    {
        TextMeshProUGUI[] UITexts = Item.transform.GetComponentsInChildren<TextMeshProUGUI>();

        UITexts[0].SetText(boardItem.title);
        UITexts[1].SetText(boardItem.subtitle);
    }

    public void loadProductList()
    {

    }

    public void setAssignemnts(List<BoardItem> i)
    {

    }

    public void setProducts(List<BoardItem> i)
    {

    }

    public void clearBoard()
    {

    }

    public class BoardItem 
    {
        public string title, subtitle;
        public UnityAction action;
    }

    
}
