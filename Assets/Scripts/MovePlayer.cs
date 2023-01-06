using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 speed_vector;
    CharacterController Cc;
    private ArduinoConnector ardConnect;
    
    Vector3 direction = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();
        ardConnect = ArduinoConnector.Instance;
    }

    // Update is called once per frame
    void Update()
    {


        /*
        if (GameManager.Instance.GameIsOver || GameManager.instance.GameIsPaused) return;
        */

        //gameObject.transform.position += speed_vector * Time.deltaTime;
        //GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0);

        if (GameManager.Instance.getNumberBatteryAvailable() > 0)
        {
            float directionToGo = ardConnect.direction;
            float speedAllow = ardConnect.direction;

            directionToGo = (directionToGo - 511.0f) / 512.0f;
            speedAllow = (speedAllow - 511.0f) / 512.0f;

            if (Cc.isGrounded || Input.GetAxis("Vertical") != 0)
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                GameManager.Instance.UseBattery();
            }

            //moveDirection.y -= gravity * Time.deltaTime;

            // Input.GetAxis("Horizontal") = 0 - 1
            // 1023
            
            //Debug.Log("[Before]" + directionToGo);
            
            //if (directionToGo < 400)
            //    directionToGo = -1f * directionToGo / 1023f;
            //else if (directionToGo > 600)
            //    directionToGo = directionToGo / 1023f;

            //Debug.Log("[After]" + directionToGo);

            /*
             if(direcion< 400)
                   droite_gauche = -1;
            else if(direction>600)
                    droite_gauche = 1;

            if(speed != 0)
               acc�l�rer 
                consommer
             */

            transform.Rotate(Vector3.up * directionToGo * Time.deltaTime * speed * 10);
            Cc.Move(moveDirection * Time.deltaTime);


        }

        //speed_vector = new Vector3(GameManager.instance.ScrollingSpeed, 0, 0);

        /*
        if (GameManager.Instance.GameIsOver || GameManager.instance.GameIsPaused) return;
        

        //gameObject.transform.position += speed_vector * Time.deltaTime;
        //GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0);

        if (Cc.isGrounded)
        {
            //Debug.Log(Input.GetAxis("Vertical"));
           
        }
        moveDirection = new Vector3(0, 0, 1);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        moveDirection.y -= gravity * Time.deltaTime;


        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 10);
        Cc.Move(moveDirection * Time.deltaTime);
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name); //nom de l'objet qu'on collisione
    }

    
}
