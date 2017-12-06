using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GUI_Canvas : MonoBehaviour 
{
    
    public GUISkin mySkin;
    public int score = 0;
    public int age = 0;
    public float density = 0;
    public int frame = 0;
    public Texture2D seedImage;

    /*
    private void OnGUI()
    {
        GUI.skin = mySkin;
        GUI.Label(new Rect(new Vector2(50, 20), new Vector2(300, 100)), "Origin Image : ");

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Scene_01")
        {
            score = GameObject.Find("Environment").GetComponent<Environment>().AliveCells();
            age = GameObject.Find("Environment").GetComponent<Environment>().MaxAge();
            frame = GameObject.Find("Environment").GetComponent<Environment>().CurrentFrame();
            density = GameObject.Find("Environment").GetComponent<Environment>().Density();
        }
        GUI.Label(new Rect(new Vector2(Screen.width - 175, 100), new Vector2(300, 100)), "Population: " + score.ToString());
        GUI.Label(new Rect(new Vector2(Screen.width - 175, 150), new Vector2(300, 300)), "Oldest: " + age.ToString());
        GUI.Label(new Rect(new Vector2(Screen.width - 175, 200), new Vector2(300, 100)), "Iteration: " + frame.ToString());
        GUI.Label(new Rect(new Vector2(Screen.width - 175, 250), new Vector2(300, 100)), "Density: " + density.ToString());
    }*/
}

