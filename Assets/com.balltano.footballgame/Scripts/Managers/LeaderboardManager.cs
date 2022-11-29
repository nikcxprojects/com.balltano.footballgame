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
            Text leader = container.GetChild(i).GetChild(1).GetComponentInChildren<Text>();
            leader.text = string.Format("{0:0000}", Random.Range((i + 2) * 100, (i + 3) * 100));
        }
    }
}
