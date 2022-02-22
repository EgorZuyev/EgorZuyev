using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 targetPos;
    public GameObject cam;
    public bool yCoordinates;
    public float Movespeed;
    public bool auto;
    public bool position;
    Quaternion startRotation;
    bool UpView = false;
    Vector3 CamTransform;
    public Quaternion additionalAngle;
    public Quaternion _additionalAngle, Angle;
    private float x,y;
    public float z;

    void Start(){
        if(Movespeed == 0)
        {
            Movespeed = 6f;
        }
        transform.position = target.position;
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("_Vertical") != 0)
        {
            y += Input.GetAxis("_Vertical");
        }
        
        CamTransform = cam.transform.position;
        if(Input.GetKeyDown(KeyCode.C)){UpView = !UpView; View();}
        if(auto)
        {
            cam.transform.LookAt(targetPos);
        }
        if(position)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Movespeed * Time.fixedDeltaTime);
            _additionalAngle = transform.rotation;
            Angle.y = y + target.rotation.y;
        }
        targetPos = target.position;

        if(!yCoordinates)
        {
            targetPos.y = 0;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Movespeed * Time.fixedDeltaTime / 2);
    }
    void View()
    {
        if(UpView){cam.transform.position = new Vector3(CamTransform.x,CamTransform.y += 3, CamTransform.z);}
        else
        {
            cam.transform.position = new Vector3(CamTransform.x,CamTransform.y -= 3, CamTransform.z);
        }
    }
}
