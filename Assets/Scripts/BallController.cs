using System;
using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public int Speed = 200;

    private Rigidbody _rigidbody;

    public enum SwipeDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    public static event Action<SwipeDirection> Swipe;
    private bool swiping = false;
    private bool eventSent = false;
    private Vector2 lastPosition;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Swipe += OnSwipe;
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal") * Speed ;
        //float moveVertical = Input.GetAxis("Vertical") * Speed ;
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //_rigidbody.AddForce(movement);

        //if (Input.touchCount > 0)
        //{
        //    // The screen has been touched so store the touch
        //    Touch touch = Input.GetTouch(0);


        //    // If the finger is on the screen, move the object smoothly to the touch position
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0f, touch.position.y));
        //    _rigidbody.AddForce(touchPosition * Speed);

        //}


        if (Input.touchCount == 0)
            return;

        if ((int)Input.GetTouch(0).deltaPosition.sqrMagnitude != 0)
        {
            if (swiping == false)
            {
                swiping = true;
                lastPosition = Input.GetTouch(0).position;
                return;
            }
            else
            {
                if (!eventSent)
                {
                    if (Swipe != null)
                    {
                        Vector2 direction = Input.GetTouch(0).position - lastPosition;

                        _rigidbody.AddForce(new Vector3(direction.x, 0f, direction.y) * Speed);

                        //if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        //{
                        //    if (direction.x > 0)
                        //        Swipe(SwipeDirection.Right);
                        //    else
                        //        Swipe(SwipeDirection.Left);
                        //}
                        //else
                        //{
                        //    if (direction.y > 0)
                        //        Swipe(SwipeDirection.Up);
                        //    else
                        //        Swipe(SwipeDirection.Down);
                        //}

                        eventSent = true;
                    }
                }
            }
        }
        else
        {
            swiping = false;
            eventSent = false;
        }

    }

    private void OnSwipe(SwipeDirection swipeDirection)
    {
        switch (swipeDirection)
        {
            case SwipeDirection.Up:
                _rigidbody.AddForce(Vector3.forward * Speed);
                break;
            case SwipeDirection.Down:
                _rigidbody.AddForce(Vector3.back * Speed);
                break;
            case SwipeDirection.Right:
                _rigidbody.AddForce(Vector3.right * Speed);
                break;
            case SwipeDirection.Left:
                _rigidbody.AddForce(Vector3.left * Speed);
                break;
        }
    }
}
