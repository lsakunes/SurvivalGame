using System;
using UnityEngine;

public class MushroomOnStick : Item
{
	override
	public Item Create()
	{
		name = "mushroom on a stick";
		ingredients = new[] { new SharpStick().Create(), new Mushroom().Create()};
		creationDevice = "craftingTable";
		setImage(ItemImages.images.mushroomOnStickImg);
		durability = 20;
		holdable = true;
		attacks = new int[] { 4, 1, 1 };
		itemEnum = ItemTypes.mushroomOnStick;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
	{
		return new MushroomOnStick();
	}
}
