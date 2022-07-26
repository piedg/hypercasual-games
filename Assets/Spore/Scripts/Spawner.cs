using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> list = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        float rand = Random.Range(-2f, 2f); 
    }
}
