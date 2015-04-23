using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletSpawner : MonoBehaviour
{

    //pool of bullets
    public GameObject bullet;
    private List<GameObject> bullets;
    public int poolAmount = 75;

    //angle info
    public float angle = 0.0f;
    float timer = 0.0f;
    public float rotateAmount = 180;

    //firing
    public float fireRate = .2f;
    private float lastFired = 0.0f;

    //spawner type
    public enum SpawnerType { Player, Enemy };
    public SpawnerType type;



    // Use this for initialization
    void Start()
    {
        //pool bullets in a list
        bullets = new List<GameObject>();

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.SetActive(false); //set active to false
            if (type == SpawnerType.Enemy)
                bullet.GetComponent<Bullet>().bType = Bullet.BulletType.Enemy;
            else if (type == SpawnerType.Player)
                bullet.GetComponent<Bullet>().bType = Bullet.BulletType.Player;
            obj.transform.position = transform.position;
            bullets.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(type)
        {
            case SpawnerType.Player: //player shooting
                firePlayerBullet();
                break;
            case SpawnerType.Enemy: //enemy shooting
                fireEnemyBullet();
                break;
        }
    }

    //fires a bullet.
    void fire()
    {
        for (int j = 0; j < bullets.Count; j++)
        {
            if (!bullets[j].activeInHierarchy)
            {
                bullets[j].transform.position = transform.position;
                if (bullets[j].GetComponent<Bullet>().bType == Bullet.BulletType.Player)
                    bullets[j].transform.Translate(0, .1f, 0);
                bullets[j].transform.rotation = transform.rotation;
                bullets[j].SetActive(true);
                break;
            }
        }
    }

    //returns agnle
    public float getAngle()
    {
        return angle;
    }

    /// <summary>
    /// Fires bullet for player
    /// </summary>
    void firePlayerBullet()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > lastFired)
        {
            lastFired = Time.time + fireRate;
            fire();
        }
    }

    /// <summary>
    /// fires bullet for enemy
    /// </summary>
    void fireEnemyBullet()
    {
        timer += Time.deltaTime;
        if (timer >= .05) //time to shoot?
        {
            fire();
            timer = 0.0f;
        }
        angle += 180 * Time.deltaTime; //rotate the object
        if (angle > 360) //clamp to 360 degrees
            angle -= 360;
        transform.Rotate(new Vector3(0, 0, 1), 180 * Time.deltaTime);
        
    }

}
