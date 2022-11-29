using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private Player playerPrefab { get; set; }

    private Ball BallPrefab { get; set; }
    private Transform BallParent { get; set; }

    public UIManager uiManager;

    private void Awake()
    {
        playerPrefab = Resources.Load<Player>("player");

        BallPrefab = Resources.Load<Ball>("ball");
        BallParent = GameObject.Find("Environment").transform;
    }

    public void StartGame()
    {
        Instantiate(playerPrefab, BallParent);
        StartCoroutine(nameof(BallSpawning));
    }

    public void EndGame()
    {
        Destroy(FindObjectOfType<Player>().gameObject);

        Ball[] balls = FindObjectsOfType<Ball>();
        foreach(Ball b in balls)
        {
            Destroy(b.gameObject);
        }

        StopCoroutine(nameof(BallSpawning));
    }

    private IEnumerator BallSpawning()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.0f);

            Vector2 position = new Vector2(3.84f, Random.Range(-4.0f, 4.0f));
            Quaternion rotation = Quaternion.Euler(Vector3.forward * Random.Range(0.0f, 360.0f));

            Instantiate(BallPrefab, position, rotation, BallParent);
        }
    }
}