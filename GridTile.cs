using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridTile : MonoBehaviour
{
    public int x;
    public int y;
    public bool isWalkable = true;

    public void Init(int _x, int _y, bool _walkable)
    {
        x = _x;
        y = _y;
        isWalkable = _walkable;
    }
}
