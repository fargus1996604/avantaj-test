using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICooldown : MonoBehaviour
{
    [SerializeField]
    private Text _cooldownText;

    [SerializeField]
    private GameObject _playButton;

    [SerializeField]
    private int _duration = 3;

    [SerializeField]
    private GameEvent _startGame;

    private void OnEnable()
    {
        _playButton.SetActive(true);
        _cooldownText.gameObject.SetActive(false);
    }

    public void Play()
    {
        _playButton.SetActive(false);
        _cooldownText.gameObject.SetActive(true);
        StartCoroutine(CooldownCO());
    }

    private IEnumerator CooldownCO()
    {
        int duration = _duration;
        while (duration > 0)
        {
            _cooldownText.text = duration.ToString();
            duration--;
            yield return new WaitForSeconds(1);
        }

        _cooldownText.text = "GO";
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
        _startGame?.Raise();
    }
}
