using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using Ball;
using Audio;

public class WinLoseManager : MonoBehaviour
{
    private int _startingAmountOfBalls, _amountOfBallsNeededToWin, _ballsWon;
    private bool _won;

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
        BallOutOfTube.BallLeftTheCube += OnBallLeftTheTube;
        BallWinCollider.BallWon += OnBallWon;
    }

    private void OnDisable() {
        BallOutOfTube.BallLeftTheCube -= OnBallLeftTheTube;
        BallWinCollider.BallWon -= OnBallWon;
    }

    private void OnBallLeftTheTube() {
        if(--_startingAmountOfBalls == 0) {
            StartCoroutine(CheckLoseAfterTime());
        }
    }

    private IEnumerator CheckLoseAfterTime() {
        yield return new WaitForSeconds(3f);
        if(!_won) {
            Lose();
        }
    }

    private void Lose() {
        LoseEvent?.Invoke();
        GenericAudioManager.Instance.PlaySfx("Lose");
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
