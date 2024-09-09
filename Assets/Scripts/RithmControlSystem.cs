using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class RithmControlSystem : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject notePrefab;
    public GameObject longNotePrefab;
    public Transform spawnPointUp;
    public Transform spawnPointDown;

    public float bpm; 
    private float secPerBeat;
    private float songPosition;
    public float songPositionInBeats;
    private float dspSongTime;
    public float firstBeatOffset;

    //public List<float> beatForNextNote;
    private List<NoteParameters> levelMap;
    

    void Start()
    {
       // beatForNextNote = new List<float>();

        levelMap = new List<NoteParameters>();
        for (int i = 1; i < 50; i++)
        {
            if (i < 23)
            {
                levelMap.Add(new(spawnPointUp, i, notePrefab));
                levelMap.Add(new(spawnPointDown, i, longNotePrefab, 3.5f));
            }
            //if (i < 7)
            //{
            //    if( i == 1 || i == 3 || i == 5)
            //    {
            //        levelMap.Add(new(spawnPointUp, i, notePrefab));
            //        levelMap.Add(new(spawnPointUp, i+0.5f, notePrefab));
            //    }
            //    else if(i == 2 || i == 4 || i == 6)
            //    {
            //        levelMap.Add(new(spawnPointDown, i, notePrefab));
            //        levelMap.Add(new(spawnPointDown, i + 0.5f, notePrefab));
            //    }
            //}
            //if (i == 20)
            //{
            //    levelMap.Add(new(spawnPointUp, i, notePrefab));
            //    levelMap.Add(new(spawnPointDown, i + 0.5f, notePrefab));
            //}
            //if (i == 9 || i == 13 || i == 17 || i == 21)
            //{
            //    levelMap.Add(new(spawnPointUp, i, notePrefab));
            //    levelMap.Add(new(spawnPointUp, i + 0.5f, notePrefab));
            //    levelMap.Add(new(spawnPointDown, i + 0.5f, notePrefab));
            //}
            //if (i > 9 && i < 13 || i > 13 && i < 17)
            //{
            //    levelMap.Add(new(spawnPointDown, i, notePrefab));
            //}

        }
        audioSource = GetComponent<AudioSource>();
        secPerBeat = 60f / bpm;
        dspSongTime = (float)AudioSettings.dspTime;
        audioSource.Play();
    }
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime-firstBeatOffset);
        songPositionInBeats = songPosition/secPerBeat;

        if (levelMap.Count != 0)
        {
            if (audioSource.isPlaying && songPositionInBeats >= levelMap[0].Beat) 
            {
                GameObject instance = Instantiate(levelMap[0].Type, levelMap[0].Position.transform.position, levelMap[0].Type.transform.rotation);
               // instance.transform.localScale = new(instance.transform.localScale.x, instance.transform.localScale.y + levelMap[0].Scale, instance.transform.localScale.z);
               // instance.transform.position = new(instance.transform.position.x + levelMap[0].Offset, instance.transform.position.y, instance.transform.position.z);
                levelMap.RemoveAt(0);
            }
        }
        else
        {
            Debug.Log("Уровень завершен");
        }
    }
}
