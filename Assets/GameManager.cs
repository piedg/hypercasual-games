using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayFlappyBird()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    public void PlayYinYang()
    {
        SceneManager.LoadScene("YinYang");
    }
}
