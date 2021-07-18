using UnityEngine;

public class LevelMovement
{
    public void Move(Rigidbody rigidbody, float speed)
    {
        rigidbody.AddForce(new Vector3(speed *- 1, 0, 0));
    }
}
