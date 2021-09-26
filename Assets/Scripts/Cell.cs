using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int X;
    public int Y;

    public List<Cell> Neighbours { get; private set; }
    
    public Cell BelowCell { get; set; }
    
    private Board _board;
    private Item _item;
    private bool _fillCell;


    public Item Item
    {
        get => _item;
        set
        {
            if (_item == value) return;

            Item oldItem = _item;
            _item = value;

            if (oldItem != null && Equals(oldItem.Cell, this))
            {
                oldItem.Cell = null;
            }

            if (value != null)
            {
                value.Cell = this;
            }
        }
    }
    
    public void Prepare(int x, int y,Board board)
    {
        X = x;
        Y = y;
        gameObject.name = "Cell " + X + ":" + Y;
        transform.localPosition = new Vector3(x, y);
        _fillCell = Y == board.Rows - 1;
        _board = board;
        UpdateNeighbours();
    }

       private void UpdateNeighbours()
       {
           Neighbours = new List<Cell>();
   
           Cell up = _board.GetNeighbour(this, Direction.Up);
           Cell down = _board.GetNeighbour(this, Direction.Down);
           Cell left = _board.GetNeighbour(this, Direction.Left);
           Cell right = _board.GetNeighbour(this, Direction.Right);
   
           if (up != null) Neighbours.Add(up);
           if (down != null) Neighbours.Add(down);
           if (left != null) Neighbours.Add(left);
           if (right != null) Neighbours.Add(right);
   
           if (down != null) BelowCell = down;
       }
}
