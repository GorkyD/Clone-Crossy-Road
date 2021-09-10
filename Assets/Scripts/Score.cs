using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;

    private void FixedUpdate()
    {
        score++;
    }
    private void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
