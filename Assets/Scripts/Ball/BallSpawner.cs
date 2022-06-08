using System.Collections;
using UnityEngine;
using Audio;

namespace Ball {
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] protected GameObject _ballPrefab;
        private LevelManager _levelManager;

        
        [Header("Interval between every ball spawn")]
        [SerializeField] private float _spawnWaitingTime = 0.1f;
        private WaitForSeconds _spawnWaitForSeconds;


        [Header("Choose various colors for the balls")]
        [SerializeField] protected Color[] _ballColors;

        private void Awake() {
            _spawnWaitForSeconds = new WaitForSeconds(_spawnWaitingTime);
        }

        private void Start() {
            _levelManager = FindObjectOfType<LevelManager>();
        }

        private void OnEnable() {
            LevelManager.LevelStart += OnLevelStart_StartSpawning;
        }

        private void OnDisable() {
            LevelManager.LevelStart -= OnLevelStart_StartSpawning;
        }

        private void OnLevelStart_StartSpawning() {
            Transform spawnPositionTransform = GameObject.FindGameObjectWithTag("Tube").transform.Find("SpawnPosition");
            StartCoroutine(SpawnBalls(spawnPositionTransform));
        }

        private IEnumerator SpawnBalls(Transform spawnPositionTransform) {
            int amountOfBalls = _levelManager.CurrentLevelProperties.AmountOfBalls;

            for(int i=0;i<amountOfBalls;++i) {
                SpawnBall(spawnPositionTransform);
                GenericAudioManager.Instance.PlaySfx("SpawnBall");
                yield return _spawnWaitForSeconds;
            }
        }

        private void SpawnBall(Transform spawnPositionTransform) {
            GameObject ballGO = Instantiate(_ballPrefab, spawnPositionTransform.position + new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),0f), Quaternion.identity, spawnPositionTransform.parent);
            ballGO.GetComponent<SpriteRenderer>().color = _ballColors[Random.Range(0,_ballColors.Length)];
        }
    }
}