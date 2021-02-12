﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : UseObject
{
    public GameObject UseCanvas;
    Player player;

    Look playerLook;
    private void Start()
    {
        playerLook = FindObjectOfType<Look>();
        player = FindObjectOfType<Player>();
        UseCanvas.SetActive(false);
    }
    override
    public void UnUse()
    {
        playerLook.Esc -= UnUse;
        player.windowOpen = false;
        UseCanvas.SetActive(false);
        Idle();
    }

    override
   public void UseReady()
    {
        playerLook.ClickObject += Use;
    }
    override
    public void Idle()
    {
        playerLook.ClickObject -= Use;
    }
    override
    public void Use()
    {
        UseCanvas.SetActive(true);
        GameObject[] itemSlots = new GameObject[player.inventorySize];
        int i = 0;
        foreach (Transform slotTransform in player.itemSlotParent.transform)
        {
            itemSlots[i] = slotTransform.gameObject;
            i++;
        }
        player.playerScript.controllerPauseState = true;
        Cursor.lockState = CursorLockMode.Confined;
        i = 0;
        player.windowOpen = true;
        foreach (Item x in player.inventory)
        {
            if (x != null)
                itemSlots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = x.getImage();
            i++;
        }
    }
}
