using UnityEngine;
using System.Collections;

public class test_movement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp_position = new Vector3();
		temp_position = transform.position;

		if(Input.GetButtonDown("a")){
			temp_position[0] += -1.732f;
			transform.position = temp_position;
		}
		else if(Input.GetButtonDown("d")){
			temp_position[0] += 1.732f;
			transform.position = temp_position;
		}
		else if(Input.GetButtonDown("w")){
			temp_position[0] += -0.866f;
			temp_position[2] += 1.5f;
			transform.position = temp_position;
		}
		else if(Input.GetButtonDown("s")){
			temp_position[0] += 0.866f;
			temp_position[2] += -1.5f;
			transform.position = temp_position;
		}
		else return;
		transform.position = temp_position;

	}


}
