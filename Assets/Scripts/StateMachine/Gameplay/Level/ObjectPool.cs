using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class ObjectPool
    {
        private List<Chunk> _chunksPool = new List<Chunk>();

        public void AddChank(Chunk chunk)
        {
            _chunksPool.Add(chunk);
        }

        public Chunk CheckTakeChunk(int id)
        {
            Debug.Log("pool: " + _chunksPool.Count);
            Chunk result = null;
            foreach (var chunk in _chunksPool.Where(chunk => chunk.Id == id)) { result = chunk; }
            return result;
        }
        public Chunk TakeChunk(int id, Vector3 position)
        {
            Chunk result = null;
            foreach (var chunk in _chunksPool.Where(chunk => chunk.Id == id)) { result = chunk; }
            _chunksPool.Remove(result);
            if (result is null)
            {
                Debug.Log("Warning!");
                return null;
            };
            result.transform.position = position;
            result.gameObject.SetActive(true);
            return result;
        }
    }
}
