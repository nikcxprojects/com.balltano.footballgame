using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float speed = 10.0f;

    private void Start()
    {
        Vector2 toPlayer = new Vector2(FindObjectOfType<Player>().transform.position.x, Random.Range(-3.0f, 3.0f)) - (Vector2)transform.position;
        transform.up = toPlayer;

        Destroy(gameObject, 2.0f);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
