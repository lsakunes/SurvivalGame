using System;

public class Rock : Item
{
	public void Start()
	{
		name = "rock";
		ingredients = new ItemTypes[0];
		creationTools = new UseObject[0];
		setImage(ItemImages.images.rockImg);
		durability = 50;
		holdable = true;
		attacks = new int[] { 0, 2, 2 };
		itemEnum = ItemTypes.rock;
		edible = false;
		hunger = 0;
	}
}
