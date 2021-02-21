using System;

public class Mushroom : Item
{
	override
	public Item Create()
	{
		name = "mushroom";
		ingredients = new Item[0];
		setImage(ItemImages.images.mushroomImg);
		durability = 0;
		holdable = false;
		attacks = new int[] { 0, 0, 0 };
		itemEnum = ItemTypes.mushroom;
		edible = true;
		hunger = 1;

		return this;
	}

	override
	public Item newObject()
	{
		return new Mushroom();
	}
}
