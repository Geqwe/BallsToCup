using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelProperties[] _levelProperties;
    public LevelProperties CurrentLevelProperties;
    public static event Action LevelStart;

    void Awake()
    {
        InitializeLevel();
    }

    private void InitializeLevel() {
        CurrentLevelProperties = _levelProperties[PlayerPrefs.GetInt("Level",0)];
        Instantiate(CurrentLevelProperties.TubePrefab, CurrentLevelProperties.TubePosition, Quaternion.identity);
    }

    public void StartLevel() {
        LevelStart?.Invoke();
    }

    public void NextLevel() {
        int levelIndex = PlayerPrefs.GetInt("Level",0);

        if(levelIndex==_levelProperties.Length-1) { //at the end of the levels go back to the start for now
            levelIndex = 0;
            PlayerPrefs.SetInt("Level",levelIndex);
        }
        else {
            PlayerPrefs.SetInt("Level",++levelIndex);
        }

        RestartScene();
    }

    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
