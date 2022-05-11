using UnityEngine;

public class TubeRotationController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10f;
    
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            float rotX = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime * Mathf.Rad2Deg;
            float rotY = Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime * Mathf.Rad2Deg;

            transform.Rotate(Vector3.forward, rotX);
        }
    }
}
