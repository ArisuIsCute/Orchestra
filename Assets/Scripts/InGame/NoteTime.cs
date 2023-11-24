using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTime : MonoBehaviour
{
    private float currentTime;
    private float currentNoteTime1;
    private float currentNoteTime2;
    private float currentNoteTime3;
    private float currentNoteTime4;

    private float perfectRate = 2500f;
    private float greatRate = 5000f;
    private float goodRate = 7000f;
    private float badRate = 11000f;
    private float missRate = 16000f;

    private int lineNum;

    private Queue<float> noteTimeLine1 = new Queue<float>();
    private Queue<float> noteTimeLine2 = new Queue<float>();
    private Queue<float> noteTimeLine3 = new Queue<float>();
    private Queue<float> noteTimeLine4 = new Queue<float>();
    public bool isEnd = false;

    private Sheet sheet;
    private Music music;

    private void Start()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        music = GameObject.Find("Music").GetComponent<Music>();
        
        SetQueue();
    }

    private void Update()
    {
        currentTime += music.audio.timeSamples;

        if (noteTimeLine1.Count > 0)
        {
            currentNoteTime1 = noteTimeLine1.Peek();
            currentNoteTime1 = currentNoteTime1 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime1 + missRate < currentTime)
            {
                noteTimeLine1.Dequeue();
            }
        }

        if (noteTimeLine1.Count > 0)
        {
            currentNoteTime2 = noteTimeLine2.Peek();
            currentNoteTime2 = currentNoteTime2 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime2 + missRate < currentTime)
            {
                noteTimeLine2.Dequeue();
            }
        }

        if (noteTimeLine3.Count > 0)
        {
            currentNoteTime3 = noteTimeLine3.Peek();
            currentNoteTime3 = currentNoteTime3 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime3 + missRate < currentTime)
            {
                noteTimeLine3.Dequeue();
            }
        }

        if (noteTimeLine4.Count > 0)
        {
            currentNoteTime4 = noteTimeLine4.Peek();
            currentNoteTime4 = currentNoteTime4 * 0.001f * music.audio.clip.frequency;

            if (currentNoteTime4 + missRate < currentTime)
            {
                noteTimeLine4.Dequeue();
            }
        }
    }

    public void TapNote(int lineNum)
    {
        this.lineNum = lineNum;

        if (lineNum.Equals(1))
        {
            if (noteTimeLine1.Count == 0) return;

            if (Math.Abs(currentNoteTime1 - currentTime) <= perfectRate)
            {
                noteTimeLine1.Dequeue();
            }else if (Math.Abs(currentNoteTime1 - currentTime) <= greatRate)
            {
                noteTimeLine1.Dequeue();
            }else if (Math.Abs(currentNoteTime1 - currentTime) <= goodRate)
            {
                noteTimeLine1.Dequeue();
            }else if (Math.Abs(currentNoteTime1 - currentTime) <= badRate)
            {
                noteTimeLine1.Dequeue();
            }else if (currentNoteTime1 + missRate <= currentTime)
            {
                noteTimeLine1.Dequeue();
            }
        }

        if (lineNum.Equals(2))
        {
            if(noteTimeLine2.Count == 0) return;

            if (Math.Abs(currentNoteTime2 - currentTime) <= perfectRate)
            {
                noteTimeLine2.Dequeue();
            }else if (Math.Abs(currentNoteTime2 - currentTime) <= greatRate)
            {
                noteTimeLine2.Dequeue();
            }else if (Math.Abs(currentNoteTime2 - currentTime) <= goodRate)
            {
                noteTimeLine2.Dequeue();
            }else if (Math.Abs(currentNoteTime2 - currentTime) <= badRate)
            {
                noteTimeLine2.Dequeue();
            }else if (currentNoteTime2 + missRate <= currentTime)
            {
                noteTimeLine2.Dequeue();
            }
        }

        if (lineNum.Equals(3))
        {
            if (noteTimeLine3.Count == 0) return;

            if (Math.Abs(currentNoteTime3 - currentTime) <= perfectRate)
            {
                noteTimeLine3.Dequeue();
            }else if (Math.Abs(currentNoteTime3 - currentTime) <= greatRate)
            {
                noteTimeLine3.Dequeue();
            }else if (Math.Abs(currentNoteTime3 - currentTime) <= goodRate)
            {
                noteTimeLine3.Dequeue();
            }else if (Math.Abs(currentNoteTime3 - currentTime) <= badRate)
            {
                noteTimeLine3.Dequeue();
            }else if (currentNoteTime3 + missRate <= currentTime)
            {
                noteTimeLine3.Dequeue();
            }
        }

        if (lineNum.Equals(4))
        {
            if (noteTimeLine4.Count == 0) return;

            if (Math.Abs(currentNoteTime4 - currentTime) <= perfectRate)
            {
                noteTimeLine4.Dequeue();
            }else if (Math.Abs(currentNoteTime4 - currentTime) <= greatRate)
            {
                noteTimeLine4.Dequeue();
            }else if (Math.Abs(currentNoteTime4 - currentTime) <= goodRate)
            {
                noteTimeLine4.Dequeue();
            }else if (Math.Abs(currentNoteTime4 - currentTime) <= badRate)
            {
                noteTimeLine4.Dequeue();
            }else if (currentNoteTime4 + missRate <= currentTime)
            {
                noteTimeLine4.Dequeue();
            }
        }
    }

    private void SetQueue()
    {
        foreach(var noteTime in sheet.noteLine1)
            noteTimeLine1.Enqueue(noteTime);
        foreach(var noteTime in sheet.noteLine2)
            noteTimeLine2.Enqueue(noteTime);
        foreach(var noteTime in sheet.noteLine3)
            noteTimeLine3.Enqueue(noteTime);
        foreach(var noteTime in sheet.noteLine4)
            noteTimeLine4.Enqueue(noteTime);
    }
}
