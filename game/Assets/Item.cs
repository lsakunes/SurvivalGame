using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
	stick,
	rock,
	mushroom
}
public abstract class Item : MonoBehaviour
{
	public new string name;
	public ItemTypes[] ingredients;
	public UseObject[] creationTools;
	public UseObject creationDevice;
	private Sprite image;
	public int durability;
	public bool holdable;
	public bool edible;
	public int hunger;
	public ItemTypes itemEnum;
	// forward attack, downward attack, sideways attack
	public int[] attacks;
	public Sprite getImage()
    {
		return image;
    }
	public void setImage(Sprite image)
    {
		this.image = image;
    }
}




