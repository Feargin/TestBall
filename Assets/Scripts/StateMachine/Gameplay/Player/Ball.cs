using NaughtyAttributes;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    private BallColision _ballColision;
    private CustomGravity _customGravity;
    private Rigidbody _rigidbody;
    private Animator _animator;
    
    [InfoBox("The force of the influence of gravity (mass is taken into account).", EInfoBoxType.Normal)]
    [HorizontalLine(color: EColor.Green)]
    [SerializeField, Range(5, 25)] 
    private int _gravityScale = 15;

    [Zenject.Inject]
    private void Constructor(BallColision ballColision, CustomGravity customGravity, 
        Animator animator, Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
        _ballColision = ballColision;
        _customGravity = customGravity;
        _customGravity.BallRigibody = _rigidbody;
        _animator = animator;
    }

    public void InvertGravity()
    {
        _customGravity.GravityScale = _gravityScale;
        _customGravity.InvertGravity();
    }

    private void FixedUpdate()
    {
        _customGravity.CalculateGravity();
    }
}
