using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _inputHandler;
    [SerializeField] private GameObject _moveHandler;
    [SerializeField] private string targetMaterialName;
    [SerializeField] private Material emissionMaterial;
    private Material[] materials;
    private Color _black = Color.black;
    private bool isAlive = true;
    private Coroutine gameOver;

    private void Start()
    {
        GetMaterials();
    }
    private void GetMaterials()
    {
        materials = GetComponent<Renderer>().materials;

        foreach (Material mat in materials)
        {

            if (mat.name == targetMaterialName)
            {
                emissionMaterial = mat;
            }
        }
    }
    private void Update()
    {
        Emission();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            _inputHandler.SetActive(false);
            _moveHandler.SetActive(false);
            isAlive = false;
            gameOver = StartCoroutine(GameOver());
            
        }
    }
    private void Emission()
    {
        if (!isAlive)
        {
            emissionMaterial.SetColor("_EmissionColor", Color.Lerp(emissionMaterial.color, _black, Time.deltaTime *2));
            emissionMaterial.SetColor("_Color", Color.Lerp(emissionMaterial.color, _black, Time.deltaTime *2));
        }
    }
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.5f);
        _gameManager.GameOver();
        yield return new WaitForSeconds(1.5f);
        _restartButton.SetActive(true);
    }
}

