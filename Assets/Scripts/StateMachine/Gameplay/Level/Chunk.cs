using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public TypeChunk Type => _type;
    public int Id
    {
        get => _id;
        set { if (_id < 0) _id = value; }
    }
    public float Speed
    {
        set { if (_speed == 0) _speed = value; }
    }
    public CameraBounds CameraBounds { set => _cameraBounds ??= value; }
    public bool IsFirst { set { if (!_isFirst) _isFirst = value; } }
    public ObjectPool Pool { set => _objectPool ??= value; }
    public Transform RightBorder => _rightBorder;
    public LevelCreator Creator { set => _creator ??= value; }
    
    [HorizontalLine(color: EColor.Green)]
    [Header("For the paws of a game designer.")]
    [SerializeField] private TypeChunk _type;
    [HorizontalLine(color: EColor.Red)]
    [Foldout("For developers only!")][SerializeField] private Transform _rightBorder;
    private int _id = -1;
    private CameraBounds _cameraBounds;
    private bool _isFirst;
    private ObjectPool _objectPool;
    private LevelCreator _creator;
    private LevelMovement _levelMovement = new LevelMovement();
    private Rigidbody _rigidbody;
    private float _speed;


    private void OnEnable() => StartCoroutine(StartCheck());

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _levelMovement.Move(_rigidbody, _speed);
    }

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
        if (!(_rightBorder.position.x < _cameraBounds.LeftBorder.x - 2)) return;
        _objectPool.AddChank(this);
        _creator.SpawnChunk();
        gameObject.SetActive(false);
    }
}

public enum TypeChunk
{
    Small,
    Medium,
    Long,
}
