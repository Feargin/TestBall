using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class LevelCreator
{
   public ObjectPool Pool { set => _objectPool ??= value; }
   public CameraBounds CameraBounds { set => _cameraBounds ??= value; }
   public string Seed { set => _seed ??= value; }
   public Transform Parent { set => _parent ??= value; }
   public int CountInitChunk 
   {
      set { if (_countInitChunk != 0) _countInitChunk = value; }
   }
   public float Speed
   {
      set { if (_speed != 0) _speed = value; }
   }
   
   private Chunk[] _prefabs;
   private Queue<Chunk> _activeChunks;
   private ObjectPool _objectPool;
   private CameraBounds _cameraBounds;
   private string _seed;
   private Random _randomHash;
   private int _countInitChunk;
   private Transform _parent;
   private Chunk _finiteChunk;
   private float _speed;

   [Inject]
   private void Constructor(Chunk[] prefabs)
   {
      _prefabs = prefabs;
   }

   public void SpawnInitialChunks()
   {
      _randomHash = new Random(_seed.GetHashCode());
      var randomValue = _randomHash.Next(0, _prefabs.Length);
      var position = new Vector3(_cameraBounds.LeftBorder.x - 1, 0, 0);
      for (var index = 0; index < _countInitChunk; index++)
      {
         var chunk =  Spawn(randomValue, position);
         if (index == 0) SetIsFirst();
         if (index == _countInitChunk - 1) _finiteChunk = chunk;
      }
   }

   public void SpawnChunk()
   {
      var position = _finiteChunk.RightBorder.position;
      var randomValue = _randomHash.Next(0, _prefabs.Length);
      var chunk = Transfer(randomValue) is {} ? Transfer(randomValue) : Spawn(randomValue, position);
      _activeChunks.Dequeue();
      SetIsFirst();
      _finiteChunk = chunk;
   }

   private Chunk Spawn(int id, Vector3 position)
   {
      var result = GameObject.Instantiate(_prefabs[id], position, Quaternion.identity, _parent);
      _activeChunks.Enqueue(result);
      result.Id = id;
      result.Creator = this;
      result.Pool = _objectPool;
      result.CameraBounds = _cameraBounds;
      result.Speed = _speed;
      return result;
   }

   private Chunk Transfer(int id)
   {
      var result = _objectPool.TakeChunk(id);
      return result;
   }

   private void SetIsFirst()
   {
      var firstChunk = _activeChunks.Peek();
      firstChunk.IsFirst = true;
   }

}
