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
}

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject _obstacle;                     // Префаб препятствия
    [SerializeField] Vector2 _fieldSize;                       // Размер поля
    [SerializeField] Vector2 _offset;
    [SerializeField] PlayerLogic _playerPrefab;


    List<Cell> usedCells = new List<Cell>();
    

    // TODO не забыть удалить
    private void Start()
    {
        GenerateRoom();
        SpawnPlayer();
    }


    /// <summary>
    /// Создаёт комнату, состоящую из 25 препятствий
    /// </summary>
    public void GenerateRoom()
    {
        for (int i = 0; i < 25; i++)
        {
            Cell newCell = new Cell(Random.Range(0, 10), 0);
            while (usedCells.Contains(newCell))
                newCell = new Cell(Random.Range(0, 10), Random.Range(0, 10));
            usedCells.Add(newCell);
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
        Cell newCell = new Cell(Random.Range(0, 10), Random.Range(0, 2));
        while (usedCells.Contains(newCell))
            newCell = new Cell(Random.Range(0, 10), Random.Range(0, 2));
        usedCells.Add(newCell);
        var player = Instantiate(_playerPrefab);
        player.SetUpPlayer();
        player.transform.position = new Vector3(newCell.x * _offset.x - 4.49f, _playerPrefab.transform.position.y, newCell.y * _offset.y - 4.49f);
    }
}
