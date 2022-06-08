using UnityEngine;

public class PunchAndLoop : MonoBehaviour
{
    [SerializeField] private float _scaleToPump = 1.3f;
    [SerializeField] private float _time = 0.8f;

    private void Awake()
    {
        Vector3 scalePump = transform.localScale * _scaleToPump;
        LeanTween.scale(gameObject, scalePump*1.5f, _time).setEasePunch().setOnComplete(() =>
            LeanTween.scale(gameObject, scalePump, _time).setEaseInOutSine().setLoopPingPong()
        );
    }
}
