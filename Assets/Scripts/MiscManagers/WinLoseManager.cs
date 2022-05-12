using UnityEngine;
using System.Collections;
using TMPro;

public class WinLoseManager : MonoBehaviour
{
    private int _startingAmountOfBalls;
    private int _amountOfBallsNeededToWin;
    private int _ballsWon;
    private bool _won;

    [SerializeField] private GameObject _loseScreen, _winScreen;
    [SerializeField] private TMP_Text _ballsLeftText;

    void Start()
    {
        _startingAmountOfBalls = FindObjectOfType<LevelManager>().CurrentLevelProperties.AmountOfBalls;
        Debug.Log(_startingAmountOfBalls);
        _amountOfBallsNeededToWin = FindObjectOfType<LevelManager>().CurrentLevelProperties.AmountOfBallsNeededToWin;
        Debug.Log(_amountOfBallsNeededToWin);
        BallsTextUpdate();
    }

    public void BallLeftTheTube() {
        Debug.Log("lost ball");
        if(--_startingAmountOfBalls == 0) {
            StartCoroutine(CheckLoseAfterTime());
        }
        BallsTextUpdate();
    }

    private IEnumerator CheckLoseAfterTime() {
        yield return new WaitForSeconds(2f);
        if(!_won) {
            Lose();
        }
    }

    private void Lose() {
        _loseScreen.SetActive(true);
        GenericAudioManager.Instance.PlaySfx("Lose");
    }

    public void WinBall() {
        if(++_ballsWon == _amountOfBallsNeededToWin) {
            StartCoroutine(CheckWinAfterTime());
        }
        BallsTextUpdate();
        LeanTween.scale(_ballsLeftText.gameObject, transform.localScale * 1.2f, 0.5f).setEasePunch()
            .setOnComplete(() => _ballsLeftText.rectTransform.localScale = Vector3.one);
        GenericAudioManager.Instance.PlaySfx("AddedBall");
    }

    private IEnumerator CheckWinAfterTime() {
        yield return new WaitForSeconds(1f);
        _won = true;
        Win();
    }

    private void Win() {
        _winScreen.SetActive(true);
        GenericAudioManager.Instance.PlaySfx("Win");
    }

    private void BallsTextUpdate() {
        _ballsLeftText.text = _ballsWon+"/"+_amountOfBallsNeededToWin;
    }
}
