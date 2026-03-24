using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource[] Sounds;



    void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlaySound(string name)
    {
        foreach (AudioSource a in Sounds)
        {
            if (a.name == name)
            {
                a.PlayOneShot(a.clip);
                return;
            }
        }
        Debug.LogWarning("Sound: " + name + " not found!");
    }
}
