using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Space(10)]
    [SerializeField] AudioSource loop;
    [SerializeField] Button soundBtnOff;
    [SerializeField] Button soundBtnOn;

    [Space(10)]
    [SerializeField] AudioSource sfx;
    [SerializeField] Button sfxBtnOff;
    [SerializeField] Button sfxBtnOn;

    [Space(10)]
    [SerializeField] Button vibtoBtnOff;
    [SerializeField] Button vibtoBtnOn;

    private const string active = "#FF6600";
    private const string disable = "#3C424D";

    public static bool VibraEnable { get; set; } = true;

    private void Start()
    {
        soundBtnOff.onClick.AddListener(() =>
        {
            loop.mute = true;

            ColorUtility.TryParseHtmlString(active, out Color activeColor);
            soundBtnOff.GetComponent<Image>().color = activeColor;

            ColorUtility.TryParseHtmlString(disable, out Color disableColor);
            soundBtnOn.GetComponent<Image>().color = disableColor;
        });

        soundBtnOn.onClick.AddListener(() =>
        {
            loop.mute = false;

            ColorUtility.TryParseHtmlString(active, out Color activeColor);
            soundBtnOn.GetComponent<Image>().color = activeColor;

            ColorUtility.TryParseHtmlString(disable, out Color disableColor);
            soundBtnOff.GetComponent<Image>().color = disableColor;
        });

        sfxBtnOff.onClick.AddListener(() =>
        {
            sfx.mute = true;

            ColorUtility.TryParseHtmlString(active, out Color activeColor);
            sfxBtnOff.GetComponent<Image>().color = activeColor;

            ColorUtility.TryParseHtmlString(disable, out Color disableColor);
            sfxBtnOn.GetComponent<Image>().color = disableColor;
        });

        sfxBtnOn.onClick.AddListener(() =>
        {
            sfx.mute = false;

            ColorUtility.TryParseHtmlString(active, out Color activeColor);
            sfxBtnOn.GetComponent<Image>().color = activeColor;

            ColorUtility.TryParseHtmlString(disable, out Color disableColor);
            sfxBtnOff.GetComponent<Image>().color = disableColor;
        });

        vibtoBtnOff.onClick.AddListener(() =>
        {
            VibraEnable = false;

            ColorUtility.TryParseHtmlString(active, out Color activeColor);
            vibtoBtnOff.GetComponent<Image>().color = activeColor;

            ColorUtility.TryParseHtmlString(disable, out Color disableColor);
            vibtoBtnOn.GetComponent<Image>().color = disableColor;
        });

        vibtoBtnOn.onClick.AddListener(() =>
        {
            VibraEnable = true;

            ColorUtility.TryParseHtmlString(active, out Color activeColor);
            vibtoBtnOn.GetComponent<Image>().color = activeColor;

            ColorUtility.TryParseHtmlString(disable, out Color disableColor);
            vibtoBtnOff.GetComponent<Image>().color = disableColor;
        });

        soundBtnOn.onClick.Invoke();
        sfxBtnOn.onClick.Invoke();
        vibtoBtnOn.onClick.Invoke();
    }
}
