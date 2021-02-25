using System;
using UnityEngine;

public class WoodChunk : Item
{
	override
	public Item Create()
	{
		name = "wood";
		ingredients = new Item[0];
		setImage(ItemImages.images.woodImg);
		durability = 20;
		holdable = true;
		attacks = new int[] { 1, 2, 2 };
		itemEnum = ItemTypes.wood;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
	{
		return new WoodChunk();
	}
}
