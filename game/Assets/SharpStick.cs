using System;
using UnityEngine;

public class SharpStick : Item
{
	override
	public Item Create()
	{
		name = "sharp stick";
		ingredients = new[] { new Stick().Create() };
		creationDevice = "craftingTable";
		creationTool = new SharpRock().Create();
		setImage(ItemImages.images.sharpStickImg);
		durability = 20;
		holdable = true;
		attacks = new int[] {4, 1, 1};
		itemEnum = ItemTypes.sharpStick;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
	{
		return new SharpStick();
	}
}
