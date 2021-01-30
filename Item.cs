using System;

Class Item
{
    // The item in binary form
    public string rawData;

    public void SetItem(string RawData) {
    
        this.rawData = RawData;
        BuildItem();   
    }
	
	public void Randomize(int tier) {
	
		//item type count - Get the number of item types
		int itc = Enum.GetNames(typeof(ItemType)).Length - 1;
		
		//random item type count - Get a random item type
		int ritc = Random.Range(0, itc);
		
		//to binary item type - Convert the random item type to binary
		int tbit = Binary.ToBinary(ritc);
		
		//item type index count
		int itic = 0;
		
		//getting the max length of the random item type
		switch(ritc) {
		
			case ItemType.WEAPON: itic = Enum.GetNames(typeof(Weapon)).Length - 1; break;
			case ItemType.POTION: itic = Enum.GetNames(typeof(Potion)).Length - 1; break;
		}
		
		//randomizing the random item type using the max length
		int tditi = Random.Range(0, itic);
		
		//converting the randomized item type index to binary
		int rbiti = Binary.ToBinary(tditi);
		
		//converting the given decimal value to binary
		int binaryTier = Binary.ToBinary(tier);
		
		//set the raw item data and build the item.
		SetItem(tbit + rbiti + binaryTier);
	}

    private void BuildItem() {
    
        itemType = Binary.ToDecimal(rawData, 0);
        itemTypeIndex = Binary.ToDecimal(rawData, 1);
        tier = Binary.ToDecimal(rawData, 2);
    }

    ItemType GetItemType(byte i) { get { return this.itemType; } }
    enum ItemType {
    
        WEAPON,
        POTION
    } ItemType itemType;

    //itemTypeIndex is the index of the dedicated item type. So if the item type is of type weapon
    //and itemTypeIndex = 0, then itemType equals SHORTSWORD
    byte itemTypeIndex = 0;
    
    //Items of all type can drop at any time. How good those items are comes down to tier and other properties.
    //Chance of getting higher tier items increase as the player gets further through the game.
    byte tier = 0;

    enum Weapon {
    
        SHORTSWORD,
        LONGSWORD,
        GREATSWORD
    }

    enum Potion {
    
        LESSER_HEALING,
        LESSER_MAGIC
    }
}
