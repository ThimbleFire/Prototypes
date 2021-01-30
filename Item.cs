using System;

Class Item
{
    public string rawData;

    public void SetItem(string RawData)
    {
        this.rawData = RawData;
        BuildItem();   
    }

    private void BuildItem()
    {
        element = Binary.Convert(rawData, 0);
        itemType = Binary.Convert(rawData, 1);
        itemTypeIndex = Binary.Convert(rawData, 2);
    }

    public string void GetItem()
    {
        return string.Empty;
    }

    Elements GetElement(byte i) { get { return this.element; } }
    enum Elements
    {
        ITEM_TYPE,
        TYPE_SPECIFIC,
    } Elements element;

    ItemType GetItemType(byte i) { get { return this.itemType; } }
    enum ItemType
    {
        WEAPON,
        POTION
    } ItemType itemType;

    //itemTypeIndex is the index of the dedicated item type. So if the item type is of type weapon
    //and itemTypeIndex = 0, then itemType equals SHORTSWORD == 
    byte itemTypeIndex = 0;

    enum Weapon
    {
        SHORTSWORD,
        LONGSWORD,
        GREATSWORD
    }

    enum Potion
    {
        LESSER_HEALING,
        LESSER_MAGIC,
    }
}
