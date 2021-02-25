using System;
using UnityEngine;

public class Bowl : Item
{
	override
	public Item Create()
	{
		name = "bowl";
		ingredients = new[] { new WoodChunk().Create()};
		creationDevice = "craftingTable";
		creationTool = new SharpRock().Create();
		setImage(ItemImages.images.bowlImg);
		durability = 20;
		holdable = true;
		attacks = new int[] { 0, 1, 1 };
		itemEnum = ItemTypes.bowl;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
	{
		return new Bowl();
	}
}
