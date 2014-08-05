using UnityEngine;
using System.Collections;

public class unit_script : MonoBehaviour {

	void OnMouseDown(){
		Debug.Log("unit 1");
		if(GUIUtility.hotControl == 0 && Gui_testing_board.GUIControl.menu_mode == "unit"){
			Debug.Log("unit 2");
			if(Gui_testing_board.GUIControl.public_mode == "delete"){
				Debug.Log("unit 3");
				if(this.transform.parent.tag == "main")
					this.transform.parent.GetComponent<change_hex>().current_unit = null;
				Destroy(gameObject);
			}
		}
	}
}
