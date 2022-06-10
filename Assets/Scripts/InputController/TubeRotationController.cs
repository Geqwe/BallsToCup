using UnityEngine;

public class TubeRotationController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10f;

    private Transform _tubeTransform;
    private Vector3 _startingMousePos;
    private Camera _cam;

    private const float X_THRESHOLD = 0f, Y_THRESHOLD = 3f;

    private void Start() {
        _tubeTransform = GameObject.FindGameObjectWithTag("Tube").transform;
        _cam = Camera.main;
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _startingMousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0)) {
            RotateTube();
        }
    }

    private void RotateTube() {
        float rotX = Input.GetAxis("Mouse X") * _rotationSpeed * Time.fixedDeltaTime * Mathf.Rad2Deg;
        float rotY = Input.GetAxis("Mouse Y") * _rotationSpeed * Time.fixedDeltaTime * Mathf.Rad2Deg;

        if (_startingMousePos.y > Y_THRESHOLD)
            rotX = -rotX;
        if (_startingMousePos.x < X_THRESHOLD)
            rotY = -rotY;

        _tubeTransform.Rotate(Vector3.forward, rotX);
        _tubeTransform.Rotate(Vector3.forward, rotY);
    }
}
