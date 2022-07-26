using System.Collections;
using UnityEngine;

namespace FlappyBird
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] float maxPosY;
        [SerializeField] float spawnTime;
        [SerializeField] float speed;

        ObjectPool obstaclesPool;

        [SerializeField] float timeToDeactive;
        float timeOverDeactive;

        private void Start()
        {
            obstaclesPool = GetComponent<ObjectPool>();
            StartCoroutine(SpawnObstacles());
        }
        private void Update()
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        IEnumerator SpawnObstacles()
        {
            while(true)
            {
                GameObject obstacles = obstaclesPool.GetObjectFromPool();

                obstacles.transform.SetPositionAndRotation(new Vector2(10f, Random.Range(-maxPosY, maxPosY)), Quaternion.identity);
               
                obstacles.transform.parent = transform;
                obstacles.SetActive(true);

                StartCoroutine(RemoveAfterSeconds(timeToDeactive, obstacles));

                yield return new WaitForSeconds(spawnTime);
            }
        }
        IEnumerator RemoveAfterSeconds(float seconds, GameObject obj)
        {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(false);
        }

    }
}
