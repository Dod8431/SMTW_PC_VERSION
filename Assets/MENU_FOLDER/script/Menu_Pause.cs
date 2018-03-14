using UnityEngine;

public class Menu_Pause : MonoBehaviour {
    private bool isPaused = false;
    public GUISkin  customSkin;
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            isPaused = !isPaused;
            GameObject.Find("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        }
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
            GameObject.Find("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        }
    }

    void OnGUI () {

        GUI.skin = customSkin;
       if (isPaused)
        {
            if(GUI.Button(new Rect (Screen.width / 2 - 150, Screen.height /2 - 250, 300, 150), "Menu")){
                isPaused = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menus Principal");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 300, 150), "Continue"))
            {
                GameObject.Find("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                isPaused = false;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 300, 150), "Quit"))
            {
                Application.Quit();
            }
        }
        
	}

}
