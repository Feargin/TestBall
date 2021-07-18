using System.Collections.Generic;
using System.Linq;

public class ObjectPool
{
    private List<Chunk> _chunksPool;

    public void AddChank(Chunk chunk)
    {
        _chunksPool.Add(chunk);
    }

    public Chunk TakeChunk(int id)
    {
        Chunk result = null;
        foreach (var chunk in _chunksPool.Where(chunk => chunk.Id == id)) { result = chunk; }
        return result;
    }

}
