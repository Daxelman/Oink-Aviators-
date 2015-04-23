using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    public float speed = 2;
    protected float pSpeed = 1; //percise speed, added or subtraced from normal speed
    // Update is called once per frame
    void Update()
    {
        //move the object
        if (Input.GetKey(KeyCode.Space))
            speed-=pSpeed;
        if (Input.GetKey(KeyCode.UpArrow)) // up
        {
            moveUp(speed);
        }
        if (Input.GetKey(KeyCode.DownArrow)) // down
        {
            moveDown(speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // left
        {
            moveLeft(speed);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // right
        {
            moveRight(speed);
        }

        //clamp to screen space
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        //reset speed
        if(speed == pSpeed)
            speed+=pSpeed;

    }

    //move methods
    void moveUp(float sp)
    {
        transform.Translate(0, sp * Time.deltaTime, 0);
    }
    void moveDown(float sp)
    {
        transform.Translate(0, -sp * Time.deltaTime, 0);
    }
    void moveLeft(float sp)
    {
        transform.Translate(-sp * Time.deltaTime, 0, 0);
    }
    void moveRight(float sp)
    {
        transform.Translate(sp * Time.deltaTime, 0, 0);
    }
}
