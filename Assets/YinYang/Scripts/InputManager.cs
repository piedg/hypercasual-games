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

        void Update()
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
                            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
                        else
                            transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);

                        if (touch.phase == TouchPhase.Ended)
                            transform.Rotate(Vector3.zero);
                    }
                }
            }
        }
    }
}

