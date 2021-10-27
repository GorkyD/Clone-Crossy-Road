using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject player;
    

    private void Update()
    {
        if (player.activeSelf == false || player.transform.position.y < -3)
        {
            GameOver();
        }
    }
    
    private void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
