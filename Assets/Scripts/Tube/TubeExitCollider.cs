using UnityEngine;

public class TubeExitCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")) {
            other.transform.parent = null;
            if(!other.GetComponent<BallOutOfTheCube>().BallLeftTheTube) {
                other.GetComponent<BallOutOfTheCube>().BallLeftTheTube = true;
                FindObjectOfType<WinLoseManager>().BallLeftTheTube();
            }
                
        }
    }
}
