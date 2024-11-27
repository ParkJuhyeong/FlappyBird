using UnityEngine;
using TMPro; // TextMeshPro 네임스페이스 추가

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private TextMeshProUGUI scoreText; // TextMeshProUGUI로 변경
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    public int score { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned!");
        }
        if (playButton == null)
        {
            Debug.LogError("Play Button is not assigned!");
        }
        if (gameOver == null)
        {
            Debug.LogError("Game Over UI is not assigned!");
        }
        if (player == null)
        {
            Debug.LogError("Player is not assigned!");
        }
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        if (player != null)
        {
            player.enabled = false;
        }
        else
        {
            Debug.LogError("Player is null in Pause method!");
        }
    }

    public void Play()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned!");
            return;
        }

        score = 0;
        scoreText.text = score.ToString();

        if (playButton != null)
        {
            playButton.SetActive(false);
        }
        else
        {
            Debug.LogError("Play Button is null in Play method!");
        }

        if (gameOver != null)
        {
            gameOver.SetActive(false);
        }
        else
        {
            Debug.LogError("Game Over UI is null in Play method!");
        }

        Time.timeScale = 1f;
        if (player != null)
        {
            player.enabled = true;
        }
        else
        {
            Debug.LogError("Player is null in Play method!");
        }

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        if (playButton != null)
        {
            playButton.SetActive(true);
        }
        else
        {
            Debug.LogError("Play Button is null in GameOver method!");
        }

        if (gameOver != null)
        {
            gameOver.SetActive(true);
        }
        else
        {
            Debug.LogError("Game Over UI is null in GameOver method!");
        }

        Pause();
    }

    public void IncreaseScore()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned!");
            return;
        }

        score++;
        scoreText.text = score.ToString();
    }
}
