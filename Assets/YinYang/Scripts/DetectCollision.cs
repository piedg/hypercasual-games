using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YinYang
{
    public class DetectCollision : MonoBehaviour
    {
        [SerializeField] ParticleSystem explosionFX;

        SpriteRenderer sprite;
        GameManager gameManager;

        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();

            gameManager = FindObjectOfType<GameManager>();   
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Red") && gameObject.CompareTag("Red"))
            {
                Debug.Log("Ho colliso con il rosso e sono rosso");
                SpawnExplosionFX(other);

                gameManager.UpdateScore(1);
                Destroy(other.gameObject);

            }
            else if (other.CompareTag("Blue") && gameObject.CompareTag("Blue"))
            {
                Debug.Log("Ho colliso con il blu e sono blu");
                SpawnExplosionFX(other);

                gameManager.UpdateScore(1);
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("Collisione con colori diversi tra loro!");
                gameManager.ResetScore();
                Camera.main.GetComponent<CameraShake>().start = true;
                Destroy(other.gameObject);
                //Time.timeScale = 0;
            }
        }

        void SpawnExplosionFX(Collider2D other)
        {
            explosionFX.startColor = sprite.color;
            Instantiate(explosionFX, other.transform.position, Quaternion.identity);
            explosionFX.Play();
        }
    }
}
