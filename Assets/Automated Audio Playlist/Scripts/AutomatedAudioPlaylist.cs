using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
   
[RequireComponent(typeof(AudioSource))]
public class AutomatedAudioPlaylist : MonoBehaviour {

    // Not necessary, but I use this mixer as a reference for the entire project.
    public AudioMixer mixer;

    [Header("Parameters")]
    public bool isPlayOnStart = true;
    public bool isShuffleOnStart = true;
    public bool isRepeatPlaylist = true;

    [Header("Content")]
    public List<AudioClip> playlist = new List<AudioClip>();

    internal AudioSource audioSource;
    internal AudioClip onlineAudioClip, tempAudioClip;
    internal int playlistIndex, random;
    internal float[] sampleData;

    public virtual void Awake () {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void Start () {
        if (isShuffleOnStart) Shuffle();
        if (isPlayOnStart) StartCoroutine (Processing());
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad (audioSource);
        DontDestroyOnLoad(gameObject.GetComponent<AutomatedAudioPlaylist>());
    }
    public void PlayByIndex (int index) {
        Stop();
        onlineAudioClip = playlist[index];
        audioSource.clip = onlineAudioClip;
        audioSource.Play();
    }

    public bool IsPlaying () {
        return audioSource.isPlaying;
    }

    public string ClipName () {
        return audioSource.clip.name;
    }

    public virtual void Play () {
        if (audioSource.isPlaying) return;
        StartCoroutine (Processing());
    }

    public virtual void Pause () {
        audioSource.Pause();
    }

    public virtual void Resume () {
        audioSource.Play();
    }

    public virtual void Stop () {
        audioSource.Stop();
        StopAllCoroutines();
    }

    public virtual void Shuffle () {
        if (playlist.Count == 0) return;
        for (int t = 0; t < playlist.Count; t++ ) {
            tempAudioClip = playlist[t];
            random = Random.Range(t, playlist.Count);
            playlist[t] = playlist[random];
            playlist[random] = tempAudioClip;
        }
    }

    public virtual void Next () {
        if (playlistIndex + 1 < playlist.Count) {
            playlistIndex++;
        }
        else {
            playlistIndex = 0;
        }
        Stop();
        Play();
    }

    public virtual void Previous () {
        if (playlistIndex > 0) {
            playlistIndex--;
        }
        else {
            playlistIndex = playlist.Count - 1;
        }
        Stop(); 
        Play();
    }

    public virtual void AddToPlaylist (AudioClip clip) {
        playlist.Add (clip);
    }

    public virtual void RemoveFromPlaylist (int index) {
        playlist.RemoveAt (index);
    }

    public float[] GetSamplesData () {
        return sampleData;
    }

    public float[] SpectrumData (int rate = 256) {
        sampleData = new float[rate];
        AudioListener.GetSpectrumData(sampleData, 0, FFTWindow.Rectangular);
        return sampleData;
    }

    private IEnumerator Processing () {
        onlineAudioClip = playlist[playlistIndex];
        audioSource.clip = onlineAudioClip;
        audioSource.Play();
        while (audioSource.time < onlineAudioClip.length) {
            yield return null;
        }
        Stop();
        if (isRepeatPlaylist) Next();
        yield return null;
    }
}
