using System;
using UnityEngine;

public class Spear : Item
{
	override
	public Item Create()
	{
		name = "spear";
		ingredients = new[] { new SmoothStick().Create(), new WoodStrip().Create(), new SharpRock().Create() };
		creationDevice = "craftingTable";
		setImage(ItemImages.images.stoneSpearImg);
		durability = 20;
		holdable = true;
		attacks = new int[] { 5, 2, 2 };
		itemEnum = ItemTypes.spear;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
	{
		return new Spear();
	}
}
