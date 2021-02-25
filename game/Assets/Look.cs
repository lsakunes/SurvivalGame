using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Look : MonoBehaviour
{
    GameObject lookObject;
    public delegate void LookedAtObject();
    public event LookedAtObject ClickObject;
    public delegate void PressedESC();
    public event PressedESC Esc;
    public AudioClip cantClick;
    Material firstmaterial;
    Player player;
    bool esced;
    public bool debugging = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debugging)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                player.Add(new Rock().Create());
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                player.Add(new Stick().Create());
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                player.Add(new Mushroom().Create());
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                player.Add(new SharpRock().Create());
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                player.Add(new WoodStrip().Create());
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                player.Add(new WoodChunk().Create());
            }
        }
        esced = false;
        if (Input.GetKeyDown(KeyCode.E))
        {
            PressE();
        }
        else
        {
            player.pressing = false;
        }
        if (lookObject != null)
        {
            if (lookObject.tag == "pickup")
            {
                Item pickable = Item.GetItemByTag(lookObject.GetComponent<pickupObject>().name);
                if (Input.GetMouseButtonDown(0) && !player.Full())
                {
                    player.Add(pickable);
                    lookObject.SetActive(false);
                }
            }

        }

        if (Input.GetMouseButtonDown(0) && !esced  && player.playerScript.IsGrounded)
        {
            if (player.windowOpen == false)
            {
                ClickObject?.Invoke();
            }
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.forward, out hit))
        {
            ResetLookedObject();
            return;
        }

        Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        if (hit.distance <= 5 && (hit.transform.tag == "pickup" || hit.transform.tag == "use"))
        {
            Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
            if (lookObject != hit.transform.gameObject)
            {
                ResetLookedObject();
                lookObject = hit.transform.gameObject;
                Renderer rend = lookObject.GetComponent<Renderer>();
                firstmaterial = rend.material;
                Material blue = GameObject.FindGameObjectsWithTag("material")[0].GetComponent<Renderer>().material;
                rend.material = blue;
                if (lookObject.tag == "use")
                {
                    lookObject.GetComponent<UseObject>().UseReady();
                }
            }
        }
        else
        {
            ResetLookedObject();
        }
    }

    void ResetLookedObject()
    {
        if (lookObject != null)
        {
            if (lookObject.tag == "use")
            {
                UseObject usable = lookObject.GetComponent<UseObject>();
                usable.UnUse();
            }
            lookObject.GetComponent<Renderer>().material = firstmaterial;
        }
        lookObject = null;
    }

    public void PressE()
    {
        player.playerScript.controllerPauseState = false;
        player.PressE();

        player.pressing = true;
        if (player.windowOpen)
        {
            Esc?.Invoke();
            Cursor.lockState = CursorLockMode.Locked;
            player.windowOpen = false;
            esced = true;
        }
    }
}
