using System;
using UnityEngine;

public class SharpRock : Item
{
	override
	public Item Create()
	{
		name = "sharpRock";
		ingredients = new []{new Rock().Create()};
		creationDevice = "craftingTable";
		creationTool = new Rock().Create();
		setImage(ItemImages.images.sharpRockImg);
		durability = 50;
		holdable = true;
		attacks = new int[] { 1, 3, 3 };
		itemEnum = ItemTypes.sharpRock;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
	{
		return new SharpRock();
	}
}
