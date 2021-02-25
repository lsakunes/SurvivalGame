using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WindowHandler : MonoBehaviour
{
    public GameObject selected;
    public GameObject second;
    public Sprite emptyImg;
    Player player;
    Chest chest;
    CraftingTable table;

    public void OnClick(GameObject clicked)
    {
        if (selected == null)
            selected = clicked;
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            second = clicked;
        }
        Transform canvas = selected.transform;
        while (canvas.parent != null)
        {
            if (canvas.CompareTag("useCanvas"))
            {
                break;
            }
            canvas = canvas.parent;
        }
        if (selected.CompareTag("trash"))
        {
            selected = null;
            second = null;
            return;
        }
        if (second != null)
        {
            if (second == selected)
            {
                second = null;
                selected = null;
                return;
            }
            if (second.CompareTag("trash"))
            {
                player.inventory[selected.transform.GetSiblingIndex()] = null;
                selected = null;
                second = null;
                return;
            }

            //chest
            if (selected.CompareTag("chestSlot"))
            {
                if (second.CompareTag("inventorySlot"))
                {
                    Item savedItem = chest.chestStorage[selected.transform.GetSiblingIndex() - player.inventorySize];
                    chest.chestStorage[selected.transform.GetSiblingIndex() - player.inventorySize] = player.inventory[second.transform.GetSiblingIndex()];
                    player.inventory[second.transform.GetSiblingIndex()] = savedItem;
                }
                if (second.CompareTag("chestSlot"))
                {
                    Item savedItem = chest.chestStorage[selected.transform.GetSiblingIndex() - player.inventorySize];
                    chest.chestStorage[selected.transform.GetSiblingIndex() - player.inventorySize] = chest.chestStorage[second.transform.GetSiblingIndex() - player.inventorySize];
                    chest.chestStorage[second.transform.GetSiblingIndex() - player.inventorySize] = savedItem;
                }
            }
            if (selected.CompareTag("inventorySlot") && second.CompareTag("chestSlot"))
            {
                Item savedItem = player.inventory[selected.transform.GetSiblingIndex()];
                player.inventory[selected.transform.GetSiblingIndex()] = chest.chestStorage[second.transform.GetSiblingIndex() - player.inventorySize];
                chest.chestStorage[second.transform.GetSiblingIndex() - player.inventorySize] = savedItem;
            }

            //Crafting Table
            if (selected.CompareTag("craftingSlot"))
            {
                if (second.CompareTag("inventorySlot"))
                {
                    Item savedItem = table.craftingStorage[selected.transform.GetSiblingIndex() - player.inventorySize];
                    table.craftingStorage[selected.transform.GetSiblingIndex() - player.inventorySize] = player.inventory[second.transform.GetSiblingIndex()];
                    player.inventory[second.transform.GetSiblingIndex()] = savedItem;
                    table.updateDrop();
                }
                if (second.CompareTag("craftingSlot"))
                {
                    Item savedItem = table.craftingStorage[selected.transform.GetSiblingIndex() - player.inventorySize];
                    table.craftingStorage[selected.transform.GetSiblingIndex() - player.inventorySize] = table.craftingStorage[second.transform.GetSiblingIndex() - player.inventorySize];
                    table.craftingStorage[second.transform.GetSiblingIndex() - player.inventorySize] = savedItem;
                    table.updateDrop();
                }
            }
            if (selected.CompareTag("inventorySlot") && second.CompareTag("craftingSlot"))
            {
                Item savedItem = player.inventory[selected.transform.GetSiblingIndex()];
                player.inventory[selected.transform.GetSiblingIndex()] = table.craftingStorage[second.transform.GetSiblingIndex() - player.inventorySize];
                table.craftingStorage[second.transform.GetSiblingIndex() - player.inventorySize] = savedItem;
                table.updateDrop();
            }

            if (selected.CompareTag("inventorySlot") && second.CompareTag("inventorySlot"))
            {

                Item savedItem = player.inventory[selected.transform.GetSiblingIndex()];
                player.inventory[selected.transform.GetSiblingIndex()] = player.inventory[second.transform.GetSiblingIndex()];
                player.inventory[second.transform.GetSiblingIndex()] = savedItem;

            }
            if (second != null)
                canvas.GetComponent<UseCanvas>().redraw = true;
            selected = null;
            second = null;
        }

    }

    public void Start()
    {
        player = FindObjectOfType<Player>();
        FindObjectOfType<Look>().Esc += ClearSelected;
        chest = FindObjectOfType<Chest>();
        table = FindObjectOfType<CraftingTable>();
    }
    public void ClearSelected()
    {
        selected = null;
        second = null;
    }
}