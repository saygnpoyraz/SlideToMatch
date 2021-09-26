using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Board board;
    [SerializeField] private Level level;
    
    void Start()
    {
        board.Prepare(level.Rows,level.Cols);
        board.PrepareLevel(level);
    }
    
}
