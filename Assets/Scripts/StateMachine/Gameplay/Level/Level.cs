using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    private LevelCreator _levelCreator;
    private LevelMovement _levelMovement;
    private CameraBounds _cameraBounds;
    [SerializeField] private string _seed = "" + Random.Range(-999f, 999f);

    [Inject]
    private void Constructor(LevelCreator levelCreator, 
        LevelMovement levelMovement, CameraBounds cameraBounds, ObjectPool objectPool)
    {
        _levelCreator = levelCreator;
        _levelCreator.Pool = objectPool;
        _levelCreator.CameraBounds = cameraBounds;
        _levelCreator.Seed = _seed;
        _levelMovement = levelMovement;
    }

    private void Start()
    {
        _cameraBounds.InitBorders();
    }
}
