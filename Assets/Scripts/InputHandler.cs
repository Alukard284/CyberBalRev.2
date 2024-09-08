using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private MovementHandler m_movementHandler;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public Vector2 GetTouchDeltaPosition()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).deltaPosition;
        }
        return Vector2.zero;
    }

    public bool IsThereTouchOnScreen()
    {
        if (Input.touchCount > 0) return true;
        else return false;
        
    }

    public void Tap()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;
            }
            if (endTouchPosition == startTouchPosition)
            {
                m_movementHandler.Push(true);
            }
            else { m_movementHandler.Push(false);}
        }
    }
    private void Update()
    {
        Tap();
    }
}
