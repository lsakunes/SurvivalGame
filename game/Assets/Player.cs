using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    public int inventorySize;
    public Item[] inventory;
    int inventorySlot = 0;
    public GameObject inventoryUI;
    bool inventoryOn = false;
    public GameObject player;
    public FirstPersonAIO playerScript;
    public bool pressing = false;
    public int inWidth;
    public GameObject imagePrefab;
    public int inventoryWidth;
    public int inventoryHeight;
    public int slotWidth;
    public int slotHeight;
    public GameObject itemSlotParent;
    public bool windowOpen;
    GameObject[] itemSlots;
    private void Awake()
    {
        ItemImages.createImages();
    }
    void Start()
    {
        Item.InitializeItems();
        playerScript = player.GetComponent<FirstPersonAIO>();
        inventoryUI.SetActive(false);
        inventorySize = (from Transform x in itemSlotParent.transform
                         where x.CompareTag("inventorySlot")
                         select x).Count();
        inventory = new Item[inventorySize];
    }

    // Update is called once per frame
    public bool PressE()
    {
        Debug.Log("pressed E");
        if (!inventoryOn && !pressing && playerScript.IsGrounded && !windowOpen)
        {
            Debug.Log("opened window");
            inventoryUI.SetActive(true);
            playerScript.controllerPauseState = true;
            inventoryOn = true;
            windowOpen = true;
            return true;
        }
        else if (inventoryOn && !pressing)
        {
            Debug.Log("closed window");
            inventoryUI.SetActive(false);
            playerScript.controllerPauseState = false;
            inventoryOn = false;
            Cursor.lockState = CursorLockMode.Locked;
            windowOpen = false;
            return false;
        }
        return false;
    }
    void Update()
    {
        if (inventoryOn)
        {
            windowOpen = true;
            itemSlots = new GameObject[inventorySize];
            int i = 0;
            foreach (Transform slotTransform in itemSlotParent.transform)
            {
                itemSlots[i] = slotTransform.gameObject;
                i++;
                if (i >= inventorySize)
                {
                    break;
                }
            }
            playerScript.controllerPauseState = true;
            Cursor.lockState = CursorLockMode.None;

            redraw();


        }
        if (windowOpen)
        {
            playerScript.controllerPauseState = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {

            playerScript.controllerPauseState = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Add(Item inputItem)
    {
        Item item = inputItem;
        inventorySlot = 0;

        if (item == null)
            return;

        while (inventory[inventorySlot] != null)
        {
            inventorySlot++;
            if (inventorySlot == inventory.Length)
            {
                return;
            }
        }

        inventory[inventorySlot] = item;
    }

    public bool Full()
    {
        return inventorySlot >= inventorySize;
    }

    public void redraw()
    {
        int i = 0;

        foreach (Item x in inventory)
        {
            if (x != null)
                itemSlots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = x.getImage();
            else
                itemSlots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = FindObjectOfType<WindowHandler>().emptyImg;
            i++;
        }
    }
}
