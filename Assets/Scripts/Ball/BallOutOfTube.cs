using UnityEngine;
using System;

namespace Ball {
    public class BallOutOfTube : MonoBehaviour
    {
        private bool _ballLeftTheTube;

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.CompareTag("TubeExit")) {
                transform.parent = null;
                if(!_ballLeftTheTube) {
                    _ballLeftTheTube = true;
                }
            }
        }
    }
}
