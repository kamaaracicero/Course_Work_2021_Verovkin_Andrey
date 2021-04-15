using System;
using System.Collections.Generic;
using System.Threading;
using TreasureGameLib.Environment.MapHelpers;
using TreasureGameLib.Environment.Walls;
using TreasureGameLib.BonusesRewards;

namespace TreasureGameLib.Environment
{
    public class Map
    {
        #region Fields

        //public delegate void EngineReact();

        /// <summary>
        /// Map tiles array
        /// </summary>
        private readonly int[,] _tilesMap;

        private const float _gameFieldHeight = 2.0f;
        private const float _gameFieldWidth = 2.0f;
        private const int _playerIdOffset = 8;

        public readonly float tileHeight;
        public readonly float tileWidth;

        public bool IsMapRewrite { get; set; }
        public bool IsItemsRewrite { get; set; }

        private int _playerCount = 0;

        public List<Place> tilesList;

        private int _firstPlayerUsedAbilities = 0;
        private int _secondPlayerUsedAbilities = 0;

        public int pointsNumber;

        /// <summary>
        /// Map saver
        /// </summary>
        private readonly IMapSaver _saver;

        /// <summary>
        /// Map loader
        /// </summary>
        private readonly IMapLoader _loader;

        /// <summary>
        /// Map filler
        /// </summary>
        private readonly IMapFiller _filler;
        

        #endregion
        #region Constructors

        public Map(int[,] tilesMap, IMapSaver saver, IMapLoader loader, IMapFiller filler)
        {
            this._saver = saver;
            this._loader = loader;
            this._filler = filler;

            _tilesMap = tilesMap;
            _playerCount = 0;

            tileWidth = _gameFieldWidth / tilesMap.GetLength(1);
            tileHeight = _gameFieldHeight / tilesMap.GetLength(0);

            FillTileMap();
            GetEmptySpaces();
        }

        /// <summary>
        /// Constructor. An array with filled values
        /// </summary>
        /// <param name="tilesMap">An array with filled values</param>
        public Map(int[,] tilesMap)
            : this (tilesMap, new MapSaver("autosave.bmp"), new MapLoader("autosave.bmp"), new MapFiller())
        { }

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Map(int widthTilesCount, int heightTilesCount)
            : this (new int[widthTilesCount, heightTilesCount])
        { }

        public Map(string mapPath, IMapSaver saver, IMapLoader loader, IMapFiller filler)
        {
            this._saver = saver;
            this._loader = loader;
            this._filler = filler;

            _tilesMap = loader.LoadMapFromBmp();
            _playerCount = 0;

            tileWidth = _gameFieldWidth / _tilesMap.GetLength(1);
            tileHeight = _gameFieldHeight / _tilesMap.GetLength(0);

            FillTileMap();
            FillPoints();
        }

        public Map(string mapPath)
            : this (mapPath, new MapSaver(mapPath), new MapLoader(mapPath), new MapFiller())
        { }

        #endregion

        #region Methods

        private void FillTileMap()
        {
            tilesList = _filler.FillMap(_tilesMap, tileWidth, tileHeight);
        }

        private void FillPoints() => pointsNumber = _filler.FillMapPoints(this, PointsRandomizer.GetArray(GetSpacesForItems().Length, new UniquePointFactory(tileWidth / Point.pointScale, tileHeight / Point.pointScale), new CommonPointFactory(tileWidth / Point.pointScale, tileHeight / Point.pointScale)), GetSpacesForItems());

        public void SaveMap()
        {
            _saver.SaveMapBmp(_tilesMap);
        }

        public int[] GetEmptySpaces()
        {
            List<int> spaces = new List<int>();

            for (int row = 0; row < _tilesMap.GetLength(0); row++)
            {
                for (int col = 0; col < _tilesMap.GetLength(1); col++)
                {
                    if (_tilesMap[row, col] == 0)
                        spaces.Add(row * _tilesMap.GetLength(1) + col);
                }
            }

            return spaces.ToArray();
        }

        public int[] GetSpacesForItems()
        {
            List<int> spaces = new List<int>();
            spaces.AddRange(GetEmptySpaces());

            spaces.RemoveAt(spaces.Count - 1);
            spaces.RemoveAt(0);

            return spaces.ToArray();
        }

        public (int, int) GetFirstSpace()
        {
            for (int row = 0; row < _tilesMap.GetLength(0); row++)
            {
                for (int col = 0; col < _tilesMap.GetLength(1); col++)
                {
                    if (_tilesMap[row, col] == 0)
                        return (row, col);
                }
            }
            throw new Exception("I dont want to believe");
        }

        public (int, int) GetLastSpace()
        {
            for (int row = _tilesMap.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = _tilesMap.GetLength(1) - 1; col >= 0; col--)
                {
                    if (_tilesMap[row, col] == 0)
                        return (row, col);
                }
            }
            throw new Exception("Wow, no last place");
        }
        
        public bool MovePlayer(Player player, Direction direction)
        {
            int index = GetTileIdToGo(player, direction);
            if (tilesList[index].Collider == true)
            {
                player.ViewDirection = direction;
                return false;
            }
            else
            {
                if (tilesList[index].Points != null)
                {
                    player.Count += tilesList[index].GetPoints();
                    IsItemsRewrite = true;
                    pointsNumber--;
                }
                switch (direction)
                {
                    case Direction.Up:
                        player.MapYCoord -= 1;
                        break;
                    case Direction.Down:
                        player.MapYCoord += 1;
                        break;
                    case Direction.Left:
                        player.MapXCoord -= 1;
                        break;
                    case Direction.Right:
                        player.MapXCoord += 1;
                        break;
                }
                player.ViewDirection = direction;
                return true;
            }
        }

