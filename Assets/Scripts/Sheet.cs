using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheet : MonoBehaviour
{
    public static Sheet instance = null;
    
    public List<float> noteLine1;
    public List<float> noteLine2;
    public List<float> noteLine3;
    public List<float> noteLine4;

    public string songName;
    public float speed = 17f;
    public float noteOffset = 0.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ResetSheet()
    {
        noteLine1.RemoveRange(0, noteLine1.Count);
        noteLine2.RemoveRange(0, noteLine2.Count);
        noteLine3.RemoveRange(0, noteLine3.Count);
        noteLine4.RemoveRange(0, noteLine4.Count);
    }

    public void SetNote(int line, float noteTime)
    {
        switch (line)
        {
            case 1:
                noteLine1.Add(noteTime);
                break;
            case 2:
                noteLine2.Add(noteTime);
                break;
            case 3:
                noteLine3.Add(noteTime);
                break;
            case 4:
                noteLine4.Add(noteTime);
                break;
        }
    }
}
