using UnityEngine;

public class BallCheckOutOfScene : MonoBehaviour
{
    private const float DESTROY_BALL_THRESHOLD = -20f;
    void Update()
    {
        if(transform.position.y <= DESTROY_BALL_THRESHOLD) {
            Destroy(gameObject);
        }
    }
}