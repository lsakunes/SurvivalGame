using System;
using UnityEngine;

public class SharpRock : Item
{
	override
	public Item Create()
	{
		name = "sharp rock";
		ingredients = new []{new Rock()};
		creationDevice = "craftingTable";
		setImage(ItemImages.images.rockImg);
		durability = 50;
		holdable = true;
		attacks = new int[] { 0, 2, 2 };
		itemEnum = ItemTypes.rock;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
	{
		return new Rock();
	}
}
