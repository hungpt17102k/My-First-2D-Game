using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Item : MonoBehaviour
{
    //A template for the changing item 
    //Will update be more detail

    public int selectedItem = 0;

    //string current_Item;

    // Start is called before the first frame update
    void Start()
    {
        SelectedItem();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedItem = selectedItem;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedItem = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 3)
        {
            selectedItem = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 4)
        {
            selectedItem = 3;
        }

        if(previousSelectedItem != selectedItem)
        {
            SelectedItem();
        }
    }

    private void SelectedItem()
    {
        int i = 0;

        foreach(Transform item in transform)
        {
            if(i == selectedItem)
            {
                item.gameObject.SetActive(true);
            } 
            else
            {
                item.gameObject.SetActive(false);
            }

            i++;
        }
    } 

}
