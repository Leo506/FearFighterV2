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
}

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject _obstacle;                     // Префаб препятствия
    [SerializeField] Vector2 _fieldSize;                       // Размер поля
    [SerializeField] Vector2 _offset;
    [SerializeField] PlayerLogic _playerPrefab;
    [SerializeField] GameObject _enemyPrefab;


    List<Cell> usedCells = new List<Cell>();
    

    // TODO не забыть удалить
    private void Start()
    {
        GenerateRoom();
        SpawnPlayer();
        for (int i = 0; i < 5; i++)
        {
            SpawnEnemy();
        }
    }


    /// <summary>
    /// Создаёт комнату, состоящую из 25 препятствий
    /// </summary>
    public void GenerateRoom()
    {
        for (int i = 0; i < 25; i++)
        {
            GetFreeCell(0, 10, 0, 10);
        }

        foreach (var item in usedCells)
        {
            Instantiate(_obstacle).transform.position = new Vector3(item.x * _offset.x - 4.49f, _obstacle.transform.position.y, item.y * _offset.y - 4.49f);
        }
    }


    /// <summary>
    /// Создаёт игрока на свободной клетке в первом ряду
    /// </summary>
    public void SpawnPlayer()
    {
        Cell spawnCell = GetFreeCell(0, 10, 0, 2);
        var player = Instantiate(_playerPrefab);
        player.SetUpPlayer();
        player.transform.position = new Vector3(spawnCell.x * _offset.x - 4.49f, _playerPrefab.transform.position.y, spawnCell.y * _offset.y - 4.49f);
    }


    public void SpawnEnemy()
    {
        Cell spawnCell = GetFreeCell(0, 10, 0, 10);
        Instantiate(_enemyPrefab).transform.position = new Vector3(spawnCell.x * _offset.x - 4.49f, _playerPrefab.transform.position.y, spawnCell.y * _offset.y - 4.49f);
    }


    Cell GetFreeCell(int minX, int maxX, int minY, int maxY)
    {
        Cell newCell = new Cell(-1, -1);

        if (usedCells.Count < 100 && newCell == new Cell(-1, -1))
        {
            newCell = new Cell(Random.Range(minX, maxX), Random.Range(minY, maxY));
            
            while (usedCells.Contains(newCell))
                newCell = new Cell(Random.Range(minX, maxX), Random.Range(minY, maxY));

            usedCells.Add(newCell);
        }

        return newCell;
    }
}
