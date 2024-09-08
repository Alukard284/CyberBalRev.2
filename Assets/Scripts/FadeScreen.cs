using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] Image gameScreeneBackGround;
    [SerializeField] float fade_Speed = 0.5f;
    [SerializeField] public TextMeshProUGUI timerText;
    private Color fade_Color;

    public IEnumerator ScreenFade()
    {
        while (fade_Color.a < 1f)
        {
            fade_Color.a += fade_Speed * Time.deltaTime;
            gameScreeneBackGround.color = fade_Color;
            yield return null;
        }
    }
}
