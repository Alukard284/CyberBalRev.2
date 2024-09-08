using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private Coroutine startCoroutine;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private FadeScreen _fadeScreen;
    private Animator _animator;
    [SerializeField] private GameObject _camera;
    private int _scenes;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _scenes = SceneManager.sceneCountInBuildSettings;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex <= _scenes -1)
            {
                other.gameObject.SetActive(false);
                _camera.SetActive(false);
                startCoroutine = StartCoroutine(NextLevel());
            }
        }
    }

    private IEnumerator NextLevel()
    {
        _animator.SetBool("Active", true);
        yield return new WaitForSeconds(4f);
        _gameManager.Win();
        yield return new WaitForSeconds(2f);

        if (SceneManager.GetActiveScene().buildIndex >= _scenes - 1)
        {
            yield return new WaitForSeconds(2f);
            _fadeScreen.timerText.text = "YOU WIN";
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
