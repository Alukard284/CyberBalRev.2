using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public InputHandler inputHandler;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    
    void Start()
    {
        if (inputHandler == null) Debug.LogError("input handler не назначен");
    }

    private void MoveDroid()
    {
        if (inputHandler.IsThereTouchOnScreen())
        {
            Vector2 currentDeltaPos = inputHandler.GetTouchDeltaPosition();
            currentDeltaPos = currentDeltaPos * speed;
            Vector3 moveDirection = new Vector3(currentDeltaPos.x, 0, currentDeltaPos.y);
            rb.AddForce(moveDirection, ForceMode.Force);
        }
    }

    public void Push(bool push)
    {
        if (push)
        {
            Debug.Log("PUSH");
        }
    }
    // Update is called once per frame
    void Update()
    {
        MoveDroid();
    }
}
