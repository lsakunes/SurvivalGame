using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHandler : MonoBehaviour
{
    public GameObject selected;
    public GameObject second;


    public void OnClick(GameObject clicked)
    {
        if (selected == null)
            selected = clicked;

        else
            second = clicked;
        if (second != null)
        {
            Transform storedImage = selected.transform.GetChild(0);
            selected.transform.DetachChildren();
            second.transform.GetChild(0).parent = selected.transform;
            storedImage.parent = second.transform;
            selected.transform.GetChild(0).position = selected.transform.position;
            second.transform.GetChild(0).position = second.transform.position;
            if (selected.transform.parent.parent.parent.parent.CompareTag("inventory"))
            {
                Player player = FindObjectOfType<Player>();
                Item savedItem = player.inventory[selected.transform.GetSiblingIndex()];
                player.inventory[selected.transform.GetSiblingIndex()] = player.inventory[second.transform.GetSiblingIndex()];
                player.inventory[second.transform.GetSiblingIndex()] = savedItem;

            }
            selected = null;
            second = null;
        }
    }

    public void Start()
    {
        FindObjectOfType<Look>().Esc += ClearSelected;
    }
    public void ClearSelected()
    {
        selected = null;
        second = null;
    }
}