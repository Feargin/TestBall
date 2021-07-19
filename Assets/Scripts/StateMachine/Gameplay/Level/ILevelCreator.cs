using UnityEngine;

namespace Gameplay
{
    public interface ILevelCreator
    {
        public ICameraBounds CameraBounds { set; }
        public string Seed { set; }
        public Transform Parent { set; }
        public int CountInitChunk { set; }
    }
}