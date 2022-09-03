using System;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [Serializable]
    public class TrackDef
    {
        public string name;
        public AudioClip clip;
        public float volume;
    }
    public List<TrackDef> tracklist = new List<TrackDef>();

    public AudioSource audioSource;

    public void Play(string name)
    {
        TrackDef def = tracklist.Find(def => def.name == name);
        if (def != null)
        {
            audioSource.clip = def.clip;
            audioSource.volume = def.volume;
            audioSource.Play();
        }
    }
}
