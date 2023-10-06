using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int points;

    public Rect rHint;
    public GUIStyle style;

    public int Points
    {
        get { return this.points; }
    }

    public void OnGUI()
    {
        GUI.Box(rHint, string.Format("Scores: {0}", points), style);
    }

    public void addPoint(int count)
    {
        points += count;
    }
}
