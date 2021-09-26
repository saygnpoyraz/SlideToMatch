using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    
    private ItemType _itemType;

    private Cell _cell;
    
    private Cell _targetCell;


    public Cell Cell
    {
        get => _cell;
        set
        {
            if (_cell == value) return;

            Cell oldCell = _cell;
            _cell = value;

            if (oldCell != null && oldCell.Item == this)
            {
                oldCell.Item = null;
            }

            if (value != null)
            {
                value.Item = this;
                gameObject.name = _cell.gameObject.name + " " + GetType().Name;
            }
        }
    }

    public void Prepare(ItemData data)
    {
        _itemType = data.ItemType;
        SpriteRenderer.sprite = data.Image;
    }
}
