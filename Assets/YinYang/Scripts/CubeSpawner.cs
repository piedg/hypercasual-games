using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YinYang
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] float spawnTime;
        [SerializeField] List<GameObject> cubesPrefab;

        Vector2 minBounds, maxBounds;
        float offSet = 2f;

        private void Start()
        {
            InitBounds();

            StartCoroutine(CubeGenerator());
        }

        IEnumerator CubeGenerator()
        {
            while (true)
            {

                Vector3 spawnPosition = new Vector3(Random.Range(-1f, 1f), maxBounds.y + offSet);
                Instantiate(GetRandomCubes(), 
                spawnPosition,
                Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);

            }
        }

        GameObject GetRandomCubes()
        {
            return cubesPrefab[Random.Range(0, cubesPrefab.Count)];
        }

        void InitBounds()
        {
            Camera mainCamera = Camera.main;
            maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        }
    }
}