        private int GetTileIdToGo(Player player, Direction direction)
        {
            int tileToGo = -1;
            switch (direction)
            {
                case Direction.Up:
                    if (player.MapYCoord - 1 >= 0)
                        tileToGo = (player.MapYCoord - 1) * _tilesMap.GetLength(1) + player.MapXCoord;
                    break;
                case Direction.Down:
                    if (player.MapYCoord + 1 < _tilesMap.GetLength(0))
                        tileToGo = (player.MapYCoord + 1) * _tilesMap.GetLength(1) + player.MapXCoord;
                    break;
                case Direction.Left:
                    if (player.MapXCoord - 1 >= 0)
                        tileToGo = player.MapYCoord * _tilesMap.GetLength(1) + (player.MapXCoord - 1);
                    break;
                case Direction.Right:
                    if (player.MapXCoord + 1 < _tilesMap.GetLength(1))
                        tileToGo = player.MapYCoord * _tilesMap.GetLength(1) + (player.MapXCoord + 1);
                    break;
            }
            return tileToGo;
        }

        // !!!!!!Переделать спавнер. Сделать фабрику и плейсер игроков
        /// <summary>
        /// Place new player to map
        /// </summary>
        /// <returns>New player id</returns>
        public Player SpawnPlayer()
        {
            Player player = new Player(tileWidth, tileHeight, _playerCount + _playerIdOffset);

            if (_playerCount == 0)
            {
                (int row, int col) position = GetFirstSpace();
                player.SetMapCoords(position.col, position.row);
                Place coords = tilesList[position.row * _tilesMap.GetLength(1) + position.col];
                player.position.X += coords.position.X;
                player.position.Y += coords.position.Y;
                _playerCount++;
            }
            else
            {
                (int row, int col) position = GetLastSpace();
                player.SetMapCoords(position.col, position.row);
                Place coords = tilesList[position.row * _tilesMap.GetLength(1) + position.col];
                player.position.X += coords.position.X;
                player.position.Y += coords.position.Y;
                _playerCount++;
            }
            return player;
        }

        public void AffectWall(Player player)
        {
            Place wall = tilesList[GetTileIdToGo(player, player.ViewDirection)];

            if (wall is DestructibleWall)
            {
                Wall temp = wall as Wall;
                temp.Use();
                IsMapRewrite = true;
            }
            else if (wall is CommonWall)
            {
                if (player.Id == 8 && _firstPlayerUsedAbilities < player.AbilitiesCount)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(FirstPlayerTransformWall));

                    PlaceDecorator place = new IntangibleWall(tilesList[wall.Index]);
                    tilesList[wall.Index] = place;

                    _firstPlayerUsedAbilities += 1;
                    thread.Start(place);
                    IsMapRewrite = true;
                }
                else if (player.Id == 9 && _secondPlayerUsedAbilities < player.AbilitiesCount)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(SecondPlayerTransformWall));

                    PlaceDecorator place = new IntangibleWall(tilesList[wall.Index]);
                    tilesList[wall.Index] = place;

                    _secondPlayerUsedAbilities += 1;
                    thread.Start(place);
                    IsMapRewrite = true;
                }
            }

        }

        private void FirstPlayerTransformWall(object place)
        {
            Thread.Sleep(8000);

            PlaceDecorator newPlace = place as PlaceDecorator;
            tilesList[newPlace.Index] = newPlace.GetPlaceObject() as CommonWall;

            _firstPlayerUsedAbilities -= 1;
            IsMapRewrite = true;
        }

        private void SecondPlayerTransformWall(object place)
        {
            Thread.Sleep(8000);

            PlaceDecorator newPlace = place as PlaceDecorator;
            tilesList[newPlace.Index] = newPlace.GetPlaceObject() as CommonWall;

            _secondPlayerUsedAbilities -= 1;
            IsMapRewrite = true;
        }

        public void PlaceWall(Player player)
        {
            Place wall = tilesList[GetTileIdToGo(player, DirectionOperations.GetOppositeDirection(player.ViewDirection))];

            if (wall is Place)
            {
                if (player.Id == 8 && _firstPlayerUsedAbilities < player.AbilitiesCount)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(FirstPlayerTransformPlace));

                    PlaceDecorator place = new TemporaryWall(tilesList[wall.Index]);
                    tilesList[wall.Index] = place;

                    _firstPlayerUsedAbilities += 1;
                    thread.Start(place);
                    IsMapRewrite = true;
                }
                else if (player.Id == 9 && _secondPlayerUsedAbilities < player.AbilitiesCount)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(SecondPlayerTransformPlace));

                    PlaceDecorator place = new TemporaryWall(tilesList[wall.Index]);
                    tilesList[wall.Index] = place;

                    _secondPlayerUsedAbilities += 1;
                    thread.Start(place);
                    IsMapRewrite = true;
                }
            }
        }

        private void FirstPlayerTransformPlace(object place)
        {
            Thread.Sleep(8000);

            PlaceDecorator newPlace = place as PlaceDecorator;
            tilesList[newPlace.Index] = newPlace.GetPlaceObject();

            _firstPlayerUsedAbilities -= 1;
            IsMapRewrite = true;
        }

        // попробовать переместить это все в класс плеер
        private void SecondPlayerTransformPlace(object place)
        {
            Thread.Sleep(8000);

            PlaceDecorator newPlace = place as PlaceDecorator;
            tilesList[newPlace.Index] = newPlace.GetPlaceObject();

            _secondPlayerUsedAbilities -= 1;
            IsMapRewrite = true;
        }

        #endregion

    }
}
