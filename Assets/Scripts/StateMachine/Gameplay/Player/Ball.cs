using System;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Ball : MonoBehaviour
    {
        private CustomGravity _customGravity;
        private Rigidbody _rigidbody;

        [InfoBox("The force of the influence of gravity (mass is taken into account).", EInfoBoxType.Normal)]
        [HorizontalLine(color: EColor.Green)]
        [Header("For the paws of a game designer.")]
        [SerializeField, Range(5, 25)] 
        private int _gravityScale = 15;

        [Inject]
        private void Constructor(CustomGravity customGravity, 
            Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
            _customGravity = customGravity;
            _customGravity.BallRigibody = _rigidbody;
        }

        private void Start()
        {
            InvertGravity();
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
}
