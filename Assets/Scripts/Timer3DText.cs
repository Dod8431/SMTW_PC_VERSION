 using UnityEngine;
 
 public class Timer3DText : MonoBehaviour
 {
     public int  Minutes = 0;
     public int  Seconds = 0;
	 public bool starttimer;
 
     public TextMesh m_text;
     private float m_leftTime;

     public GameObject gameoverrespawn;
     public GameObject player;
 
     private void Awake()
     {
         m_text = GetComponent<TextMesh>();
         m_leftTime = GetInitialTime();
     }
 
     private void Update()
     {
		if(starttimer == true)
		{
         if (m_leftTime > 0f)
         {
             //  Update countdown clock
             m_leftTime -= Time.deltaTime;
             Minutes = GetLeftMinutes();
             Seconds = GetLeftSeconds();
             //  Show current clock
             if (m_leftTime > 0f)
             {
                 m_text.text = "0" + Minutes + ":" + Seconds.ToString("00");
             }
             else
             {
                 m_text.text = "00:00";
                 GameObject.Find("ScreenFade").GetComponent<Animator>().Play("SCREEN_FADE_IN");
                 player.GetComponent<Transform>().position = gameoverrespawn.transform.position;
             }
         }
		}
        if(GameObject.Find("GAMECONTROLLER").GetComponent<Objectives>().objective_puzzle_1 > 4)
        {
            Destroy(this.gameObject);
        }
     }
 
     private float GetInitialTime()
     {
         return Minutes * 60f + Seconds;
     }
 
     private int GetLeftMinutes()
     {
         return Mathf.FloorToInt(m_leftTime / 60f);
     }
 
     private int GetLeftSeconds()
     {
         return Mathf.FloorToInt(m_leftTime % 60f);
     }
 }