using UnityEngine;

public class TimeChardger : MonoBehaviour
{
    [SerializeField] private float _timeChardge;
    [SerializeField] private CountDownTimer _countdownTimer;
    private bool _isActive;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !_isActive)
        {
            _countdownTimer.timer += _timeChardge;
            _isActive = true;
        }
    }
}
