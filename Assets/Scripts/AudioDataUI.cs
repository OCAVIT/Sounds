using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AudioDataUI : MonoBehaviour
{
    public AudioDataSO audioData;
    public Text uniqueIDText;
    public Text longText;
    public GameObject dangerousAudioListPanelLeft;
    public GameObject dangerousAudioListPanelRight;
    public GameObject friendlyAudioListPanelLeft;
    public GameObject friendlyAudioListPanelRight;
    public GameObject neutralAudioListPanelLeft;
    public GameObject neutralAudioListPanelRight;
    public GameObject longTextPanel;
    public GameObject audiolistpanel;
    public Button showListButton;
    public Button showTextButton;
    public Button hideAllButton;
    public GameObject audioItemPrefab;
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        uniqueIDText.text = audioData.uniqueID;
        showListButton.onClick.AddListener(ShowList);
        showTextButton.onClick.AddListener(ShowText);
        hideAllButton.onClick.AddListener(HideAll);
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        if (audioData != null && uniqueIDText != null)
        {
            Debug.Log("Setting text: " + audioData.uniqueID);
            uniqueIDText.text = audioData.uniqueID;
        }
        else
        {
            Debug.LogError("AudioData or Text component is not set.");
        }
    }

    void ChangeVolume(float value)
    {
        audioSource.volume = value;
    }

    void ShowList()
    {
        audiolistpanel.SetActive(true);
        dangerousAudioListPanelLeft.SetActive(true);
        dangerousAudioListPanelRight.SetActive(true);
        friendlyAudioListPanelLeft.SetActive(true);
        friendlyAudioListPanelRight.SetActive(true);
        neutralAudioListPanelLeft.SetActive(true);
        neutralAudioListPanelRight.SetActive(true);
        longTextPanel.SetActive(false);

        PopulateAudioList(dangerousAudioListPanelLeft, dangerousAudioListPanelRight, audioData.dangerousAudioClips);
        PopulateAudioList(friendlyAudioListPanelLeft, friendlyAudioListPanelRight, audioData.friendlyAudioClips);
        PopulateAudioList(neutralAudioListPanelLeft, neutralAudioListPanelRight, audioData.neutralAudioClips);
    }

    void PopulateAudioList(GameObject panelLeft, GameObject panelRight, List<AudioClipData> audioClips)
    {
        foreach (Transform child in panelLeft.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in panelRight.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < audioClips.Count; i++)
        {
            GameObject audioItem = Instantiate(audioItemPrefab, i % 2 == 0 ? panelLeft.transform : panelRight.transform);
            Text clipNameText = audioItem.GetComponentInChildren<Text>();
            Button playButton = audioItem.GetComponentInChildren<Button>();

            clipNameText.text = audioClips[i].audioClip.name;

            int index = i;
            playButton.onClick.AddListener(() => PlayAudioClip(audioClips[index].audioClip));
        }
    }

    void ShowText()
    {
        dangerousAudioListPanelLeft.SetActive(false);
        dangerousAudioListPanelRight.SetActive(false);
        friendlyAudioListPanelLeft.SetActive(false);
        friendlyAudioListPanelRight.SetActive(false);
        neutralAudioListPanelLeft.SetActive(false);
        neutralAudioListPanelRight.SetActive(false);
        longTextPanel.SetActive(true);
        audiolistpanel.SetActive(false);
    }

    void HideAll()
    {
        dangerousAudioListPanelLeft.SetActive(false);
        dangerousAudioListPanelRight.SetActive(false);
        friendlyAudioListPanelLeft.SetActive(false);
        friendlyAudioListPanelRight.SetActive(false);
        neutralAudioListPanelLeft.SetActive(false);
        neutralAudioListPanelRight.SetActive(false);
        longTextPanel.SetActive(false);
        audiolistpanel.SetActive(false);
    }

    void PlayAudioClip(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}