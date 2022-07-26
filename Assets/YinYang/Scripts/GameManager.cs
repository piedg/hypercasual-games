using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace YinYang
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject StartGamePanel;
        [SerializeField] GameObject PauseGamePanel;
        [SerializeField] Button PauseButton;

        [SerializeField] TextMeshProUGUI scoreText;
        int score;

        private void Start()
        {
            score = 0;
            scoreText.text = score.ToString();

            StartGame();
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

        public void StartGame()
        {
            Time.timeScale = 0;
            PauseGamePanel.SetActive(false);
            StartGamePanel.SetActive(true);
            PauseButton.gameObject.SetActive(false);
        }

        public void PlayGame()
        {
            Time.timeScale = 1;
            StartGamePanel.SetActive(false);
            PauseButton.gameObject.SetActive(true);
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            PauseGamePanel.SetActive(true);
            PauseButton.gameObject.SetActive(false);

        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            PauseGamePanel.SetActive(false);
            PauseButton.gameObject.SetActive(true);
        }

        public void ExitGame()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
