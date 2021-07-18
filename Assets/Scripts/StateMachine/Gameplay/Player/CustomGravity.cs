using UnityEngine;

public class CustomGravity
{
    private int _gravityScale;

    public int GravityScale
    {
        set 
        {
            if (_gravityScale == 0) _gravityScale = value;
        }
    }
    public Rigidbody BallRigibody
    {
        get => _ballRigibody;
        set { _ballRigibody ??= value; }
    }
    private Rigidbody _ballRigibody;

    public void CalculateGravity()
    {
        _ballRigibody.AddForce(new Vector3(0, _gravityScale, 0), ForceMode.Force);
    }

    public void InvertGravity()
    {
        _gravityScale *= -1;
    }
    
}
