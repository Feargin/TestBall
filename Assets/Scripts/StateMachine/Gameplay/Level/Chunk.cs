using System.Collections;
using UnityEngine;
using Zenject;

public class Chunk : MonoBehaviour
{
    public int Id
    {
        get => _id;
        set { if (_id < 0) _id = value; }
    }
    public CameraBounds CameraBounds { set => _cameraBounds ??= value; }
    public bool IsFirst { set { if (!_isFirst) _isFirst = value; } }
    public ObjectPool Pool { set => _objectPool ??= value; }

    private int _id = -1;
    private CameraBounds _cameraBounds;
    private bool _isFirst;
    private ObjectPool _objectPool;
    private Transform _rightBorder;

    [Inject]
    private void Constructor(Transform rightBorder)
    {
        _rightBorder = rightBorder;
    }
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
        if (!(_rightBorder.position.x < _cameraBounds.LeftBorder.x - 1f)) return;
        _objectPool.AddChank(this);
        gameObject.SetActive(false);
    }
}
