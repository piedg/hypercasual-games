using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingFurry
{
    public class DeactiveObject : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Obstacles"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}

