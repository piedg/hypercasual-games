using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace YinYang
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        int score;

        private void Start()
        {
            score = 0;
            scoreText.text = score.ToString();
        }

        public void UpdateScore(int value)
        {
            score += value;
            scoreText.text = score.ToString();
        }
        public void ResetScore()
        {
            score = 0;
            scoreText.text = score.ToString();
        }
    }
}
