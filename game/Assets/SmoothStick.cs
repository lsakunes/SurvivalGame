using System;

public class SmoothStick : Item
{
	override
	public Item Create()
	{
		name = "smooth stick";
		ingredients = new[] { new Stick().Create() };
		creationDevice = "craftingTable";
		creationTool = new SharpRock().Create();
		setImage(ItemImages.images.smoothStickImg);
		durability = 10;
		holdable = true;
		attacks = new int[] { 1, 1, 1 };
		itemEnum = ItemTypes.smoothStick;
		edible = false;
		hunger = 0;

		return this;
	}

	override
	public Item newObject()
	{
		return new SmoothStick().Create();
	}
}