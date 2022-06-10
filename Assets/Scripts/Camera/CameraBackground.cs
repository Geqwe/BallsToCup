using UnityEngine;

public class CameraBackground : MonoBehaviour
{
    private LevelManager _levelManager;
    private Camera _cam;

    void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        _levelManager = FindObjectOfType<LevelManager>();

        _levelManager.LevelInitialize += OnInitializeLevel;
    }

    private void OnDisable()
    {
        _levelManager.LevelInitialize -= OnInitializeLevel;
    }

    private void OnInitializeLevel()
    {
        _cam.backgroundColor = _levelManager.CurrentLevelProperties.BackgroundColor;
    }
}
