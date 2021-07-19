using GameSateMachine;
using Global;
using UnityEngine;

namespace Gameplay
{
    public interface IChunk
    {
        public TypeChunk Type { get; }
        public int Id { get; set; }
        public PlayerStats Stats { get; set; }
        public GameState State { get; set; }
        public ICameraBounds CameraBounds { set; }
        public bool IsFirst { set; }
        public ObjectPool Pool { set; }
        public Transform RightBorder { get; }
        public LevelCreator Creator { set; }
    }
}