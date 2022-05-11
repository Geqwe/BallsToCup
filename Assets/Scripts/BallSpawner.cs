using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public int AmountOfBalls;
    private WaitForSeconds _spawnWaitForSeconds;
    [SerializeField] private float _spawnWaitingTime = 0.1f;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Color[] _ballColors;

    private void Awake() {
        _spawnWaitForSeconds = new WaitForSeconds(_spawnWaitingTime);
    }

    void Start()
    {
        Transform spawnPositionTransform = GameObject.FindGameObjectWithTag("Tube").transform.Find("SpawnPosition");
        StartCoroutine(SpawnBalls(spawnPositionTransform));
    }

    private IEnumerator SpawnBalls(Transform spawnPositionTransform) {
        for(int i=0;i<AmountOfBalls;++i) {
            SpawnBall(spawnPositionTransform);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void SpawnBall(Transform spawnPositionTransform) {
        GameObject ballGO = Instantiate(_ballPrefab, spawnPositionTransform.position, Quaternion.identity, spawnPositionTransform.parent);
        ballGO.GetComponent<Renderer>().materials[0].color = _ballColors[Random.Range(0,_ballColors.Length)];
    }
}
