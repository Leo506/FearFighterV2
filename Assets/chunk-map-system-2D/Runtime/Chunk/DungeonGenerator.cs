using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

namespace Game.WorldGeneration
{
    [CreateAssetMenu(fileName = "New Dungeon Generator", menuName = "Map/Dungeon")]
    public class DungeonGenerator : Generator
    {
        [SerializeField] private TileBase _main;
        [SerializeField] private int _divideIterations = 12;
        [SerializeField] private int _minRoomSize = 3;
        [Space]
        [Range(0f, 1f)] [SerializeField] private float _chanceWalls = 1f;
        [SerializeField] private int _wallsIterations = 2;
        [SerializeField] private int _holeSize = 2;
        [Range(0f, 1f)] [SerializeField] private float _chanceCorners = 0.25f;

        public override void Generate(ChunkContext context, Tilemap[] tilemaps)
        {
            Tilemap tilemap = tilemaps[0];
            List<Room> rooms = RoomGenerator(context.GetMinPosition(), context.GetMaxPosition());
            List<Vector3Int> positions = new List<Vector3Int>();
            foreach (var room in rooms)
            {
                positions.AddRange(StaticGenerations.HollowRectangle(room.min, room.max));
            }
            SetTiles(_main, positions.ToArray(), tilemap);

            List<Wall> walls = new List<Wall>();
            List<Vector3Int> corners = new List<Vector3Int>();
            foreach (var room in rooms)
            {
                Add(new Wall() { x = room.min.x, y = room.min.y, size = room.max.y - room.min.y, vertical = true}, walls);//L
                Add(new Wall() { x = room.min.x, y = room.min.y, size = room.max.x - room.min.x, vertical = false}, walls);//D
                Add(new Wall() { x = room.max.x, y = room.min.y, size = room.max.y - room.min.y, vertical = true}, walls);//R
                Add(new Wall() { x = room.min.x, y = room.max.y, size = room.max.x - room.min.x, vertical = false}, walls);//U
                Add(new Vector3Int(room.min.x, room.min.y, 0), corners);//LD
                Add(new Vector3Int(room.max.x, room.min.y, 0), corners);//RD
                Add(new Vector3Int(room.min.x, room.max.y, 0), corners);//LU
                Add(new Vector3Int(room.max.x, room.max.y, 0), corners);//RU
            }
            positions.Clear();
            //Debug.Log(string.Join(" ", walls.Count, corners.Count));

            if (_chanceWalls == 1f)
            {
                foreach (var wall in walls)
                {
                    for (int i = 0; i < _wallsIterations; i++)
                    {
                        positions.AddRange(wall.GetRandomHoleInWall(_holeSize));
                    }
                }
            }
            else if (_chanceWalls != 0f)
            {
                foreach (var wall in walls)
                {
                    if (Random.value < _chanceWalls)
                    {
                        for (int i = 0; i < _wallsIterations; i++)
                        {
                            positions.AddRange(wall.GetRandomHoleInWall(_holeSize));
                        }
                    }
                }
            }
            if (_chanceCorners == 1f)
            {
                foreach (var corner in corners)
                {
                    positions.Add(corner);
                }
            }
            else if (_chanceCorners != 0f)
            {
                foreach (var corner in corners)
                {
                    if (Random.value < _chanceCorners)
                    {
                        positions.Add(corner);
                    }
                }
            }
            SetTiles(null, positions.ToArray(), tilemap);
        }

        private List<Room> RoomGenerator(Vector2Int min, Vector2Int max)
        {
            List<Room> rooms = new List<Room>() { new Room() { min = min, max = max } };
            if (_divideIterations > 0)
            {
                bool vertical = Random.value < 0.5f;
                rooms.Add(Divide(rooms[0], vertical));

                for (int i = 0; i < _divideIterations; i++)
                {
                    Room room = SelectBiggestRoom(rooms, out vertical);
                    rooms.Add(Divide(room, vertical));
                }
            }
            return rooms;
        }
        private Room SelectBiggestRoom(List<Room> rooms, out bool vertical)
        {
            int biggest = 0;
            for (int i = 1; i < rooms.Count; i++)
            {
                if (rooms[biggest].IsBigger(rooms[i]))
                {
                    biggest = i;
                }
            }
            vertical = !rooms[biggest].Vertical();
            return rooms[biggest];
        }
        private Room Divide(Room room, bool vertical)
        {
            if (vertical)
            {
                int min = room.min.x + _minRoomSize + 1;
                int max = room.max.x - _minRoomSize - 2;
                if (min > max)
                    return null;
                int divideX = Random.Range(min, max);
                Room newRoom = new Room()
                {
                    min = new Vector2Int(divideX, room.min.y),
                    max = room.max
                };
                room.max.x = divideX;
                return newRoom;
            }
            else
            {
                int min = room.min.y + _minRoomSize + 1;
                int max = room.max.y - _minRoomSize - 2;
                if (min > max)
                    return null;
                int divideY = Random.Range(min, max);
                Room newRoom = new Room()
                {
                    min = new Vector2Int(room.min.x, divideY),
                    max = room.max
                };
                room.max.y = divideY;
                return newRoom;
            }
        }

        private static bool Add(Wall item, List<Wall> collection)
        {
            if (collection.Count == 0)
            {
                collection.Add(item);
                return true;
            }
            else if (!collection.Contains(item))
            {
                collection.Add(item);
                return true;
            }
            return false;
        }
        private static bool Add(Vector3Int item, List<Vector3Int> collection)
        {
            if (collection.Find((Vector3Int w) => item == w) == null)
            {
                collection.Add(item);
                return true;
            }
            return false;
        }

        [System.Serializable]
        private class Room
        {
            public Vector2Int min, max;

            public override string ToString()
            {
                return string.Format("min: {0}, {1} ||| max: {2}, {3}", min.x, min.y, max.x, max.y);
            }

            public bool IsBigger(Room room)
            {
                return room.GetSquare() > GetSquare();
            }

            public int GetSquare()
            {
                return (max.y - min.y) * (max.x - min.x);
            }

            public bool Vertical()
            {
                return (max.y - min.y) > (max.x - min.x);
            }
        }

        [System.Serializable]
        private class Wall
        {
            public int x, y, size;
            public bool vertical;

            public override string ToString()
            {
                return string.Format("pos: {0}, {1} ||| size: {2}, vertical: {3}", x, y, size, vertical);
            }

            public Vector3Int[] GetRandomHoleInWall(int sizeOfHole)
            {
                if (size - 2 < sizeOfHole)
                    sizeOfHole = size - 2;
                int startIndex = Random.Range(0, size - sizeOfHole - 2);
                Vector3Int[] hole = new Vector3Int[sizeOfHole];
                for (int i = 0; i < sizeOfHole; i++)
                {
                    hole[i] = GetPoint(startIndex + i);
                }
                return hole;
            }
            public Vector3Int GetPoint(int index)
            {
                if (index > size - 1)
                    return new Vector3Int();
                if (vertical)
                    return new Vector3Int(x, y + index, 0);
                else
                    return new Vector3Int(x + index, y, 0);
            }

            public static bool operator ==(Wall wall1, Wall wall2)
            {
                return wall1.x == wall2.x && wall1.y == wall2.y && wall1.size == wall2.size && wall1.vertical == wall2.vertical;
            }
            public static bool operator !=(Wall wall1, Wall wall2)
            {
                return !(wall1 == wall2);
            }
        }
    }
}