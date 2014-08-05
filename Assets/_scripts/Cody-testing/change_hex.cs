using UnityEngine;
using System.Collections;

public class change_hex : MonoBehaviour {

	public GameObject model1;
	public GameObject[] models;
	public GameObject[] unit_models;
	public GameObject current_unit;
	public GameObject currentModel;


	
	void Start(){
		if(currentModel == null){
			foreach(Transform child in transform)
				if(child.CompareTag("hex"))
					Destroy(child.gameObject);
			currentModel = Instantiate(model1, transform.position, transform.rotation) as GameObject;
			currentModel.name = model1.name;
			currentModel.transform.parent = transform;
		}
	}

	void OnMouseDown(){
		if(GUIUtility.hotControl == 0){
//			int i;
//			for(i = 0; i < models.Length; i++){
//				if(currentModel.name == models[i].name){
//					i++;
//					break;
//				}
//			}
//			if(i == models.Length)
//				i = 0;
//			change_model(models[i]);
			if(Gui_testing_board.GUIControl.menu_mode == "hex")
				change_model(Gui_testing_board.GUIControl.public_mode);
			if(Gui_testing_board.GUIControl.menu_mode == "unit"){
				change_unit(Gui_testing_board.GUIControl.public_mode);
			}

		}
	}

	public void change_model(string name){
		for(int i = 0; i < models.Length; i++){
			if(name == models[i].name){
				change_model(models[i]);
			}
		}


	}

	public void change_unit(string name){
		for(int i = 0; i < unit_models.Length; i++){
			if(name == unit_models[i].name){
				change_unit(unit_models[i]);
			}
		}
		
		
	}

	public void change_model(GameObject target)
	{
		GameObject thisModel = Instantiate(target, transform.position, transform.rotation) as GameObject;
		Destroy(currentModel);
		thisModel.name = target.name;
		thisModel.transform.parent = transform;
		currentModel = thisModel;
		
	}
	public void change_unit(GameObject target)
	{
		GameObject thisModel = Instantiate(target, transform.position, target.transform.rotation) as GameObject;
		thisModel.transform.Translate(0,1.2f,0,Space.World);
		Destroy(current_unit);
		thisModel.name = target.name;
		thisModel.transform.parent = transform;
		current_unit = thisModel;
		
	}
}
