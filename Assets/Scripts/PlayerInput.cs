using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Vector2 touchDistance;
    private const float swipeMinDistance = 50;
    private float startTimer;

    public enum Direction { Left, Rigth, Up, Down}
    bool[] swipe = new bool[4];


    void Update()
    {
        InputControl();
    }

    private void InputControl()
    {
        if (Input.touchCount > 0)
        {
            #region Swipe
            touchDistance = Vector2.zero;
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                touchDistance = endTouchPosition - startTouchPosition;
            }

            if (touchDistance.magnitude > swipeMinDistance)
            {
                if (Mathf.Abs(touchDistance.x) > Mathf.Abs(touchDistance.y))
                {
                    swipe[(int)Direction.Left] = touchDistance.x < 0;
                    swipe[(int)Direction.Rigth] = touchDistance.x > 0;
                }
                else 
                {
                    swipe[(int)Direction.Down] = touchDistance.y < 0;
                    swipe[(int)Direction.Up] = touchDistance.y > 0;
                    
                }
                Swipe();
            }
            else
            {
                Tap();
            }
            #endregion
        }
    }
    public void Swipe()
    {
        if (swipe[0] || swipe[1] || swipe[2] || swipe[3])
        {
            Debug.Log(swipe[0] + "||" + swipe[1] + "||" + swipe[2] + "||" + swipe[3]);
        }
    }

    public void Tap()
    {
        Debug.Log("Tap");
    }
    private void Reset()
    {
        startTouchPosition = touchDistance = Vector2.zero;
        for (int i = 0; i < 4; i++)
        { 
            swipe[i] = false; 
        }
    }
}
