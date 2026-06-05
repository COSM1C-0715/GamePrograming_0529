using UnityEngine;
using TMPro;

public class ScoreManagement : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Score_Text;

    int Score_count = 0;

    public int p_ScoreCount => Score_count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score_Text.text = Score_count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Score_Text.text = Score_count.ToString();
    }

    public void CountAdd()
    {
        Score_count++;
    }
}
