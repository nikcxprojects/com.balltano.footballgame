using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] Transform container;

    private void OnEnable() => UpdateBoard();

    public void UpdateBoard()
    {
        for(int i = 0; i < container.childCount; i++)
        {
            Text leader = container.GetChild(i).GetComponent<Text>();
            leader.text = $"{i + 1} scored <color=yellow>{Random.Range((i+2) * 100, (i+3) * 100)}</color> points";
        }
    }
}
