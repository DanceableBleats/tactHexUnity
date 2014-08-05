using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {
	
	public static GameControl Control;
	public GameObject sample_gameobj;
	
	public GameObject[,] game_board;
	public int number;
	public int[,] array_test;
	
	void Awake(){
		if(Control == null){
			DontDestroyOnLoad(gameObject);
			Control = this;
		}
		else if(Control != this){
			Destroy(gameObject);
		}
	}
	
	
	
	
	
	public void save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/Save_number.cupcake");


		hex_array_info data = new hex_array_info(game_board);
		
		
		bf.Serialize(file,data);
		file.Close();
	}
	
	public void load(){
		if(File.Exists(Application.persistentDataPath + "/Save_number.cupcake")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/Save_number.cupcake", FileMode.Open);
			
			hex_array_info data = (hex_array_info)bf.Deserialize(file);
			file.Close();
			
			data.SetGameObject_array(ref game_board, sample_gameobj);
			
		}
	}
}





[Serializable]
class hex_array_info{
	public hex_info[,] all_hexs;
	public hex_array_info(){
		
	}
	public hex_array_info(GameObject[,] gameobj_array){
		all_hexs = new hex_info[gameobj_array.GetLength(0),gameobj_array.GetLength(1)];
		for(int i = 0; i < gameobj_array.GetLength(0); i++){
			for(int j = 0; j < gameobj_array.GetLength(1); j++){
				all_hexs[i,j] = new hex_info(gameobj_array[i,j]);
			}
		}
	}
	
	public hex_array_info(ref GameObject[,] gameobj_array, GameObject sample_gameobj){
		all_hexs = new hex_info[gameobj_array.GetLength(0),gameobj_array.GetLength(1)];
		SetGameObject_array(ref gameobj_array, sample_gameobj);
	}
	
	public hex_array_info(int size0, int size1){
		all_hexs = new hex_info[size0,size1];
		clear_board();
	}
	
	void clear_board(){
		for( int i = 0 ; i < all_hexs.GetLength(0); i++){
			for( int j = 0 ; j < all_hexs.GetLength(0); j++){
				all_hexs[i,j] = new hex_info();
			}
		}
	}
	
	public void SetGameObject_array(ref GameObject[,] orig, GameObject sample_gameobj){
		for(int i = 0; i < orig.GetLength(0); i++)
			for(int j = 0; j < orig.GetLength(1); j++)
				GameObject.Destroy(orig[i,j]);
		
		orig = new GameObject[all_hexs.GetLength(0), all_hexs.GetLength(1)];
		
		for(int i = 0; i < all_hexs.GetLength(0); i++)
			for(int j = 0; j < all_hexs.GetLength(1); j++)
				orig[i,j] = all_hexs[i,j].IntoGameObject(sample_gameobj);
		
	}
	
}

[Serializable]
class hex_info{
	public Vector_serial posistion_data; 
	public Vector_serial quadrian_data;
	public string hex_type;


	public hex_info(){
	}
	public hex_info(GameObject gameobj){
		posistion_data = new Vector_serial(gameobj.transform.position);
		quadrian_data = new Vector_serial(gameobj.transform.eulerAngles);
		hex_type = gameobj.GetComponent<change_hex>().currentModel.name;
	}
	public GameObject IntoGameObject(GameObject sample_gameobj){
		GameObject gameobj = GameObject.Instantiate(sample_gameobj) as GameObject;
		gameobj.name = sample_gameobj.name;
		gameobj.transform.position = posistion_data.ToVector3();
		gameobj.transform.eulerAngles = quadrian_data.ToVector3();
		gameobj.GetComponent<change_hex>().change_model(hex_type);
		return gameobj;
	}
}

[Serializable]
class Vector_serial{
	public float x_data;
	public float y_data;
	public float z_data;
	public Vector_serial(){
		
	}
	public Vector_serial(float x, float y, float z){
		x_data = x;
		y_data = y;
		z_data = z;
	}
	public Vector_serial(Vector3 vec3){
		x_data = vec3[0];
		y_data = vec3[1];
		z_data = vec3[2];
	}
	public Vector3 ToVector3(){
		return new Vector3(x_data, y_data, z_data);
	}
}

