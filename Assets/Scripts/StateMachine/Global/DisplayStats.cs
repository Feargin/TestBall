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
            switch (type)
            {
                case TypeStats.Score:
                    print(_score.text);
                    _score.text = "" + (int.Parse(_score.text) + value);
                    break;
                case TypeStats.Other:
                    throw new Exception("Invalid type!");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
