using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.Events;


public class ItemImages : MonoBehaviour
{
    public Sprite stickImg;
    public Sprite rockImg;
    public Sprite woodStripImg;
    public Sprite mushroomImg;
    public Sprite sharpRockImg;
    public Sprite leafImg;
    public Sprite stoneSpearImg;
    public Sprite bowlImg;
    public static ItemImages images;
    public static void createImages()
    {
        images = GameObject.FindGameObjectWithTag("images").GetComponent<ItemImages>();
    }
}
