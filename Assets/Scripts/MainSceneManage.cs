using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManage : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject aboutTheAuthorButton;

    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject aboutAboutScreen;

    public void MainMenuButton()
    {
        mainMenuButton.SetActive(false);
        startButton.SetActive(true);
        aboutTheAuthorButton.SetActive(true);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AboutTheAuthorButton()
    {
        mainMenuScreen.SetActive(false);
        aboutAboutScreen.SetActive(true);
    }

    public void ReturnButton()
    {
        aboutAboutScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
