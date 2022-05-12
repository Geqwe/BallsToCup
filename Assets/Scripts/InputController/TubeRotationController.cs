using UnityEngine;

public class TubeRotationController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10f;
    private Transform _tubeTransform;

    private void Start() {
        _tubeTransform = GameObject.FindGameObjectWithTag("Tube").transform;
    }
    
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            float rotX = Input.GetAxis("Mouse X") * _rotationSpeed * Time.fixedDeltaTime * Mathf.Rad2Deg;
            float rotY = Input.GetAxis("Mouse Y") * _rotationSpeed * Time.fixedDeltaTime * Mathf.Rad2Deg;

            _tubeTransform.Rotate(Vector3.forward, rotX);
        }
    }
}
