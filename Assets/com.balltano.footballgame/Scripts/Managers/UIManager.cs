using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int score ;
    private float currentTime;
    private const float initTime = 60;

    private GameObject _last = null;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject options;
    [SerializeField] GameObject top;
    [SerializeField] GameObject game;
    [SerializeField] GameObject result;

    [Space(10)]
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScoreText;

    [Space(10)]
    [SerializeField] Text timerText;

    private void Awake()
    {
        OpenWindow(0);

        Ball.OnPressed += () =>
        {
            UpdateScore();
        };
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && game.activeSelf)
        {
            Destroy(FindObjectOfType<Ball>().gameObject);
            OpenWindow(0);
        }

        if(game.activeSelf)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <=0)
            {
                Destroy(FindObjectOfType<Ball>().gameObject);
                OpenWindow(4);

                return;
            }

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void UpdateScore()
    {
        score += Random.Range(2, 6);

        scoreText.text = $"{score}";
        finalScoreText.text = scoreText.text;
    }

    public void OpenWindow(int windowIndex)
    {
        if(_last)
        {
            _last.SetActive(false);
        }

        switch(windowIndex)
        {
            case 0: _last = menu; break;
            case 1: _last = options; break;
            case 2: _last = top; break;
            case 3: _last = game; break;
            case 4: _last = result; break;
        }

        _last.SetActive(true);
        if(windowIndex == 3)
        {
            score = 0;
            currentTime = initTime;

            scoreText.text = $"{score}";
            GameManager.Instance.StartGame();
        }
    }
}