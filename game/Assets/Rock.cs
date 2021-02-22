using System;

public class Rock : Item
{
	override
	public Item Create()
	{
		name = "rock";
		ingredients = new Item[0];
		setImage(ItemImages.images.rockImg);
		durability = 200;
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
