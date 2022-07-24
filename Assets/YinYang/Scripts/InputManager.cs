using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace YinYang
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] float turnSpeed;
        Touch touch;
        float halfScreenWidth = Screen.width / 2;

        Vector3 direction;

        void Update()
        {
            TouchInput();

            transform.Rotate(direction * turnSpeed * Time.deltaTime);
        }

        void TouchInput()
        {
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                if (Input.touchCount > 0 || Input.GetMouseButton(0))
                {
                    touch = Input.GetTouch(0);

                    for (int i = 0; i < Input.touchCount; i++)
                    {
                        Vector3 touchPosition = Input.touches[i].position;

                        if (touchPosition.x < halfScreenWidth)
                            direction = Vector3.forward;
                        else
                            direction = Vector3.back;
                        if (touch.phase == TouchPhase.Ended)
                            direction = Vector3.zero;
                    }
                }
            }
        }
    }
}

