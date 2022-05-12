using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private int _amountOfBalls;
    private WaitForSeconds _spawnWaitForSeconds;
    [SerializeField] private float _spawnWaitingTime = 0.1f;
    [SerializeField] private GameObject _ballPrefab;

    [Header("Choose various colors for the balls")]
    [SerializeField] private Color[] _ballColors;

    private void Awake() {
        _spawnWaitForSeconds = new WaitForSeconds(_spawnWaitingTime);
    }

    void Start()
    {
        _amountOfBalls = FindObjectOfType<LevelManager>().CurrentLevelProperties.AmountOfBalls;
    }

    private void OnEnable() {
        LevelManager.LevelStart += LevelStart_StartSpawning;
    }

    private void OnDisable() {
        LevelManager.LevelStart -= LevelStart_StartSpawning;
    }

    private void LevelStart_StartSpawning() {
        Transform spawnPositionTransform = GameObject.FindGameObjectWithTag("Tube").transform.Find("SpawnPosition");
        StartCoroutine(SpawnBalls(spawnPositionTransform));
    }

    private IEnumerator SpawnBalls(Transform spawnPositionTransform) {
        for(int i=0;i<_amountOfBalls;++i) {
            SpawnBall(spawnPositionTransform);
            GenericAudioManager.Instance.PlaySfx("SpawnBall");
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void SpawnBall(Transform spawnPositionTransform) {
        GameObject ballGO = Instantiate(_ballPrefab, spawnPositionTransform.position, Quaternion.identity, spawnPositionTransform.parent);
        ballGO.GetComponent<Renderer>().materials[0].color = _ballColors[Random.Range(0,_ballColors.Length)];
    }
}
