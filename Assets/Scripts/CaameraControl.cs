using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CaameraControl : MonoBehaviour
{
    Vector3 TouchStart;
   // public Transform CA;
    public float ZoomOutMin = 20;
    public float ZoomOutMax = 52;
    public Vector3 MaxMoveDistance, MinMoveDistance;
    public CinemachineVirtualCamera cm;
    public bool CameraMode=true;
    public GameObject Parent;

   // public Rigidbody rb;
  //  public string t;

    
    void Start()
    {
    //    rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Input.mousePosition);
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
        if (Input.GetMouseButtonDown(0))
        {
            TouchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit, 10000.0f))
        //    {
        //        if (Camera.main.ScreenToWorldPoint(Input.mousePosition) == TouchStart)
        //        {
        //            t = hit.transform.name.ToString();
        //        }
        //    }
        //}
        if (Input.touchCount == 2)
        {
            Touch TouchZero = Input.GetTouch(0);
            Touch TouchOne = Input.GetTouch(1);

            Vector2 TouchZeroPrevPos = TouchZero.position - TouchZero.deltaPosition;
            Vector2 TouchOnePrevPos = TouchOne.position - TouchOne.deltaPosition;

            float PrevMagnitude = (TouchZeroPrevPos - TouchOnePrevPos).magnitude;
            float CurrentMagnitude = (TouchZero.position - TouchOne.position).magnitude;

            float Difference = CurrentMagnitude - PrevMagnitude;
            Zoom(-Difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = TouchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //  if(CameraMode)
            //  {
            //  transform.position += direction;
            // Vector3 temPos = transform.position;
            //  temPos.x = Mathf.Clamp(temPos.x, MinMoveDistance.x, MaxMoveDistance.x);
            //  temPos.y = Mathf.Clamp(temPos.y, MinMoveDistance.y, MaxMoveDistance.y);
            //  temPos.z = Mathf.Clamp(temPos.z, MinMoveDistance.z, MaxMoveDistance.z);
            //  transform.position = temPos;
            transform.position += direction;
           // }
            //else
            //{
            //    Vector3 TouchEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    Debug.Log(TouchStart + "      " + TouchEnd);
            //    if (TouchEnd.x < TouchStart.x)
            //    {
            //        Debug.Log("Left");
            //        Parent.transform.Rotate(new Vector3(0f, 2f, 0f));
            //    }
            //    else if(TouchEnd.x > TouchStart.x)
            //    {
            //        Debug.Log("Right");
            //        Parent.transform.Rotate(new Vector3(0f, -2f, 0f));
            //    }
            //    //if(direction.y>0)
            //    //{
            //    //    Debug.Log("Right");
            //    //}
            //    //else
            //    //{
            //    //    Debug.Log("Left");
            //    //}
            //}
           // rb.AddForce(direction * 1.5f, ForceMode.Impulse);
           // StartCoroutine(Incres());
        }
        Zoom(Input.GetAxis("Mouse ScrollWheel"));

    }
    void Zoom(float increment)
    {
        cm.m_Lens.OrthographicSize = Mathf.Clamp(cm.m_Lens.OrthographicSize - increment, ZoomOutMin, ZoomOutMax);
    // Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, ZoomOutMin, ZoomOutMax);
    }
    IEnumerator Incres()
    {
        yield return new WaitForSeconds(0.7f);
       // rb.drag = 100;
        StartCoroutine("stop");
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(0.5f);
      //  rb.drag = 2.5f;
        StopAllCoroutines();
    }


    public void SwitchPriority()
    {

    }


    public void ChangeCamMode()
    {
        if(CameraMode)
        {
            CameraMode = false;
        }
        else
        {
            CameraMode=true;
        }
    }
}
