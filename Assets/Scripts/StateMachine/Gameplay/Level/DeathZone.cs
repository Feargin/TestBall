using GameSateMachine;
using NaughtyAttributes;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [HorizontalLine(color: EColor.Red)]
    [Foldout("For developers only!")]
    [SerializeField] private Chunk _chunk;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Ball>()) _chunk.State.Machine.SetState(TypeStates.EndGame);
    }
}
