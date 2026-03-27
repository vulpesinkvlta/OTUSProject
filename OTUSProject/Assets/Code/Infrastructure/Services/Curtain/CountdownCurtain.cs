using Code.Infrastructure.Services.Curtain;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownCurtain : MonoBehaviour, ICountDownCurtain
{
    public TextMeshProUGUI CountDownText;
    private float _countDown = 3;
    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Hide()  
    {
        Debug.Log("curtain count");

        StartCoroutine(DoCountDown()); 
    }

    private IEnumerator DoCountDown()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        float time = _countDown;

        while (time > 0)
        {
            CountDownText.text = Mathf.Ceil(time).ToString();
            yield return new WaitForSecondsRealtime(1f);
            time--;
        }

        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

