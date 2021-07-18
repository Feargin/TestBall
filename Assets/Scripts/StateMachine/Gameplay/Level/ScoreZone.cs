using UnityEngine;
using Zenject;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 1;
    private PlayerStats _playerStats;
    [Inject]
    private void Constructor(PlayerStats playerStats)
    {
        _playerStats = playerStats;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Ball>()) _playerStats.StatChange(TypeStats.Score, _scoreValue);
    }
}
