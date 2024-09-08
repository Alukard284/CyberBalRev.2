using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameManager _gameManager;
    public float timer = 90;
    public bool active = true;
    
    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (active)
        { 
            timerText.text = timer.ToString("0");
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
           _gameManager.GameOver();
        }
    }
}
