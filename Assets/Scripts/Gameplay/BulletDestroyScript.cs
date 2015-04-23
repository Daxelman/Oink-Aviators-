using UnityEngine;
using System.Collections;

public class BulletDestroyScript : MonoBehaviour {

    public float killTime = 3.0f;

    void OnEnable()
    {
        Invoke("killBullet",killTime);
    }

    void killBullet()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
	
}
