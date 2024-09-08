using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CountDownTimer _countdownTimer;
    [SerializeField] private FadeScreen _fadeScreen;
    [SerializeField] private GameObject _restartButton;
    private Coroutine _coroutine;
    public void GameOver()
    {
        _countdownTimer.active = false;
        _coroutine = StartCoroutine(_fadeScreen.ScreenFade());
        _fadeScreen.timerText.color = Color.red;
        _fadeScreen.timerText.text = "GameOver";
        _restartButton.SetActive(true);
    }

    public void Win()
    {
        _countdownTimer.active = false;
        _coroutine = StartCoroutine(_fadeScreen.ScreenFade());
        _fadeScreen.timerText.text = "Misson Complite";
    }
}
