using UnityEngine;
using UnityEngine.UI;
using TMPro;
using R3;
using R3.Triggers;


public class LifeGauge : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image gaugeImage;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI maxLifeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.OnActionMesod_Float(UpdateLifeText);

        gaugeImage.fillAmount = 1.0f;
        // ライフの最大値
        maxLifeText.text = player._MaxLife.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateLifeText(float l_currentlife, float l_maxlife)
    {
        lifeText.text = l_currentlife.ToString();

        gaugeImage.fillAmount = l_currentlife / l_maxlife;
    }
}
