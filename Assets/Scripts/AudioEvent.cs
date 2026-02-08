using UnityEngine;

[CreateAssetMenu(fileName = "AudioEvent", menuName = "Scriptable Objects/AudioEvent")]
public class AudioEvent : ScriptableObject
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private float volume;
    [SerializeField] [Range(0,2)] private float pitch;

    public void Play(AudioSource source)
    {
        if(clips.Length == 0) return;
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }

}