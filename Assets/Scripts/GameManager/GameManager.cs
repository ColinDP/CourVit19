
using System;
using TimeManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private TimeManager timeManager;
        public TimeManager TimeManager => timeManager;

        public void LoadNextScene()
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextScene == SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene"));
            else if(nextScene == SceneManager.sceneCountInBuildSettings - 1)
                SceneManager.LoadScene("Level1");
            else
                SceneManager.LoadScene(nextScene);
        }
        
        public void LoadScene(string sceneName)
        {
            var lastScene = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LastScene", lastScene);
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}