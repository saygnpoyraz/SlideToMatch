using System;
using UnityEngine;

[Serializable][CreateAssetMenu(fileName = "ItemData")]
public class ItemData : ScriptableObject
{
    public Sprite Image;
    public ItemType ItemType;
}