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
    bool ready;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        esced = false;
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.pressing = true;
            player.playerScript.controllerPauseState = false;
            player.PressE();
            Esc?.Invoke();
            Cursor.lockState = CursorLockMode.Locked;
            player.windowOpen = false;
            Debug.Log("windows closed registered");
            esced = true;
        }
        if (lookObject != null)
        {
            if (lookObject.tag == "pickup")
            {
                Item pickable = lookObject.GetComponent<Item>();
                if (Input.GetMouseButtonDown(0) && !player.Full())
                {
                    player.Add(pickable);
                    lookObject.SetActive(false);
                }
            }

        }

        if (Input.GetMouseButtonDown(0) && !esced)
        {
            if (player.windowOpen == false)
            {
                ClickObject?.Invoke();
                Debug.Log("invoked clikObject");
            }
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log("No hit");
            ResetLookedObject();
            return;
        }

        Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        if (hit.distance <= 5 && (hit.transform.tag == "pickup" || hit.transform.tag == "use"))
        {
            Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
            Debug.Log("Hit " + hit.transform.name);
            if (lookObject != hit.transform.gameObject)
            {
                ResetLookedObject();
                lookObject = hit.transform.gameObject;
                Renderer rend = lookObject.GetComponent<Renderer>();
                firstmaterial = rend.material;
                Material blue = GameObject.FindGameObjectsWithTag("material")[0].GetComponent<Renderer>().material;
                rend.material = blue;
                Debug.Log("changed to " + hit.transform.name);
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
            Debug.Log("Reseting lookObject: " + lookObject.transform.name);
            if (lookObject.tag == "use")
            {
                UseObject usable = lookObject.GetComponent<UseObject>();
                usable.UnUse();
                Debug.Log("Use object Idle");
            }
            lookObject.GetComponent<Renderer>().material = firstmaterial;
        }
        lookObject = null;
    }
}
