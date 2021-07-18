using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class LevelCreator
{
   public ObjectPool Pool { set => _objectPool ??= value; }
   public CameraBounds CameraBounds { set => _cameraBounds ??= value; }
   public string Seed { set => _seed ??= value; }
   
   private Chunk[] _prefabs;
   private Queue<Chunk> _activeChunks;
   private ObjectPool _objectPool;
   private CameraBounds _cameraBounds;
   private string _seed;
   private Random _randomHash;

   [Inject]
   private void Constructor(Chunk[] prefabs)
   {
      _prefabs = prefabs;
   }

   private void SpawnInitialChunks()
   {
      _randomHash = new Random(_seed.GetHashCode());
      var randomValue = _randomHash.Next(0, _prefabs.Length);
      
   }
   
}
