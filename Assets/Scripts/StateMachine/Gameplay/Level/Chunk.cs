using System;
using System.Collections;
using GameSateMachine;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public TypeChunk Type => _type;
    public int Id
    {
        get => _id;
        set { if (_id < 0) _id = value; }
    }
    public PlayerStats Stats { get; set; }
    public GameState State { get; set; }
    public CameraBounds CameraBounds { set => _cameraBounds ??= value; }
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
    private CameraBounds _cameraBounds;
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
