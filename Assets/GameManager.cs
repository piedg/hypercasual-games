using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayFlyingFurry()
    {
        SceneManager.LoadScene("FlyingFurry");
    }

    public void PlayYinYang()
    {
        SceneManager.LoadScene("YinYang");
    }
}
