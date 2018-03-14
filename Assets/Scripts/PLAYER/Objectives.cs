using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    public List<GameObject> puzzle_1_symbols; 
    public List<Transform> puzzle_1_symbols_transform;
    public List <GameObject> puzzle_1_dalles;
    public List<GameObject> puzzle_1_gooddalles;
    public List<Transform> puzzle_1_line1;
    public List<Transform> puzzle_1_line2;
    public List<Transform> puzzle_1_line3;
    public List<Transform> puzzle_1_line4;
    public List<Transform> puzzle_1_line5;
    public AudioClip son_ouverture_porte;
	public GameObject puzzle1door;
    public bool entrance_puzzle1 = false;

    public GameObject respawn_puzzle_1;
    public int objective_puzzle_1;
    public int objective_puzzle_2;
    private bool p1f = true;
  
void Start()
{

    //Puzzle_1_First_Generation();
}

void Update()
{
        if(objective_puzzle_1 > 4 && p1f == true)
        {
			puzzle1door.GetComponentInParent<AudioSource>().enabled = true;
			puzzle1door.GetComponent<Animator>().Play("DOOR_OPEN");
            p1f = false;
        }

        if(entrance_puzzle1 == true)
        {      
            Puzzle_1_First_Generation();
            entrance_puzzle1 = false;
        }
        
        
}
    
