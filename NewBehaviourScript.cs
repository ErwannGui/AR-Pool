using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

	public Vector3 vt = new Vector3();

public Rigidbody rstick;     //Rigidbody of stick

public Rigidbody rball;     //Rigidbody of ball

public GameObject stick1;   //object stick

public GameObject ball;     //object ball

//public GameObject camera;

 

public Transform target;

public Transform pivot;

public float fRadius = 3.0f;

    Vector3 unit = new Vector3(1, 0, 1);

void Start()

    {

        //pivot = new GameObject().transform;
        pivot = GameObject.FindWithTag("pivot").transform;

        stick1.transform.parent = pivot;

    }

    void Update()

    {

        Roll();

        vt = (ball.transform.position - stick1.transform.position);

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                stick1.SetActive(true);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                stick1.SetActive(false);

                rball.velocity = vt * 2;
            }
        }


        if (Input.touchCount == 2)
        {
            SceneManager.LoadScene("Level");
        }

        /*if (Input.GetKeyUp(K))   

        {

            stick1.SetActive(false);

            rball.velocity = vt*2;

        }*/

            /*if(Input.GetKey(KeyCode.Space))

                    {

                        stick1.SetActive(true);

                    }*/

    }

//Controll stick rotate around white ball

void Roll()

    {

        //Vector3 v3Pos = Camera.main.WorldToScreenPoint(target.position);

        Vector3 v3Pos = Camera.main.WorldToScreenPoint(target.position);

        Debug.Log(v3Pos);

        v3Pos = Input.mousePosition - v3Pos;
		
		Debug.Log(v3Pos);

		float angle = Mathf.Atan2(v3Pos.x, v3Pos.y) * Mathf.Rad2Deg;

        pivot.position = target.position;

        pivot.rotation = Quaternion.AngleAxis(angle, Vector3.up);

    }
}
