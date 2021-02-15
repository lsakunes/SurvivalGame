using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    private void Awake()
    {
        ItemImages.createImages();
    }
    void Start()
    {
        playerScript = player.GetComponent<FirstPersonAIO>();
        inventoryUI.SetActive(false);
        inventory = new Item[inventorySize];
    }

    // Update is called once per frame
    public bool PressE()
    {
        Debug.Log("pressed E");
        if (Input.GetKey(KeyCode.E) && !inventoryOn && !pressing && playerScript.IsGrounded && !windowOpen)
        {
            Debug.Log("opened window");
            inventoryUI.SetActive(true);
            playerScript.controllerPauseState = true;
            inventoryOn = true;
            windowOpen = true;
            return true;
        }
        else if (Input.GetKey(KeyCode.E) && inventoryOn && !pressing)
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
            GameObject[] itemSlots = new GameObject[inventorySize];
            int i = 0;
            foreach (Transform slotTransform in itemSlotParent.transform)
            {
                itemSlots[i] = slotTransform.gameObject;
                i++;
            }
            playerScript.controllerPauseState = true;
            Cursor.lockState = CursorLockMode.None;
            i = 0;

            foreach (Item x in inventory)
            {
                if (x != null)
                    itemSlots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = x.getImage();
                i++;
            }


        }
    }

    public void Add(Item inputItem)
    {
        Item item = inputItem;
        inventorySlot = 0;
        while (inventory[inventorySlot] != null)
        {
            inventorySlot++;
        }
        inventory[inventorySlot] = item;
    }

    public bool Full()
    {
        return inventorySlot >= inventorySize;
    }
}
