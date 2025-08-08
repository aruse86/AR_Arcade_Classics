// needed namespaces for Unity to function
using System.Collections;
using UnityEngine;

// Defines the BackgroundMusic class that plays background music during gameplay
public class BackgroundMusic : MonoBehaviour
{
    public AudioClip trackA;
    public AudioClip trackB;

    private AudioSource audioSource;

    // starts the music tracks
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayMusicSequence());
    }

    // defines how the music is to be played (recommended by music creator)
    IEnumerator PlayMusicSequence()
    {
        // Play Track A once
        audioSource.clip = trackA;
        audioSource.loop = false;
        audioSource.Play();

        // Wait until Track A finishes
        yield return new WaitForSeconds(trackA.length);

        // Play Track B in a loop
        audioSource.clip = trackB;
        audioSource.loop = true;
        audioSource.Play();
    }
}
