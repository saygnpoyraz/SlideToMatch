using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemFactory
{
    public static Item CreateItem(ItemData data,Transform itemParent)
    {
        GameObject itemPrefab = Resources.Load("Item") as GameObject;
        
        Item item = Object.Instantiate(
            itemPrefab, Vector3.zero, Quaternion.identity, itemParent).GetComponent<Item>();

        
        item.Prepare(data);

        return item;
    }
}