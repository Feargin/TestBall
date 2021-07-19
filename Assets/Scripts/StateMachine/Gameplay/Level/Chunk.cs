using System.Collections;
using GameSateMachine;
using Global;
using NaughtyAttributes;
using UnityEngine;

namespace Gameplay
{
    public sealed class Chunk : MonoBehaviour, IChunk
    {
        public TypeChunk Type => _type;
        public int Id
        {
            get => _id;
            set { if (_id < 0) _id = value; }
        }
        public PlayerStats Stats { get; set; }
        public GameState State { get; set; }
        public ICameraBounds CameraBounds { set => _cameraBounds ??= value; }
        public bool IsFirst { set { if (!_isFirst) _isFirst = value; } }
        public ObjectPool Pool { set => _objectPool ??= value; }
        public Transform RightBorder => _rightBorder;
        public LevelCreator Creator { set => _creator ??= value; }
    
        [HorizontalLine(color: EColor.Green)]
        [Header("For the paws of a game designer.")]
        [SerializeField] private TypeChunk _type;
        [HorizontalLine(color: EColor.Red)]
        [Foldout("For developers only!")]
        [SerializeField] private Transform _rightBorder;
        private int _id = -1;
        private ICameraBounds _cameraBounds;
        private bool _isFirst;
        private ObjectPool _objectPool;
        private LevelCreator _creator;


        private void OnEnable() => StartCoroutine(StartCheck());

        private IEnumerator StartCheck()
        {
            while (true)
            {
                if(_isFirst) CheckLevelBounds();
                yield return new WaitForSeconds(0.2f);
            }
        }

        private void CheckLevelBounds()
        {
            if (!(_rightBorder.position.x < _cameraBounds.LeftBorder.x - 4)) return;
            gameObject.SetActive(false);
            _objectPool.AddChank(this);
            _creator.SpawnChunk();
        }
    }

    public enum TypeChunk
    {
        Small,
        Medium,
        Long,
    }
}