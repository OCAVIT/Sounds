using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObjects/AudioData", order = 1)]
public class AudioDataSO : ScriptableObject
{
    public string uniqueID;
    [TextArea(3, 10)]
    public string longText;
    public AudioContentType audioContentType;
    public List<AudioClipData> dangerousAudioClips = new List<AudioClipData>();
    public List<AudioClipData> friendlyAudioClips = new List<AudioClipData>();
    public List<AudioClipData> neutralAudioClips = new List<AudioClipData>();
}