using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Principal : MonoBehaviour
{
    public GUISkin customSkin;
    public float button1horizontal = 250;
    public float button2horizontal = 250;
    public float button1vertical = 80;
    public float button2vertical = 80;

    void Update()
    {
        Time.timeScale = 1.0f;
    }
    void OnGUI()
    {
        {
            GUI.skin = customSkin;

            if (GUI.Button(new Rect(Screen.width / 2 + button1horizontal, Screen.height / 2 - button1vertical, 300, 100), "Jouer"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("TUTORIAL");
            }

            if (GUI.Button(new Rect(Screen.width / 2 + button2horizontal, Screen.height / 2 + button2vertical, 300, 100), "Quitter"))
            {
                Application.Quit();
            }

            /*public void Load_Scene()
            {

            }
            public void Quit(){
                Application.Quit();
            }*/
        }
    }
}
