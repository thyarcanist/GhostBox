using UnityEngine;
using UnityEngine.UI;

public class AAP_Tutorial : MonoBehaviour {

    public Text label;
    public Button playButton, stopButton, nextButton, previousButton;

    internal AutomatedAudioPlaylist playlist;

    private void Start () {
        playlist = FindObjectOfType<AutomatedAudioPlaylist>();
        playButton.onClick.AddListener(Play);
        stopButton.onClick.AddListener(Stop);
        nextButton.onClick.AddListener(Next);
        previousButton.onClick.AddListener(Previous);
        label.text = "Stand by";
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) Play();
        if (Input.GetKeyDown (KeyCode.Escape)) Stop();
        if (Input.GetKeyDown (KeyCode.RightArrow)) Next();
        if (Input.GetKeyDown (KeyCode.LeftArrow)) Previous();
        playButton.interactable =! playlist.IsPlaying();
        stopButton.interactable = playlist.IsPlaying();
    }

    public void Play () {
        playlist.Play();
        label.text = "Now playing" + "\n" + playlist.ClipName();
    }

    public void Stop () {
        playlist.Stop();
        label.text = "Stand by";
    }

    public void Next () {
        playlist.Next();
        label.text = "Now playing" + "\n" + playlist.ClipName();
    }

    public void Previous () {
        playlist.Previous();
        label.text = "Now playing" + "\n" + playlist.ClipName();
    }
}
