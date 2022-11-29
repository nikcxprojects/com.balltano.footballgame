using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private Ball BallPrefab { get; set; }
    private Transform BallParent { get; set; }

    private void Awake()
    {
        BallPrefab = Resources.Load<Ball>("ball");
        BallParent = GameObject.Find("Environment").transform;
    }

    public void StartGame()
    {
        Instantiate(BallPrefab, BallParent).Init();
    }
}