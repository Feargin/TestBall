using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
    private Ball _ball;

    [Inject]
    private void Constructor(Ball ball)
    {
        _ball = ball;
    }
    
    public void PlayerInteraction()
    {
        _ball.InvertGravity();
    }
}
