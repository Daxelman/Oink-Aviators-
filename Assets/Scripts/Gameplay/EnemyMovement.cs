using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
    float timer = 0f;
    float speed = 1f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer >= .7f)
        {
            speed *= -1;
            timer = 0;
        }
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);

	}
}
