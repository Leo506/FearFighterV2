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
    
    List<Cell> usedCells = new List<Cell>();                   // Использованные клетки поля
    Cell startCell;                                            // Стартовая клетка

    

    // TODO не забыть удалить
    private void Start()
    {
        GenerateRoom();
        /*var obj = Instantiate(_obstacle);
        obj.transform.position = new Vector3(6 * _offset.x - 4.49f, obj.transform.position.y, 1 * _offset.y - 4.49f);*/
       
    }

    public void GenerateRoom()
    {
        // Выбор стартовой точки
        startCell = new Cell(0, 0);
        usedCells.Add(startCell);


        // Перебираем все клетки в ряду стартовой точки
        /*for (int x = 0; x < _fieldSize.x; x++)
        {
            CreateNewCell(x, 0);
        }*/


        // Перебираем все оствышиеся клетки
        for (int x = 0; x < _fieldSize.x; x+=2)
        {
            for (int y = 0; y < _fieldSize.y; y+=2)
            {
                CreateNewCell(x, y);
            }
        }


        List<Cell> freeCells = new List<Cell>();
        for (int x = 0; x < _fieldSize.x; x++)
        {
            for (int y = 0;  y < _fieldSize.y;  y++)
            {
                if (!usedCells.Contains(new Cell(x, y)))
                    freeCells.Add(new Cell(x, y));
            }
        }

        for (int i = 0; i < freeCells.Count; i++)
        {
            int j = Random.Range(0, freeCells.Count);
            var tmp = freeCells[j];
            freeCells[j] = freeCells[i];
            freeCells[i] = tmp;
        }

        for (int i = 0; i < freeCells.Count / 2; i++)
        {
            Instantiate(_obstacle).transform.position = new Vector3(freeCells[i].x * _offset.x - 4.49f, _obstacle.transform.position.y, freeCells[i].y * _offset.y - 4.49f);
        }



        foreach (var item in usedCells)
        {
            Debug.Log(item);
        }
    }


    void CreateNewCell(int x, int y)
    {
        Cell newCell = GetValidDir(x, y);

        if (newCell != new Cell(-1, -1))
        {
            Cell currentCell = new Cell(x, y);
            Cell middleCell = (newCell + currentCell) / 2;
            
            usedCells.Add(newCell);
            usedCells.Add(currentCell);
            usedCells.Add(middleCell);
        }
    }


    Cell GetValidDir(int x, int y)
    {
        Vector2[] availableDirs = { Vector2.up * 2, Vector2.right * 2 };
        for (int i = 0; i < 2; i++)
        {
            int j = Random.Range(0, 2);
            var tmp = availableDirs[j];
            availableDirs[j] = availableDirs[i];
            availableDirs[i] = tmp;
        }

        foreach (var item in availableDirs)
        {
            Cell newPos = new Cell(x + item.x, y + item.y);
            if (!usedCells.Contains(newPos) && (newPos.x >= 0 && newPos.x < _fieldSize.x) && (newPos.y >= 0 && newPos.y < _fieldSize.y))
            {
                Debug.Log("On cell " + new Cell(x, y) + " valid cell " + newPos);
                return newPos;
            }
        }

        return new Cell(-1, -1);
    }
   
}
