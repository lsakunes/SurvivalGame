using System;

public class Mushroom : Item
{
	public void Start()
	{
		name = "mushroom";
		ingredients = new ItemTypes[0];
		creationTools = new UseObject[0];
		setImage(ItemImages.images.mushroomImg);
		durability = 0;
		holdable = false;
		attacks = new int[] { 0, 0, 0 };
		itemEnum = ItemTypes.mushroom;
		edible = true;
		hunger = 1;
	}
}
