using UnityEngine;
using System;

namespace Ball {
    public class BallWinCollider : MonoBehaviour
    {
        private bool _ballInFlask;
        public static event Action BallWon;

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.CompareTag("BallWin")) {
                if(!_ballInFlask) {
                    _ballInFlask = true;
                    BallWon?.Invoke();
                }
            }
        }
    }
}
