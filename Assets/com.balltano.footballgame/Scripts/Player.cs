using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        transform.position = new Vector2(FindObjectOfType<UIManager>().border.position.x + 1, 0);
    }

    private void Update()
    {
        if(Time.timeScale < 1)
        {
            return;
        }

        transform.position = new Vector2(transform.position.x, _camera.ScreenToWorldPoint(Input.mousePosition).y);
    }

    private void OnTriggerEnter2D(Collider2D _)
    {
        GameManager.Instance.uiManager.UpdateScore();
    }
}
