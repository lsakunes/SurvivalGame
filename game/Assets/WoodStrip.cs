using System;
using UnityEngine;

public class WoodStrip : Item
{
	override
	public Item Create()
	{
		name = "wood strip";
		ingredients = new Item[0];
		setImage(ItemImages.images.woodStripImg);
		durability = 20;
		holdable = true;
		attacks = new int[] { 0, 0, 0 };
		itemEnum = ItemTypes.woodStrip;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
	{
		return new WoodStrip();
	}
}
