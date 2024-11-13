using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AudioDataUI : MonoBehaviour
{
    public AudioDataSO audioData;
    public Text uniqueIDText;
    public Text longText;
    public GameObject audioListPanel;
    public GameObject longTextPanel;
    public Button showListButton;
    public Button showTextButton;
    public Button hideAllButton;

    void Start()
    {
        uniqueIDText.text = audioData.uniqueID;
        showListButton.onClick.AddListener(ShowList);
        showTextButton.onClick.AddListener(ShowText);
        hideAllButton.onClick.AddListener(HideAll);
    }

    void ShowList()
    {
        audioListPanel.SetActive(true);
        longTextPanel.SetActive(false);

        List<AudioClipData> currentList = null;
        switch (audioData.audioContentType)
        {
            case AudioContentType.Dangerous:
                currentList = audioData.dangerousAudioClips;
                break;
            case AudioContentType.Friendly:
                currentList = audioData.friendlyAudioClips;
                break;
            case AudioContentType.Neutral:
                currentList = audioData.neutralAudioClips;
                break;
        }
    }

    void ShowText()
    {
        audioListPanel.SetActive(false);
        longTextPanel.SetActive(true);
    }

    void HideAll()
    {
        audioListPanel.SetActive(false);
        longTextPanel.SetActive(false);
    }
}