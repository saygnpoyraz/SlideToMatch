using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject
{
    public int Rows;
    public int Cols;
    public List<ItemData> ItemDatas;
}

