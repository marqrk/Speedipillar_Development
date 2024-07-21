using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class BasicPlayerMovement : MonoBehaviour
{
    public int AliveState;
    public float acceleration;
    public float speed = 0.1f;
    public float baseAccel;
    public float baseSpeed = 5.0f;
    public float gravity;

    public float jumpSpeed;

    public Animator animator;
    public GameObject topParent;
    public int aliveVal;

    public GameObject ControlStick;
    public GameObject ControlStickBG;

    bool inTutorial = false;

    public Rigidbody cubeRigibody;

    public GameObject levelName;

    public GameObject JsonHandler;

    public bool usingStick;

    Quaternion lastFacingDir;

    // Start is called before the first frame update
    void Start()
    {
        usingStick = JsonHandler.GetComponent<JsonHandlerScript>().playerSettings.StickControls;
        
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            inTutorial = true;
        }
        AliveState = 0;
        cubeRigibody = GetComponent<Rigidbody>();
        cubeRigibody.constraints = RigidbodyConstraints.FreezeRotationZ|RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationX;
        if (!usingStick)
        {
            ControlStick.SetActive(false);
            ControlStickBG.SetActive(false);
        }

        animator = topParent.GetComponent<Animator>();
        aliveVal = animator.GetInteger("AliveState");

        lastFacingDir = transform.rotation;
}

    public void LevelSelect() { SceneManager.LoadScene(2); }
    public void HazardDeath()
    {
        if(AliveState == 2 || AliveState == 3 || AliveState == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inTutorial)
        {
        }
        else
        {

            if (usingStick)
            {
                switch (AliveState)
                {
                    case 0:
                        if (Input.touchCount > 0)
                        {
                            cubeRigibody.rotation = Quaternion.Euler(0, cubeRigibody.rotation.y, 0);
                            AliveState = 1;
                            animator.SetInteger("AliveState", 1);
                            levelName.SetActive(false);
                        }
                        break;
                    case 1:
                        if (transform.position.y < -50)
                        {
                            AliveState = 2;
                            animator.SetInteger("AliveState", 2);


                            HazardDeath();
                            break;
                        }
                        else
                        {
                            
                            //Movement for Controlstick handled in ControlStickScript.cs
                            break;
                        }
                    case 2:
                        cubeRigibody.constraints = RigidbodyConstraints.None;
                        animator.SetInteger("AliveState", 2);
                        break;
                    case 3:
                        animator.SetInteger("AliveState", 0);
                        break;
                    case 4:
                        if (cubeRigibody.velocity.magnitude < speed)
                        {
                            cubeRigibody.AddForce(transform.forward * baseAccel);
                        }
                        break;
                }
            }
            else
            {
                switch (AliveState)
                {
                    case 0:
                        if (Input.touchCount > 0)
                        {
                            cubeRigibody.rotation = Quaternion.Euler(0, cubeRigibody.rotation.y, 0);
                            AliveState = 1;
                            animator.SetInteger("AliveState", 1);
                            levelName.SetActive(false);
                        }
                        break;
                    case 1:
                        if (transform.position.y < -50)
                        {
                            AliveState = 2;
                            animator.SetInteger("AliveState", 2);

                            HazardDeath();
                            break;
                        }
                        else
                        {
                            if (Input.touchCount > 0)
                            {
                                Touch touch = Input.GetTouch(0);
                                Vector3 touchPos = Camera.main.ScreenToViewportPoint(touch.position);

                                //convert the screen coordinates of the touch to +/- axis centered on the middle of the screen
                                touchPos.z = touchPos.y;
                                touchPos.y = 0f;
                                touchPos.x -= 0.5f;
                                //touchPos.x *= speed;
                                touchPos.z -= 0.5f;
                                //touchPos.z *= speed;

                                //Figure out the math on this later to incorporate distance from center as a speed control
                                //float moveMagnitude = Mathf.Sqrt(Mathf.Pow(touchPos.x, 2) * Mathf.Pow(touchPos.z, 2));

                                Quaternion faceAngle = Quaternion.LookRotation(touchPos);

                                Vector3 rotation = new Vector3(faceAngle.eulerAngles.x, faceAngle.eulerAngles.y, 0f);

                                rotation.x = Mathf.Clamp(rotation.x, -45f, 45);

                                cubeRigibody.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);



                                if (cubeRigibody.velocity.magnitude < speed)
                                {

                                    if(Quaternion.Angle(transform.rotation, lastFacingDir) > 170 && Quaternion.Angle(transform.rotation, lastFacingDir) < 190){
                                        cubeRigibody.AddForce(Vector3.up * jumpSpeed);
                                    }
                                    
                                    cubeRigibody.AddForce(transform.forward * acceleration);
                                }

                                lastFacingDir = transform.rotation;
                                // Might use this later for a gravity changing level
                                //cubeRigibody.AddForce(Vector3.down * gravity * cubeRigibody.mass);

                                //cubeRigibody.MovePosition(transform.position + touchPos * speed * Time.deltaTime);

                                //transform.rotation = faceAngle;

                                //transform.position += touchPos;

                                //transform.Translate(Vector3.forward * speed * Time.deltaTime);


                            }
                            else
                            {

                                Vector3 rotation = new Vector3(cubeRigibody.transform.rotation.eulerAngles.x, cubeRigibody.transform.rotation.eulerAngles.y, 0f);

                                rotation.x = Mathf.Clamp(rotation.x, -45f, 45);

                                cubeRigibody.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

                                if (cubeRigibody.velocity.magnitude < baseSpeed)
                                {
                                    cubeRigibody.AddForce(transform.forward * baseAccel);
                                }

                                //cubeRigibody.AddForce(Vector3.down * gravity * cubeRigibody.mass);

                                //transform.Translate(Vector3.forward * baseSpeed * Time.deltaTime);
                            }
                            break;
                        }
                    case 2:
                        cubeRigibody.constraints = RigidbodyConstraints.None;
                        animator.SetInteger("AliveState", 0);

                        break;
                    case 3:
                        break;
                    case 4:
                        if (cubeRigibody.velocity.magnitude < speed)
                        {
                            cubeRigibody.AddForce(transform.forward * baseAccel);
                        }
                        break;
                }
            }
        
        }
        
    }
}