using UnityEngine;

public class BallWinCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")) {
            if(!other.GetComponent<BallOutOfTheCube>().BallInFlask) {
                other.GetComponent<BallOutOfTheCube>().BallInFlask = true;
                FindObjectOfType<WinLoseManager>().WinBall();
            }
        }
    }
}
