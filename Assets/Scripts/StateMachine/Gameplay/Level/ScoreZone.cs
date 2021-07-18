using NaughtyAttributes;
using UnityEngine;
using Zenject;

public class ScoreZone : MonoBehaviour
{
    [HorizontalLine(color: EColor.Green)]
    [Header("For the paws of a game designer.")]
    [SerializeField] private int _scoreValue = 1;
    [HorizontalLine(color: EColor.Red)]
    [Foldout("For developers only!")]
    [SerializeField] private Chunk _chunk;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            _chunk.Stats.StatChange(TypeStats.Score, _scoreValue);
        }
    }
}
