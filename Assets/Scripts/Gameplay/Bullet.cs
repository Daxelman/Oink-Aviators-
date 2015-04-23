using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float bSpeed = 10.0f;
    float bX;
    float bY;
    float angle;

    //reference to the spawner object
    public GameObject spawner;

    //type of bullet
    public enum BulletType { Player, Enemy };
    public BulletType bType;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (bType)
        {
            case BulletType.Player:
                transform.Translate(0, bSpeed * Time.deltaTime, 0);
                break;
            case BulletType.Enemy:
                //while the bullet is inactive, grab info from the spawner about it's rotation angle
                while (this.isActiveAndEnabled == false)
                {
                    //using the angle, calucalte unit x and y locations
                    angle = getAngle();

                    bX = Mathf.Cos(angle);
                    bY = Mathf.Sin(angle);
                }
                //move the bullet in the direction gained from figuring out said vector. 
                transform.Translate(bX + (bSpeed * Time.deltaTime), bY + (bSpeed * Time.deltaTime), 0);
                break;
        }

    }

    float getAngle()
    {
        float result = 0.0f;
        result = spawner.GetComponent<BulletSpawner>().getAngle();
        return result;
    }
}
