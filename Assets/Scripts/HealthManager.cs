using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int healthVal = 100;
    private int armourVal = 0;

    public Texture healthTexture;
    public Texture armourTexture;

    public Rect rHeathHud;
    public Rect rArmourHud;

    public GUIStyle styleHud;

    private void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.DrawTexture(rHeathHud, healthTexture);
        GUI.DrawTexture(rArmourHud, armourTexture);

        GUI.Box(rHeathHud, healthVal.ToString(), styleHud);
        GUI.Box(rArmourHud, armourVal.ToString(), styleHud);
    }
}