public void Puzzle_1_First_Generation()
{
    //Calcul Symbols
    int[] line1 = {0, 1, 4, 5}; //0
    int line_1picker = line1[Random.Range(0,4)];
    int[] line2 = {1, 3, 4}; //1
    int line_2picker = line2[Random.Range(0,3)];
    int[] line3 = {0, 2, 5}; //2
    int line_3picker = line3[Random.Range(0,3)];
    int[] line4 = {2, 3}; //3
    int line_4picker = line4[Random.Range(0,2)];
    int[] line5 = {0, 2, 4}; //4
    int line_5picker = line5[Random.Range(0,3)];
    int[] linefinal = {line_1picker, line_2picker, line_3picker, line_4picker, line_5picker};
    //
    //Calcul Line
    int[] liner1 = {2,3,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25};
    int[] liner2 = {2,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25};
    int[] liner3 = {3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25};
    int[] liner4 = {0,1,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25};
    int[] liner5 = {0,1,3,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25};
    //
    //Calcul Alphabet
    List<int> line_1 = CreateList(0, 1, 2, 3, 4);
    for (int i = 0; i < line_1.Count; i++) {
         int temp = line_1[i];
         int randomIndex = Random.Range(i, line_1.Count);
         line_1[i] = line_1[randomIndex];
         line_1[randomIndex] = temp;
     }
    List<int> line_2 = CreateList(0, 1, 2, 3, 4);
    for (int i = 0; i < line_2.Count; i++) {
         int temp = line_2[i];
         int randomIndex = Random.Range(i, line_2.Count);
         line_2[i] = line_2[randomIndex];
         line_2[randomIndex] = temp;
     }
    List<int> line_3 = CreateList(0, 1, 2, 3, 4);
    for (int i = 0; i < line_3.Count; i++) {
         int temp = line_3[i];
         int randomIndex = Random.Range(i, line_3.Count);
         line_3[i] = line_3[randomIndex];
         line_3[randomIndex] = temp;
     }
    List<int> line_4 = CreateList(0, 1, 2, 3, 4);
    for (int i = 0; i < line_4.Count; i++) {
         int temp = line_4[i];
         int randomIndex = Random.Range(i, line_4.Count);
         line_4[i] = line_4[randomIndex];
         line_4[randomIndex] = temp;
     }
    List<int> line_5 = CreateList(0, 1, 2, 3, 4);
    for (int i = 0; i < line_5.Count; i++) {
         int temp = line_5[i];
         int randomIndex = Random.Range(i, line_5.Count);
         line_5[i] = line_5[randomIndex];
         line_5[randomIndex] = temp;
     }   
    //
        Instantiate(puzzle_1_symbols[linefinal[0]], puzzle_1_symbols_transform[0].position, puzzle_1_symbols_transform[0].rotation, GameObject.Find("Symbol_Line_1").GetComponent<Transform>());
        Instantiate(puzzle_1_symbols[linefinal[1]], puzzle_1_symbols_transform[1].position, puzzle_1_symbols_transform[1].rotation, GameObject.Find("Symbol_Line_2").GetComponent<Transform>());
        Instantiate(puzzle_1_symbols[linefinal[2]], puzzle_1_symbols_transform[2].position, puzzle_1_symbols_transform[2].rotation, GameObject.Find("Symbol_Line_3").GetComponent<Transform>());
        Instantiate(puzzle_1_symbols[linefinal[3]], puzzle_1_symbols_transform[3].position, puzzle_1_symbols_transform[3].rotation, GameObject.Find("Symbol_Line_4").GetComponent<Transform>());
        Instantiate(puzzle_1_symbols[linefinal[4]], puzzle_1_symbols_transform[4].position, puzzle_1_symbols_transform[4].rotation, GameObject.Find("Symbol_Line_5").GetComponent<Transform>());

    //LINE1
    
    for(int i = 0 ; i <= 3 ; i++)
    {
        int l1pick = line_1[Random.Range(0,line_1.Count)];
        Instantiate(puzzle_1_dalles[liner1[Random.Range(0,21)]], puzzle_1_line1[l1pick].position, puzzle_1_line1[l1pick].rotation, GameObject.Find("Line1").GetComponent<Transform>());
        line_1.Remove(l1pick);
    }
    if(line_1picker == 0)
    {
        Instantiate(puzzle_1_gooddalles[0], puzzle_1_line1[line_1[0]].position, puzzle_1_line1[line_1[0]].rotation, GameObject.Find("Line1").GetComponent<Transform>());
    }
    if(line_1picker == 1)
    {
        Instantiate(puzzle_1_gooddalles[1], puzzle_1_line1[line_1[0]].position, puzzle_1_line1[line_1[0]].rotation, GameObject.Find("Line1").GetComponent<Transform>());
    }
    if(line_1picker == 4)
    {
        Instantiate(puzzle_1_gooddalles[5], puzzle_1_line1[line_1[0]].position, puzzle_1_line1[line_1[0]].rotation, GameObject.Find("Line1").GetComponent<Transform>());
    }
    if(line_1picker == 5)
    {
        Instantiate(puzzle_1_gooddalles[4], puzzle_1_line1[line_1[0]].position, puzzle_1_line1[line_1[0]].rotation, GameObject.Find("Line1").GetComponent<Transform>());
    }
    
    //
    //LINE2
    for(int i = 0 ; i <= 3 ; i++)
    {
        int l2pick = line_2[Random.Range(0,line_2.Count)];
        Instantiate(puzzle_1_dalles[liner2[Random.Range(0,22)]], puzzle_1_line2[l2pick].position, puzzle_1_line2[l2pick].rotation, GameObject.Find("Line2").GetComponent<Transform>());
        line_2.Remove(l2pick);
    }
    if(line_2picker == 1)
    {
        Instantiate(puzzle_1_gooddalles[3], puzzle_1_line2[line_2[0]].position, puzzle_1_line2[line_2[0]].rotation, GameObject.Find("Line2").GetComponent<Transform>());
    }
    if(line_2picker == 3)
    {
        Instantiate(puzzle_1_gooddalles[0], puzzle_1_line2[line_2[0]].position, puzzle_1_line2[line_2[0]].rotation, GameObject.Find("Line2").GetComponent<Transform>());
    }
    if(line_2picker == 4)
    {
        Instantiate(puzzle_1_gooddalles[1], puzzle_1_line2[line_2[0]].position, puzzle_1_line2[line_2[0]].rotation, GameObject.Find("Line2").GetComponent<Transform>());
    }
    //
    //LINE3
    for(int i = 0 ; i <= 3 ; i++)
    {
        int l3pick = line_3[Random.Range(0,line_3.Count)];
        Instantiate(puzzle_1_dalles[liner3[Random.Range(0,22)]], puzzle_1_line3[l3pick].position, puzzle_1_line3[l3pick].rotation, GameObject.Find("Line3").GetComponent<Transform>());
        line_3.Remove(l3pick);
    }
    if(line_3picker == 0)
    {
        Instantiate(puzzle_1_gooddalles[2], puzzle_1_line3[line_3[0]].position, puzzle_1_line3[line_3[0]].rotation, GameObject.Find("Line3").GetComponent<Transform>());
    }
    if(line_3picker == 2)
    {
        Instantiate(puzzle_1_gooddalles[0], puzzle_1_line3[line_3[0]].position, puzzle_1_line3[line_3[0]].rotation, GameObject.Find("Line3").GetComponent<Transform>());
    }
    if(line_3picker == 5)
    {
        Instantiate(puzzle_1_gooddalles[1], puzzle_1_line3[line_3[0]].position, puzzle_1_line3[line_3[0]].rotation, GameObject.Find("Line3").GetComponent<Transform>());
    }
    //
    //LINE4
    for(int i = 0 ; i <= 3 ; i++)
    {
        int l4pick = line_4[Random.Range(0,line_4.Count)];
        Instantiate(puzzle_1_dalles[liner4[Random.Range(0,23)]], puzzle_1_line4[l4pick].position, puzzle_1_line4[l4pick].rotation, GameObject.Find("Line4").GetComponent<Transform>());
        line_4.Remove(l4pick);
    }
    if(line_4picker == 2)
    {
        Instantiate(puzzle_1_gooddalles[3], puzzle_1_line4[line_4[0]].position, puzzle_1_line4[line_4[0]].rotation, GameObject.Find("Line4").GetComponent<Transform>());
    }
    if(line_4picker == 3)
    {
        Instantiate(puzzle_1_gooddalles[2], puzzle_1_line4[line_4[0]].position, puzzle_1_line4[line_4[0]].rotation, GameObject.Find("Line4").GetComponent<Transform>());
    }
    //
    //LINE5
    for(int i = 0 ; i <= 3 ; i++)
    {
        int l5pick = line_5[Random.Range(0,line_5.Count)];
        Instantiate(puzzle_1_dalles[liner5[Random.Range(0,22)]], puzzle_1_line5[l5pick].position, puzzle_1_line5[l5pick].rotation, GameObject.Find("Line5").GetComponent<Transform>());
        line_5.Remove(l5pick);
    }
    if(line_5picker == 0)
    {
        Instantiate(puzzle_1_gooddalles[4], puzzle_1_line5[line_5[0]].position, puzzle_1_line5[line_5[0]].rotation, GameObject.Find("Line5").GetComponent<Transform>());
    }
    if(line_5picker == 2)
    {
        Instantiate(puzzle_1_gooddalles[5], puzzle_1_line5[line_5[0]].position, puzzle_1_line5[line_5[0]].rotation, GameObject.Find("Line5").GetComponent<Transform>());
    }
    if(line_5picker == 4)
    {
        Instantiate(puzzle_1_gooddalles[2], puzzle_1_line5[line_5[0]].position, puzzle_1_line5[line_5[0]].rotation, GameObject.Find("Line5").GetComponent<Transform>());
    }
    //
}

public void Puzzle_1_Generator()
{
        GameObject[] symbols = GameObject.FindGameObjectsWithTag("Puzzle_1_Symbol");
        GameObject[] dalles = GameObject.FindGameObjectsWithTag("BadTrigger");
        GameObject[] gooddalles = GameObject.FindGameObjectsWithTag("GoodTrigger");
        foreach(GameObject Puzzle_1_Symbol in symbols)
        GameObject.Destroy(Puzzle_1_Symbol);
        foreach(GameObject BadTrigger in dalles)
        GameObject.Destroy(BadTrigger);
        foreach(GameObject GoodTrigger in gooddalles)
        GameObject.Destroy(GoodTrigger);
        Puzzle_1_First_Generation();
}

List<T> CreateList<T>(params T[] values)
{
    return new List<T>(values);
}
    
}


