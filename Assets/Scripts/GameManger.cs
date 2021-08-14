using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;

public class GameManger : MonoBehaviour
{
   // public GameObject dp;
    //Dropdown m_Dropdown;
  //  public string[] Names;
    public string[] Content;
    public GameObject[] Planet;
    //public GameObject Mercury;
    //public GameObject Venus;
    //public GameObject Earth;
    //public GameObject Mars;
    //public GameObject Jupiter;
    //public GameObject Saturn;
    //public GameObject Uranus;
    //public GameObject Neptune;
   
    public float speed=1;
  //  public int days = 1;
    public bool Play = true;
  //  public int ModeIndex = 0;
    public TextMeshProUGUI Speedtext;
    public TextMeshProUGUI PlayText;
  //  public TextMeshProUGUI ModeText;
    public TextMeshProUGUI InfoArea;

    public int priorityIndex = 0;
    public CinemachineVirtualCamera[] Cams;
    
    public Animator trajectoryanim,InfoTextanim;
    // Start is called before the first frame update


    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(days);
        if (Play)
        {
            Planet[0].transform.Rotate(Vector3.up * 171f * speed * Time.deltaTime);
            Planet[1].transform.Rotate(Vector3.up * 87.25f * speed * Time.deltaTime);
            Planet[2].transform.Rotate(Vector3.up * 28f * speed * Time.deltaTime);
            Planet[3].transform.Rotate(Vector3.up * 12.25f * speed * Time.deltaTime);
            Planet[4].transform.Rotate(Vector3.up * 2f * speed * Time.deltaTime);
            Planet[5].transform.Rotate(Vector3.up * 1f * speed * Time.deltaTime);
            Planet[6].transform.Rotate(Vector3.up * 0.75f * speed * Time.deltaTime);
            Planet[7].transform.Rotate(Vector3.up * 0.25f * speed * Time.deltaTime);
        }
    }
    public void incrementDays()
    {
        //days=days+speed;
    }

    public void IncreseSpeed(int i)
    {
        if (speed != 0)
        {
            if (i == 0 && speed < 8)
            {
                speed *= 2;
                Speedtext.text = speed + "X";
            }
            else if (i == 1)
            {
                speed /= 2;
                if (speed < 1)
                {
                    speed = 1;
                }
                Speedtext.text = speed + "X";

            }
        }
    }
    public void togglePlay()
    {
        if (Play)
        {
            Play = false;
            PlayText.text = "Play";
        }
        else
        {
            Play = true;
            PlayText.text = "Stop";
        }
    }

    //public void SwitchPriority(string direction)
    //{

    //    int len = Cams.Length;
    //    if(direction=="R")
    //    {
    //        if (priorityIndex < 8)
    //            priorityIndex++;
    //        else
    //            priorityIndex = 0;

    //    }
    //    else if (direction =="L")
    //    {
    //        if (priorityIndex > 0)
    //            priorityIndex--;
    //        else
    //            priorityIndex = 8;
    //    }
    //    if(priorityIndex == 0)
    //    {
    //        speed = 1f;
    //        Speedtext.text = speed + "X";
    //        trajectoryanim.SetInteger("trajectoryAnim", 2);
    //    }
    //    else
    //    {
    //        speed = 0f;
    //        Speedtext.text = speed + "X";
    //        trajectoryanim.SetInteger("trajectoryAnim", 1);
    //    }
    //    for (int j = 0; j < len; j++)
    //    {
    //        if (j == priorityIndex)
    //            Cams[j].Priority = 1;
    //        else
    //            Cams[j].Priority = 0;
    //    }
    //    ModeText.text = Names[priorityIndex];
    //}


    public void SetMode(int val)
    {
        int len = Cams.Length;
        priorityIndex = val;
        if (priorityIndex == 0)
        {
            speed = 1f;
            Speedtext.text = speed + "X";
            trajectoryanim.SetInteger("trajectoryAnim", 2);
            //for (int j = 0; j < len-1; j++)
            //{
            //    Planet[j].SetActive(true);
            //}
            StartCoroutine(PlanetToggle());
        }
        else
        {
            speed = 0f;
            Speedtext.text = speed + "X";
            trajectoryanim.SetInteger("trajectoryAnim", 1);
        }
        for (int j = 0; j < len; j++)
        {
            if (j == priorityIndex)
            {
                Cams[j].Priority = 1;
            }
            else
            {
                Cams[j].Priority = 0;
            }
        }
        StartCoroutine(PlanetToggle());


    }
    

    public IEnumerator PlanetToggle()
    {
        yield return new WaitForSeconds(0f);
        int len = Cams.Length;
        if (priorityIndex == 0)
        {
            for (int j = 0; j < len - 1; j++)
            {
                StopAllCoroutines();
                StartCoroutine(PlanetShow(0f, j));
            }
            InfoTextanim.SetInteger("InfoText", 2);
        }
        else
        {
            for (int j = 0; j < len - 1; j++)
            {
                if (j == priorityIndex - 1)
                {
                    StartCoroutine(PlanetShow(0f, j));
                }
                else
                {
                    StartCoroutine(PlanetHide(1.5f, j));
                }
                InfoTextanim.SetInteger("InfoText", 1);
                InfoArea.text = Content[priorityIndex - 1];
                
            }
        }
    }


    public IEnumerator PlanetShow(float f,int index)
    {
        Planet[index].SetActive(true);
        yield return new WaitForSeconds(f);
    }
    public IEnumerator PlanetHide(float f, int index)
    {
        yield return new WaitForSeconds(f);
        Planet[index].SetActive(false);
    }

}
