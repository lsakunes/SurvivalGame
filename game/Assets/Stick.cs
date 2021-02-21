using System;

public class Stick : Item
{
	override
	public Item Create()
	{
		name = "stick";
		ingredients = new Item[0];
        setImage(ItemImages.images.stickImg);
		durability = 10;
		holdable = true;
		attacks = new int[] { 1, 1, 1 };
		itemEnum = ItemTypes.stick;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
    {
		return new Stick().Create();
    }
}