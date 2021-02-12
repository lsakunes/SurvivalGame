using System;

public class Stick : Item
{
	public void Start()
	{
		name = "stick";
		ingredients = new ItemTypes[0];
		creationTools = new UseObject[0];
        setImage(ItemImages.images.stickImg);
		durability = 10;
		holdable = true;
		attacks = new int[] { 1, 1, 1 };
		itemEnum = ItemTypes.stick;
		edible = false;
		hunger = 0;
	}
}