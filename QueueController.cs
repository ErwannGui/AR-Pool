using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class QueueController : MonoBehaviour {
	
	private float speed = 5f;
	private Vector3 initial_position;
	private float ratio;
	public Vector3 charge;
	
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		initial_position = this.gameObject.transform.position;
		ratio = initial_position.z / initial_position.y;
		Debug.Log(ratio);
        //this.gameObject.name = "Self";
		Debug.Log("Initial :"+initial_position);
		
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		/*//Debug.Log(CheckRange(this.gameObject.transform.position));
		if(Input.GetKey(KeyCode.Space)) {
			float y_load = ToSingle(0.1);
			float z_load = ToSingle(0.1 * ratio);
			Vector3 direction = new Vector3 (0, y_load, z_load);
			direction = direction * speed * Time.deltaTime;
			this.gameObject.transform.position += direction;
			//rb.AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);
			
			charge = this.gameObject.transform.position;
		}
		
		if (Input.GetKeyUp(KeyCode.Space)) {
			//this.gameObject.transform.position = initial_position;
			float y_shoot = ToSingle(initial_position.y - charge.y);
			float z_shoot = ToSingle((initial_position.z + charge.y));
			// Vector3 force = new Vector3(0, y_shoot, z_shoot);
			Vector3 force = new Vector3(0, y_shoot, z_shoot);
			Debug.Log("Charge :"+charge);
			Debug.Log("Force :"+force);
			Debug.Log("Forward :"+this.gameObject.transform.forward);
			rb.AddForce(new Vector3(0, -1, 10), ForceMode.Impulse);
			// ResetPosition();
			// Shoot(15f);
		}*/

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                float y_load = ToSingle(0.1);
                float z_load = ToSingle(0.1 * ratio);
                Vector3 direction = new Vector3(0, y_load, z_load);
                direction = direction * speed * Time.deltaTime;
                this.gameObject.transform.position += direction;
                //rb.AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);

                charge = this.gameObject.transform.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                float y_shoot = ToSingle(initial_position.y - charge.y);
			float z_shoot = ToSingle((initial_position.z + charge.y));
			// Vector3 force = new Vector3(0, y_shoot, z_shoot);
			Vector3 force = new Vector3(0, y_shoot, z_shoot);
			Debug.Log("Charge :"+charge);
			Debug.Log("Force :"+force);
			Debug.Log("Forward :"+this.gameObject.transform.forward);
			rb.AddForce(new Vector3(0, -1, 10), ForceMode.Impulse);
			// ResetPosition();
			// Shoot(15f);
            }
        }

        if (Input.touchCount == 2)
        {
            SceneManager.LoadScene("Level");
        }

    }
	
	public static float ToSingle(double value) {
		return (float)value;
	}

	
	public static bool CheckRange(Vector3 position) {
		if(position.y > position.y-1 && position.y < position.y+1) {
			if(position.z > position.z-4 && position.z < position.z+4) {
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
		
	}
	
	public void Shoot(float speed) {
		Debug.Log("Charge2 :"+charge.y+", "+charge.z);
		float y = ToSingle(charge.y + (initial_position.y - charge.y) - 0.25);
		float z = ToSingle(charge.z + (initial_position.z - charge.z) - (0.25 * ratio));
		Debug.Log(y+", "+z);
		Vector3 shoot = new Vector3(0, y, z);
		Debug.Log("Shoot :"+shoot);
		shoot = shoot * speed * Time.deltaTime;
		this.gameObject.transform.position = shoot;
		//ResetPosition();
	}
	
	public void ResetPosition() {
		this.gameObject.transform.position = initial_position;
	}
}
