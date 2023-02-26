using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventorypanel;
    public GameObject PressButton;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void storagebutton()
    {
        inventorypanel.SetActive(true);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Storage")
        {
            PressButton.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Storage")
        { 
            PressButton.SetActive(false);
        }

    }
}
