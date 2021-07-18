using UnityEngine;

public class LevelMovement
{
    public void Move(Rigidbody rigidbody, float speed, Vector3 currentPosition)
    {
        rigidbody.MovePosition(new Vector3(speed *- 1, 0, 0) * Time.deltaTime + currentPosition);
    }
}
