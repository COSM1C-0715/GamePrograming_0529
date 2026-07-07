using UnityEngine;
using System.Collections;
using TMPro;
using DG.Tweening;

public class CountDisplayManagement : MonoBehaviour
{
    [SerializeField]
    GameObject CountDisplayText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CountUpDisplay()
    {
        CountDisplayText.SetActive(true);

        yield return null;

        CountDisplayText.transform.DOMoveY(600,3.0f);

        CountDisplayText.transform.position = new Vector2(240,450);

        yield return null;

        CountDisplayText.SetActive(false);
    }
}
