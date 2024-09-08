using UnityEngine;
using System.Linq;

public class EmissionControl : MonoBehaviour
{
    [SerializeField] private string targetMaterialName;
    [SerializeField] private Material emissionMaterial;
    private Material[] materials;
    private float intensivity;
    private Color _green = Color.green;
    private Color _white = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        GetChildMaterials();
    }

    // Update is called once per frame
    void Update()
    {
        Emission();
    }
    private void GetChildMaterials()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            materials = child.GetComponent<Renderer>().materials.ToArray();
        }

        foreach (Material mat in materials)
        {

            if (mat.name == targetMaterialName)
            {
                emissionMaterial = mat;
            }
        }
    }

    private void Emission()
    {
        intensivity = Mathf.PingPong(Time.time, 1f) / 200;
        
        emissionMaterial.SetColor("_EmissionColor", new Color(255f, 255f, 255f, 0) * intensivity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            emissionMaterial.SetColor("_EmissionColor", _green * intensivity);
            emissionMaterial.SetColor("_Color", _green);
        }
    }
}
