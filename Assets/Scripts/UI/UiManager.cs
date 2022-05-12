using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject _dragToRotateDisplay, _ballsLeftText;

    public void HideDragToRotateUi() {
        _dragToRotateDisplay.SetActive(false);
        _ballsLeftText.SetActive(true);
        FindObjectOfType<LevelManager>().StartLevel();
    }

    public void NextLevel() {
        FindObjectOfType<LevelManager>().NextLevel();
    }

    public void RestartLevel() {
        FindObjectOfType<LevelManager>().RestartScene();
    }
}
