using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Global
{
    public sealed class DisplayStats : MonoBehaviour
    {
        private TMP_Text _score;
        private PlayerStats _stats;

        [Inject]
        private void Constructor(TMP_Text score, PlayerStats stats)
        {
            _score = score;
            _stats = stats;
        }

        private void OnEnable() => _stats.OnStatChange += SetStats;
        private void OnDisable() => _stats.OnStatChange -= SetStats;
    
        private void SetStats(TypeStats type, int value)
        {
            _score.text = type switch
            {
                TypeStats.Score => "" + (int.Parse(_score.text) + value),
                TypeStats.Other => throw new Exception("Invalid type!"),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
