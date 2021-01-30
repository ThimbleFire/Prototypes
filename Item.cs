using System;

Class Item
{
    // The item in binary form
    public string rawData;

    public void SetItem(string RawData) {
    
        this.rawData = RawData;
        BuildItem();   
    }
	
	public void Random(int tier) {
	
			int ItemType = Random.Range(0, Binary.ToBinary(Enum.GetNames(typeof(ItemType)).Length - 1));
			int ItemTypeIndex = Random.Range(0, Binary.ToBinary(Enum.GetNames(typeof(ItemType)).Length - 1));
			int Tier = Random.Range(0, Binary.ToBinary(tier));
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
