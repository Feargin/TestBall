using GameSateMachine;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private GameState _gameplay;
    [Zenject.Inject]
    private void Constructor(GameState gameplay)
    {
        _gameplay = gameplay;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Ball>()) _gameplay.Machine.SetState(TypeStates.EndGame);
    }
}
