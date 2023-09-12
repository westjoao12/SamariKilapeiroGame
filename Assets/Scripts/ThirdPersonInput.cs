using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour
{

    public FixedJoystick LeftJoystick;
    //public FixedButton Button;
    public Joybutton joybutton;
    public FixedTouchField TouchField;

    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;

    private RaycastHit hit;
    public GameObject cabeca;
   
    public float velocidadeDeMovimento = 2;


    protected ThirdPersonUserControl Control;
    // Start is called before the first frame update
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();
        //joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        //Control.m_Jump = Button.Pressed;
        Control.m_Jump = joybutton.Pressed;
 


        //Control.Hinput = LeftJoystick.inputVector.x;
        Control.Hinput = LeftJoystick.Horizontal;
        Control.Vinput = LeftJoystick.Vertical;

        Camera.main.transform.LookAt(cabeca.transform);

        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

        if (!Physics.Linecast(cabeca.transform.position, transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 5, -5)))
        {


            Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 5, -5);

            Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
                        
            Debug.DrawLine(cabeca.transform.position, transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 5, -5));




        }
        else if (Physics.Linecast(cabeca.transform.position, transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 5, -5), out hit))
        {



            Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 5, -5);

            Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

            Debug.DrawLine(cabeca.transform.position, transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 5, -5));

            //================================================================///////=================================================================
            //Camera.main.transform.position = Vector3.Lerp(transform.position, hit.point, (velocidadeDeMovimento * 2) * Time.deltaTime);
            //Debug.DrawLine(cabeca.transform.position, hit.point);
        }

        //Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 5, -5);
        //Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
    }
}
