using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, _camera.ScreenToWorldPoint(Input.mousePosition).y);
    }
}
