using UnityEngine;
using System.Collections;

public class Gui_testing_board : MonoBehaviour {

	public static Gui_testing_board GUIControl;
	public string public_mode;
	public string menu_mode;

	private string tempx, tempy;
	private int x, y;


	void Awake(){
		if(GUIControl == null){
			DontDestroyOnLoad(gameObject);
			GUIControl = this;
		}
		else if(GUIControl != this){
			Destroy(gameObject);
		}
	}

	void Start(){
		public_mode = "flatland";
		menu_mode = "";
		x = 1;
		y = 1;
		tempx = "1";
		tempy = "1";
	}

	void OnGUI(){

		//Left
		GUILayout.BeginArea(new Rect(5,5,Screen.width * 0.2f - 10,Screen.height/2 - 5));
		{
			if(menu_mode == "save"){
				GUILayout.BeginVertical(); // also can put width in here
				{
					GUILayout.Label("Save/Load");
					if(GUILayout.Button("save"))
						GameControl.Control.save();
					if(GUILayout.Button("load"))
						GameControl.Control.load();
					GUILayout.BeginHorizontal();
					{
						tempx = GUILayout.TextField(tempx,3);
						tempy = GUILayout.TextField(tempy,3);
						if(GUILayout.Button("new")){
							if(int.TryParse(tempx,out x)){
								if(int.TryParse(tempy,out y)){
									board.BoardControl.new_board(x,y);
								}
							}
						}

					}
					GUILayout.EndHorizontal();
				}
				GUILayout.EndVertical();
			}
		}
		GUILayout.EndArea();

		//Right
		GUILayout.BeginArea(new Rect(Screen.width * 0.8f - 5,5,Screen.width * 0.2f - 10,Screen.height/2 - 5));
		{
			if(menu_mode == "hex"){
				GUILayout.BeginVertical(); // also can put width in here
				{
					GUILayout.Label("Change Hex");
					GUILayout.Label("Current type: " + public_mode);
					if(GUILayout.Button("flatland"))
						public_mode = "flatland";
					if(GUILayout.Button("forest"))
						public_mode = "forest";
					if(GUILayout.Button("hill"))
						public_mode ="hill";
					if(GUILayout.Button("mountain"))
						public_mode = "mountain";
					if(GUILayout.Button("water"))
						public_mode = "water";
					if(GUILayout.Button("lava"))
						public_mode = "lava";
					if(GUILayout.Button("stronghold"))
						public_mode = "stronghold";
				}
				GUILayout.EndVertical();
			}

			if(menu_mode == "unit"){
				GUILayout.Label("Change Unit");
				GUILayout.Label("Current type: " + public_mode);
				if(GUILayout.Button("cavalry"))
					public_mode = "cavalry";
				if(GUILayout.Button("swordsmen"))
					public_mode = "swordsmen";
				if(GUILayout.Button("delete"))
					public_mode = "delete";
			}
		}
		GUILayout.EndArea();


		//Bottom
		GUILayout.BeginArea(new Rect(5,Screen.height - 30 ,Screen.width - 10, 25));
		{
			GUILayout.BeginHorizontal(); // also can put width in here
			{
				GUILayout.Label("menu_mode");
				if(GUILayout.Button("Save/Load")){
					menu_mode = "save";
					public_mode = "";
				}
				if(GUILayout.Button("Hex mode")){
					menu_mode = "hex";
				}
				if(GUILayout.Button("Unit mode")){
					menu_mode = "unit";
					public_mode = "";
				}
				if(GUILayout.Button("Map")){
					menu_mode = "";
					public_mode = "";
				}
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();

	}	
}
