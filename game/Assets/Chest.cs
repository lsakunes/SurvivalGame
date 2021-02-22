using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : UseObject
{
    public GameObject useCanvas;
    Player player;
    Look playerLook;
    public GameObject itemSlotParent;
    public int chestSize;
    public Item[] chestStorage;
    GameObject[] inventoryItemSlots;
    GameObject[] chestItemSlots;
    private void Start()
    {
        playerLook = FindObjectOfType<Look>();
        player = FindObjectOfType<Player>();
        useCanvas.SetActive(false);
        chestSize = 0;
        foreach (Transform x in itemSlotParent.transform)
        {
            if (x.CompareTag("chestSlot"))
            {
                chestSize++;
            }
        }

        chestStorage = new Item[chestSize];
    }
    public void Update()
    {
        if (useCanvas.GetComponent<UseCanvas>().redraw)
        {
            redraw();
        }
    }
    override
   public void UseReady()
    {
        playerLook.ClickObject += Use;
    }
    override
    public void UnUse()
    {
        playerLook.ClickObject -= Use;
        playerLook.Esc -= UnUse;
        useCanvas.SetActive(false);
    }
    override
    public void Use()
    {
        playerLook.Esc += UnUse;
        useCanvas.SetActive(true);
        player.windowOpen = true;
        inventoryItemSlots = new GameObject[player.inventorySize];
        chestItemSlots = new GameObject[chestSize];
        int i = 0;
        foreach (Transform slotTransform in itemSlotParent.transform)
        {
            if (slotTransform.CompareTag("inventorySlot") || slotTransform.CompareTag("chestSlot"))
            {
                if (i < player.inventorySize)
                    inventoryItemSlots[i] = slotTransform.gameObject;
                else
                    chestItemSlots[i - player.inventorySize] = slotTransform.gameObject;
                i++;
            }
        }

        redraw();







    }

    public void redraw()
    {
        int i = 0;
        foreach (Item x in player.inventory)
        {
            if (x != null)
                inventoryItemSlots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = x.getImage();
            else
                inventoryItemSlots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = FindObjectOfType<WindowHandler>().emptyImg;
            i++;
        }
        i = 0;
        foreach (Item x in chestStorage)
        {
            if (x != null)
                chestItemSlots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = x.getImage();
            else
                chestItemSlots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = FindObjectOfType<WindowHandler>().emptyImg;
            i++;
        }
    }
}
