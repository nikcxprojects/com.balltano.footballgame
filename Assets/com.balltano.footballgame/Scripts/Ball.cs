using System;
using UnityEngine;
using System.Collections;

using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private const float timeOffset = 0.8f;


    private CircleCollider2D Collider { get; set; }
    private SpriteRenderer Renderer { get;set; }


    public static Action OnPressed { get; set; } = delegate { };

    private void Awake()
    {
        Collider = GetComponent<CircleCollider2D>();
        Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Collider.enabled = false;
        Renderer.enabled = false;

        if(SettingsManager.VibraEnable)
        {
            Handheld.Vibrate();
        }

        OnPressed?.Invoke();
    }

    public void Init()
    {
        StartCoroutine(nameof(GameCycle));
    }

    Vector2 GetPosition()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float y = Random.Range(-4.43f, 3.29f);

        return new Vector2(x, y);
    }

    private IEnumerator GameCycle()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeOffset);

            Collider.enabled = true;
            Renderer.enabled = true;

            transform.position = GetPosition();
        }
    }
}
