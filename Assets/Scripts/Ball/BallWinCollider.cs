using UnityEngine;

public class BallWinCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")) {
            FindObjectOfType<WinLoseManager>().WinBall();
        }
    }
}
