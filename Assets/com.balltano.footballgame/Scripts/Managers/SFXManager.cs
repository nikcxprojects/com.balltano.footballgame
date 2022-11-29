using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    private void Awake()
    {
        Ball.OnPressed += () =>
        {
            if(sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }

            sfxSource.Play();
        };
    }
}
