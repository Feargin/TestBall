using System;
using System.Collections.Generic;
using GameSateMachine;
using Global;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

namespace Gameplay
{
   public sealed class LevelCreator : ILevelCreator
   {
      public ICameraBounds CameraBounds { set => _cameraBounds ??= value; }
      public string Seed { set => _seed ??= value; }
      public Transform Parent { set => _parent ??= value; }
      public int CountInitChunk 
      {
         set { if (_countInitChunk == 0) _countInitChunk = value; }
      }

      private Chunk[] _prefabs;
      private List<IChunk> _activeChunks = new List<IChunk>();
      private ObjectPool _objectPool;
      private ICameraBounds _cameraBounds;
      private string _seed;
      private Random _randomHash;
      private int _countInitChunk;
      private Transform _parent;
      private PlayerStats _playerStats;
      private GameState _gameState;

      [Inject]
      private void Constructor(Chunk[] prefabs, PlayerStats playerStats, 
         ObjectPool objectPool, GameState gameState)
      {
         _gameState = gameState;
         _objectPool = objectPool;
         _playerStats = playerStats;
         _prefabs = prefabs;
      }

      public void SpawnInitialChunks()
      {
         _randomHash = new Random(_seed.GetHashCode());
      
         var position = new Vector3(_cameraBounds.LeftBorder.x - 1, 0, 0);
         for (var index = 0; index < _countInitChunk; index++)
         {
            var randomValue = 0;
            if (index != 0)
            {
               randomValue = _randomHash.Next(0, _prefabs.Length);
               position = _activeChunks[index - 1].RightBorder.position;
            }
            var chunk =  Spawn(randomValue, position);
            _activeChunks.Add(chunk);
            if (index == 0) SetIsFirst();
         }
      }

      public void SpawnChunk()
      {
         var position = _activeChunks[_activeChunks.Count - 1].RightBorder.position;
         var randomValue = _randomHash.Next(0, _prefabs.Length);
         var chunk = CheckTransfer(randomValue) is {} ? Transfer(randomValue, position) : Spawn(randomValue, position);
         _activeChunks.Remove(_activeChunks[0]);
         _activeChunks.Add(chunk);
         SetIsFirst();
      }

      private Chunk Spawn(int id, Vector3 position)
      {
         var result = Object.Instantiate(_prefabs[id], position, Quaternion.identity, _parent);
         result.Id = id;
         result.Creator = this;
         result.Stats = _playerStats;
         result.Pool = _objectPool;
         result.State = _gameState;
         result.CameraBounds = _cameraBounds;
         return result;
      }

      private Chunk CheckTransfer(int id)
      {
         var result = _objectPool.CheckTakeChunk(id);
         return result;
      }

      private Chunk Transfer(int id, Vector3 position)
      {
         var result = _objectPool.TakeChunk(id, position);
         return result;
      }

      private void SetIsFirst()
      {
         _activeChunks[0].IsFirst = true;
      }
   }
}
