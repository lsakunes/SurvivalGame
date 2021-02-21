using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTable : UseObject
{
    public GameObject useCanvas;
    Player player;
    Look playerLook;
    public GameObject itemSlotParent;
    public int chestSize;
    public Item[] craftingStorage;
    GameObject[] inventoryItemSlots;
    GameObject[] craftingItemSlots;
    public GameObject dropdown;
    public Item[] creatables;
    private void Start()
    {
        playerLook = FindObjectOfType<Look>();
        player = FindObjectOfType<Player>();
        useCanvas.SetActive(false);
        chestSize = 0;
        creatables = new Item[20];
        foreach (Transform x in itemSlotParent.transform)
        {
            if (x.CompareTag("craftingSlot"))
            {
                chestSize++;
            }
        }

        craftingStorage = new Item[chestSize];
    }
    public void Update()
    {
        if (useCanvas.activeSelf)
            updateDrop();
        if (useCanvas.GetComponent<UseCanvas>().redraw)
        {
            redraw();
        }
    }
    override
   public void UseReady()
    {
        Debug.Log("use subscribed");
        playerLook.ClickObject += Use;
    }
    override
    public void UnUse()
    {
        foreach (Item x in craftingStorage)
        {
            player.Add(x);
        }
        playerLook.ClickObject -= Use;
        playerLook.Esc -= UnUse;
        useCanvas.SetActive(false);
        Debug.Log("idled");
        for (int y = 0; y < craftingStorage.Length; y++)
        {
            craftingStorage[y] = null;
        }
    }
    override
    public void Use()
    {

        Debug.Log("used");
        playerLook.Esc += UnUse;
        useCanvas.SetActive(true);
        player.windowOpen = true;
        inventoryItemSlots = new GameObject[player.inventorySize];
        craftingItemSlots = new GameObject[chestSize];
        int i = 0;
        foreach (Transform slotTransform in itemSlotParent.transform)
        {
            if (slotTransform.CompareTag("inventorySlot") || slotTransform.CompareTag("craftingSlot"))
            {
                if (i < player.inventorySize)
                    inventoryItemSlots[i] = slotTransform.gameObject;
                else
                    craftingItemSlots[i - player.inventorySize] = slotTransform.gameObject;
                i++;
            }
        }
        redraw();
    }

    public void updateDrop()
    {
        int creatablesNum = 0;
        creatables = new Item[20];
        bool contin = false;
        foreach (Item x in Item.items)
        {
            if (x.ingredients.Length == 0)
                continue;
            if ((x.creationTool == null && craftingStorage[craftingStorage.Length - 1] != null) || (x.creationTool != null && craftingStorage[craftingStorage.Length - 1] == null))
                continue;
            if (x.creationDevice == "craftingTable" && x.creationTool.name == craftingStorage[craftingStorage.Length - 1].name)
            {
                int[] ingredientsEnum = new int[x.ingredients.Length];
                int[] craftingStorageEnum = new int[x.ingredients.Length];
                int z = 0;
                foreach (Item y in x.ingredients)
                {
                    ingredientsEnum[z] = (int)y.itemEnum;
                    z++;
                }

                z = 0;
                foreach (Item y in craftingStorage)
                {
                    if (y == craftingStorage[craftingStorage.Length - 1] && y != null)
                        continue;
                    if (y != null)
                    {
                        if (z >= x.ingredients.Length)
                        {
                            contin = true;
                            break;
                        }
                        craftingStorageEnum[z] = (int)y.itemEnum;
                        z++;
                    }
                }
                if (contin)
                    continue;

                if (z > x.ingredients.Length)
                    continue;

                Array.Sort(craftingStorageEnum);
                Array.Sort(ingredientsEnum);

                z = 0;
                foreach (int y in craftingStorageEnum)
                {
                    if (y != ingredientsEnum[z])
                    {
                        contin = true;
                        break;
                    }
                    z++;
                }

                if (contin)
                    continue;

                creatables[creatablesNum] = x;
                creatablesNum++;
            }
        }

        Item[] savedCreatables = creatables;

        creatables = new Item[creatablesNum];
        int w = 0;
        foreach (Item y in savedCreatables)
        {
            if (y == null)
                break;
            creatables[w] = y;
            w++;
        }

        Dropdown dropdownBar = dropdown.GetComponent<Dropdown>();
        dropdownBar.ClearOptions();
        List < Dropdown.OptionData > dropdownList = new List<Dropdown.OptionData>();
        int i = 0;
        foreach (Item x in creatables)
        {
            dropdownList.Add(new Dropdown.OptionData(creatables[i].name));
            i++;
        }
            dropdownBar.AddOptions(dropdownList);
    }
    public void redraw()
    {
        int i = 0;
        foreach (Item x in player.inventory)
        {
            if (x != null)
                inventoryItemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = x.getImage();
            else
                inventoryItemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = FindObjectOfType<WindowHandler>().emptyImg;
            i++;
        }
        i = 0;
        foreach (Item x in craftingStorage)
        {
            if (x != null)
                craftingItemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = x.getImage();
            else
                craftingItemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = FindObjectOfType<WindowHandler>().emptyImg;
            i++;
        }
    }
}
