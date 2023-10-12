using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicPlayerMovement : MonoBehaviour
{
    public int AliveState;
    public float jump = 10f;
    public float speed = 0.1f;
    public float baseSpeed = 5.0f;
    bool inTutorial = false;

    public GameObject levelName;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            inTutorial = true;
        }
        AliveState = 0;
    }

    public void HazardDeath()
    {
        if(AliveState == 2 || AliveState == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (inTutorial)
        {
        }
        else
        {
            switch (AliveState)
            {
                case 0:
                    if (Input.touchCount > 0) { 
                        AliveState = 1; 
                        levelName.SetActive(false);
                    }
                    break;
                case 1:
                    if (transform.position.y < -50)
                    {
                        AliveState = 2;
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


                            Quaternion faceAngle = Quaternion.LookRotation(touchPos, Vector3.up);

                            transform.rotation = faceAngle;

                            //transform.position += touchPos;

                            transform.Translate(Vector3.forward * speed * Time.deltaTime);


                        }
                        else
                        {
                            transform.Translate(Vector3.forward * baseSpeed * Time.deltaTime);
                        }
                        break;
                    }
                case 2:
                case 3:
                    break;
            }
        }
        
    }
}