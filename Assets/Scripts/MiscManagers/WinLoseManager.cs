using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using Ball;
using Audio;

public class WinLoseManager : MonoBehaviour
{
    private int _startingAmountOfBalls, _amountOfBallsNeededToWin, _ballsWon, _ballsLost;
    private bool _won, _lost;

    public UnityEvent WinEvent, LoseEvent;
    public event Action<int,int> BallsTextUpdate;

    void Start()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();

        _startingAmountOfBalls = levelManager.CurrentLevelProperties.AmountOfBalls;
        _amountOfBallsNeededToWin = levelManager.CurrentLevelProperties.AmountOfBallsNeededToWin;

        BallsTextUpdate?.Invoke(_ballsWon, _amountOfBallsNeededToWin);
    }

    private void OnEnable() {
        BallWinCollider.BallWon += OnBallWon;
        BallCheckOutOfScene.BallOutOfScene += OnBallLost;
    }

    private void OnDisable() {
        BallWinCollider.BallWon -= OnBallWon;
        BallCheckOutOfScene.BallOutOfScene -= OnBallLost;
    }

    private void OnBallLost()
    {
        if (_lost)
            return;

        if ((_startingAmountOfBalls - (++_ballsLost)) < _amountOfBallsNeededToWin)
        {
            StartCoroutine(CheckLoseAfterTime());
        }
    }

    private IEnumerator CheckLoseAfterTime() {
        yield return new WaitForSeconds(1f);
        if(!_won) {
            Lose();
        }
    }

    private void Lose() {
        _lost = true;
        LoseEvent?.Invoke();
        GenericAudioManager.Instance.PlaySfx("Lose");
        StopAllCoroutines();
    }

    public void OnBallWon() {
        if(++_ballsWon == _amountOfBallsNeededToWin) {
            StartCoroutine(CheckWinAfterTime());
        }
        
        BallsTextUpdate?.Invoke(_ballsWon, _amountOfBallsNeededToWin);
        GenericAudioManager.Instance.PlaySfx("AddedBall");
    }

    private IEnumerator CheckWinAfterTime() {
        _won = true;
        yield return new WaitForSeconds(1f);
        Win();
    }

    private void Win() {
        WinEvent?.Invoke();
        GenericAudioManager.Instance.PlaySfx("Win");
    }
}
