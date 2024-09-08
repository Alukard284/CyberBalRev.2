using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform m_Camera;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 10, -10);
    
    void Start()
    {
        m_Camera = GetComponent<Transform>();
    }

    void Update()
    {
        CameraFalow();
    }

    private void CameraFalow() 
    {
        m_Camera.position = targetTransform.position + cameraOffset;
    }

}
