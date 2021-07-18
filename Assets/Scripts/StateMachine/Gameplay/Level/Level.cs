using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Timeline;
using Zenject;

public class Level : MonoBehaviour
{
    private LevelCreator _levelCreator;
    private CameraBounds _cameraBounds;
    
    [HorizontalLine(color: EColor.Green)]
    [Header("For the paws of a game designer.")]
    [SerializeField] private string _seed;
    [InfoBox("The number of active chunks on the scene.", EInfoBoxType.Normal)]
    [SerializeField, Range(4, 16)] private int CountInitChunk;
    [InfoBox("Level movement speed.", EInfoBoxType.Normal)]
    [SerializeField, Range(0.5f, 4f)] private float _speed = 1f;

    [Inject]
    private void Constructor(LevelCreator levelCreator, 
         CameraBounds cameraBounds, ObjectPool objectPool)
    {
        _cameraBounds = cameraBounds;
        _levelCreator = levelCreator;
        _levelCreator.Pool = objectPool;
        _levelCreator.CameraBounds = _cameraBounds;
        _levelCreator.Seed = _seed;
        _levelCreator.Speed = _speed;
        _levelCreator.Parent = transform;
        _levelCreator.CountInitChunk = CountInitChunk;
    }

    private void Start()
    {
        if(_seed is null) _seed = "" + Random.Range(-999f, 999f);
        _cameraBounds.InitBorders();
        _levelCreator.SpawnInitialChunks();
    }
}
