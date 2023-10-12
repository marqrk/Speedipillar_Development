using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovementScript : MonoBehaviour
{
    public Vector3 OriginalPosition;
    // Start is called before the first frame update
    void Start()
    {
        OriginalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToViewportPoint(touch.position);
            

                //touchPos.x -= 0.5f;
                //touchPos.y -= 0.5f;
                //touchPos.z = touchPos.y * 0.5f;

            transform.position = touchPos;
        }
    }
}