using System.Linq;
using UnityEngine;

public class SwitchEmission : MonoBehaviour
{
    [SerializeField] private string targetMaterialName;
    [SerializeField] private Material emissionMaterial;
    private Material[] materials;
    private Color _yellow = Color.yellow;

    // Start is called before the first frame update
    void Start()
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            emissionMaterial.SetColor("_EmissionColor", _yellow);
            emissionMaterial.SetColor("_Color", _yellow);
        }
    }
}
