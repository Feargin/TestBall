using UnityEngine;
using Zenject;

public class CameraBounds : ICameraBounds
{
    public Vector3 LeftBorder => _leftBorder;
    public Vector3 RightBorder => _rightBorder;
    private Vector3 _leftBorder;
    private Vector3 _rightBorder;
    private Camera _camera;

    [Inject]
    private void Constructor(Camera camera)
    {
        _camera = camera;
    }
    
    public void InitBorders()
    {
        _leftBorder = _camera.ScreenPointToRay(new Vector3(0, 0, 0)).origin;
        _rightBorder = _camera.ScreenPointToRay(new Vector3(1, 0, 0)).origin;
    }
}
