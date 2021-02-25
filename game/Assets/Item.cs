using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
	woodStrip,
	stick,
	rock,
	mushroom,
	sharpRock,
	sharpStick,
	mushroomOnStick,
	spear,
	smoothStick,
	wood,
	bowl
}
public abstract class Item
{
	public string name;
	public Item[] ingredients;
    public Item creationTool;
	public string creationDevice;
	public Sprite image;
	public int durability;
	public bool holdable;
	public bool edible;
	public int hunger;
	public ItemTypes itemEnum;
	public static Item[] items;
    public static int itemNum = 11;
	// forward attack, downward attack, sideways 
	public int[] attacks;

	public abstract Item newObject();

	public abstract Item Create();

	public static void InitializeItems()
	{
		items = new Item[itemNum];
		items[(int)ItemTypes.stick] = new Stick().Create();
		items[(int)ItemTypes.rock] = new Rock().Create();
		items[(int)ItemTypes.mushroom] = new Mushroom().Create();
		items[(int)ItemTypes.sharpRock] = new SharpRock().Create();
		items[(int)ItemTypes.sharpStick] = new SharpStick().Create();
		items[(int)ItemTypes.mushroomOnStick] = new MushroomOnStick().Create();
		items[(int)ItemTypes.woodStrip] = new WoodStrip().Create();
		items[(int)ItemTypes.spear] = new Spear().Create();
		items[(int)ItemTypes.smoothStick] = new SmoothStick().Create();
		items[(int)ItemTypes.wood] = new WoodChunk().Create();
		items[(int)ItemTypes.bowl] = new Bowl().Create();

	}
	
	public Sprite getImage()
    {
		return image;
    }
	public void setImage(Sprite image)
    {
		this.image = image;
    }

	public static Item GetItemByIcon(Sprite img)
    {
		foreach (Item x in items)
		{
			if (img.texture.name == x.image.texture.name)
			{
				return x.newObject().Create();
			}
		}
		return null;
    }

	public static Item GetItemByTag(string tag)
    { 
		foreach (Item x in items)
		{
			if (tag == x.name)
			{
				return x.newObject().Create();
			}
		}
		return null;
	}

	public static Item GetItemByEnum(int num){
		foreach (Item x in items)
        {
			if (num == (int)x.itemEnum)
            {
				return x.newObject().Create();
            }
        }
		return null;
	}

	public bool CheckBreak()
    {
		if (durability <= 0)
		{
			return true;
		}
		else return false;
    }
}




