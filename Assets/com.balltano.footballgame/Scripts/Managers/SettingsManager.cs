using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Space(10)]
    [SerializeField] AudioSource loop;
    [SerializeField] Button soundBtn;

    [Space(10)]
    [SerializeField] AudioSource sfx;
    [SerializeField] Button sfxBtn;

    [Space(10)]
    [SerializeField] Button vibtoBtn;

    private const string active = "#FFEB00";
    private const string disable = "#0F4839";

    public static bool VibraEnable { get; set; } = true;

    private void Start()
    {
        soundBtn.onClick.AddListener(() =>
        {
            loop.mute = !loop.mute;

            string target = loop.mute ? disable : active;
            string status = loop.mute ? "OFF" : "ON";

            soundBtn.GetComponent<Text>().text = $"MUSIC      <color={target}>{status}</color>";
        });

        sfxBtn.onClick.AddListener(() =>
        {
            sfx.mute = !sfx.mute;

            string target = sfx.mute ? disable : active;
            string status = sfx.mute ? "OFF" : "ON";

            sfxBtn.GetComponent<Text>().text = $"SFX           <color={target}>{status}</color>";
        });

        vibtoBtn.onClick.AddListener(() =>
        {
            VibraEnable = !VibraEnable;

            string target = VibraEnable ? active : disable;
            string status = VibraEnable ? "ONN" : "OFF";

            vibtoBtn.GetComponent<Text>().text = $"VIBRA       <color={target}>{status}</color>";
        });
    }
}
