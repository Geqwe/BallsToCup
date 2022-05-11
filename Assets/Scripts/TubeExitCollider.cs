using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeExitCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ball")) {
            other.transform.parent = null;
        }
    }
}
