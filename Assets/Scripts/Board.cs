using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;

    [SerializeField] private Transform cellParent;
    [SerializeField] private Transform itemParent;


    public int Rows { get; private set; }
    public int Cols { get; private set; }

    private Cell[,] _cells;

    public void Prepare(int rowCount, int colCount)
    {
        Rows = rowCount;
        Cols = colCount;
        CreateCells();
        PrepareCells();
    }

    private void CreateCells()
    {
        _cells = new Cell[Cols, Rows];
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Cols; x++)
            {
                Cell cell = Instantiate(cellPrefab, Vector3.zero, Quaternion.identity, cellParent);
                _cells[x, y] = cell;
            }
        }
    }

    private void PrepareCells()
    {
        for (int y = 0; y < Rows; y++)
        {
            for (int x = 0; x < Cols; x++)
            {
                Cell cell = _cells[x, y];
                cell.Prepare(x, y,this);
            }
        }
    }
    
    public Cell GetNeighbour(Cell cell, Direction direction)
    {
        int x = cell.X;
        int y = cell.Y;
        switch (direction)
        {
            case Direction.Up:
                y += 1;
                break;
            case Direction.Right:
                x += 1;
                break;
            case Direction.Down:
                y -= 1;
                break;
            case Direction.Left:
                x -= 1;
                break;
        }

        if (x >= Cols || x < 0 || y >= Rows || y < 0) return null;

        return _cells[x, y];
    }

    public void PrepareLevel(Level level)
    {
        for (int y = 0; y < level.Rows; y++)
        {
            for (int x = 0; x < level.Cols; x++)
            {
                Cell cell = _cells[x, y];

                Item item = ItemFactory.CreateItem(level.ItemDatas[Random.Range(0,level.ItemDatas.Count)],itemParent);
                if (item == null) continue;

                cell.Item = item;
                item.transform.position = cell.transform.position;
            }
        }
    }
}