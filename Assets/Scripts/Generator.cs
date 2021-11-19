using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

struct Cell
{
    public int x;
    public int y;

    public Cell(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Cell(float x, float y)
    {
        this.x = (int)x;
        this.y = (int)y;
    }

    public static bool operator ==(Cell cell_one, Cell cell_two)
    {
        if (cell_one.x == cell_two.x && cell_one.y == cell_two.y)
            return true;

        return false;
    }

    public static bool operator !=(Cell cell_one, Cell cell_two)
    {
        if (cell_one.x != cell_two.x || cell_one.y != cell_two.y)
            return true;

        return false;
    }

    public static Cell operator +(Cell cell_one, Cell cell_two)
    {
        return new Cell(cell_one.x + cell_two.x, cell_one.y + cell_two.y);
    }


    public static Cell operator /(Cell cell, int value)
    {
        return new Cell(cell.x / value, cell.y / value);
    }


    public override string ToString()
    {
        return $"Cell x = {x} and y = {y}";
    }
}

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject _obstacle;                     // Префаб препятствия
    [SerializeField] Vector2 _fieldSize;                       // Размер поля
    [SerializeField] Vector2 _offset;


    List<Cell> usedCells = new List<Cell>();
    

    // TODO не забыть удалить
    private void Start()
    {
        GenerateRoom();
        /*var obj = Instantiate(_obstacle);
        obj.transform.position = new Vector3(6 * _offset.x - 4.49f, obj.transform.position.y, 1 * _offset.y - 4.49f);*/
       
    }

    public void GenerateRoom()
    {
        for (int i = 0; i < 25; i++)
        {
            Cell newCell = new Cell(Random.Range(0, 10), Random.Range(0, 10));
            while (usedCells.Contains(newCell))
                newCell = new Cell(Random.Range(0, 10), Random.Range(0, 10));
            usedCells.Add(newCell);
        }

        foreach (var item in usedCells)
        {
            Instantiate(_obstacle).transform.position = new Vector3(item.x * _offset.x - 4.49f, _obstacle.transform.position.y, item.y * _offset.y - 4.49f);
        }
    }
}
