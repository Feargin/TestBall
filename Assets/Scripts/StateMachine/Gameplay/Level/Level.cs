using NaughtyAttributes;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        private LevelCreator _levelCreator;
        private CameraBounds _cameraBounds;
        private Rigidbody _rigidbody;
        private LevelMovement _levelMovement;

        [HorizontalLine(color: EColor.Green)]
        [Header("For the paws of a game designer.")]
        [SerializeField] private string _seed;
        [InfoBox("The number of active chunks on the scene.", EInfoBoxType.Normal)]
        [SerializeField, Range(4, 16)] private int CountInitChunk;
        [InfoBox("Level movement speed.", EInfoBoxType.Normal)]
        [SerializeField, Range(0.5f, 4f)] private float _speed = 1f;

        [Inject]
        private void Constructor(LevelCreator levelCreator, 
            LevelMovement levelMovement, CameraBounds cameraBounds)
        {
            _cameraBounds = cameraBounds;
            _levelMovement = levelMovement;
            _levelCreator = levelCreator;
            _levelCreator.CameraBounds = _cameraBounds;
            _levelCreator.Seed = _seed;
            _levelCreator.Parent = transform;
            _levelCreator.CountInitChunk = CountInitChunk;
        }

        private void Start()
        {
            _seed ??= "" + Random.Range(-999f, 999f);
            _cameraBounds.InitBorders();
            _levelCreator.SpawnInitialChunks();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _levelMovement.Move(_rigidbody, _speed, transform.position);
        }
    }
}
