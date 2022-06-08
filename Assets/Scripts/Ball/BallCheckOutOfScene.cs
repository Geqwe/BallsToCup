using UnityEngine;

namespace Ball {
    public class BallCheckOutOfScene : MonoBehaviour
    {
        private const float DESTROY_BALL_THRESHOLD = -20f; //if out of the scene destroy it
        
        void Update()
        {
            if(transform.position.y <= DESTROY_BALL_THRESHOLD) {
                Destroy(gameObject);
            }
        }
    }
}
