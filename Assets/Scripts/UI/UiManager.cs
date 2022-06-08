using UnityEngine;
using System;
using UnityEngine.Events;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _ballsLeftText;

    public UnityEvent StartLevelEvent;
    public event Action NextLevelEvent, RestartLevelEvent;
    
    private WinLoseManager _winLoseManager;

    private void OnEnable() {
        _winLoseManager = FindObjectOfType<WinLoseManager>();
        _winLoseManager.BallsTextUpdate += OnBallsTextUpdate;
    }

    private void OnDisable() {
       _winLoseManager.BallsTextUpdate -= OnBallsTextUpdate;
    }

    public void HideDragToRotateUi() {
        StartLevelEvent?.Invoke();
    }

    public void NextLevel() {
        NextLevelEvent?.Invoke();
    }

    public void RestartLevel() {
        RestartLevelEvent?.Invoke();
    }

    private void OnBallsTextUpdate(int ballsWon, int amountOfBallsNeededToWin) {
        _ballsLeftText.text = ballsWon+"/"+ballsWon;
        LeanTween.scale(_ballsLeftText.gameObject, transform.localScale * 1.2f, 0.5f).setEasePunch()
            .setOnComplete(() => _ballsLeftText.rectTransform.localScale = Vector3.one);
    }
}
