using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelProperties[] _levelProperties;
    public LevelProperties CurrentLevelProperties;
    public static event Action LevelStart;
    private UiManager _uiManager;

    void Awake()
    {
        InitializeLevel();
    }

    private void InitializeLevel() {
        CurrentLevelProperties = _levelProperties[PlayerPrefs.GetInt("Level",0)];
        Instantiate(CurrentLevelProperties.TubePrefab, CurrentLevelProperties.TubePosition, Quaternion.identity);
    }

    private void OnEnable() {
        _uiManager = FindObjectOfType<UiManager>();
        
        _uiManager.StartLevelEvent.AddListener(OnStartLevel);
        _uiManager.NextLevelEvent += OnNextLevel;
        _uiManager.RestartLevelEvent += OnRestartScene;
    }

    private void OnDisable() {
        _uiManager.StartLevelEvent.RemoveListener(OnStartLevel);
        _uiManager.NextLevelEvent -= OnNextLevel;
        _uiManager.RestartLevelEvent -= OnRestartScene;
    }

    private void OnStartLevel() {
        LevelStart?.Invoke();
    }

    private void OnNextLevel() {
        int levelIndex = PlayerPrefs.GetInt("Level",0);

        if(levelIndex==_levelProperties.Length-1) { //at the end of the levels go back to the start for now
            levelIndex = 0;
            PlayerPrefs.SetInt("Level",levelIndex);
        }
        else {
            PlayerPrefs.SetInt("Level",++levelIndex);
        }

        OnRestartScene();
    }

    private void OnRestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
