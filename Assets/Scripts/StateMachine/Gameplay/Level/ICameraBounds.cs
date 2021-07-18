using UnityEngine;

public interface ICameraBounds
{
    public Vector3 LeftBorder { get; }
    public Vector3 RightBorder { get; }
    public void InitBorders();
}
