using UnityEngine;
using System.Collections;

public class board : MonoBehaviour {

	public static board BoardControl;
	public GameObject hex;
	public int horizontal_length;
	public int vertical_length;
	private float offset;
	private float short_dist;
	private float long_dist;

	void Awake(){
		if(BoardControl == null){
			DontDestroyOnLoad(gameObject);
			BoardControl = this;
		}
		else if(BoardControl != this){
			Destroy(gameObject);
		}
	}

	void Start () {
		offset = Mathf.Sqrt(1.0f - (0.5f * 0.5f));
		short_dist = 2.0f * offset;
		long_dist = 1.5f;
		
		GameControl.Control.game_board = new GameObject[0,0];//so I can use new_board
		new_board(horizontal_length,vertical_length);
	}

	void clear_board(){
		for(int i = 0; i < GameControl.Control.game_board.GetLength(0); i++){
			for(int j = 0; j < GameControl.Control.game_board.GetLength(1); j++){
				Destroy(GameControl.Control.game_board[i,j]);
			}
		}
	}

	public void new_board(int new_horizontal, int new_vertical){
		clear_board();
		transform.position = Vector3.zero;
		GameControl.Control.game_board = new GameObject[new_horizontal,new_vertical];
		for(int i = 0; i < GameControl.Control.game_board.GetLength(0); i++){
			for(int j = 0; j < GameControl.Control.game_board.GetLength(1); j++){
				GameControl.Control.game_board[i,j] = Instantiate(hex, transform.position, transform.rotation) as GameObject;
				transform.Translate(short_dist, 0.0f, 0.0f);
			}
			transform.Translate(offset - (GameControl.Control.game_board.GetLength(1) * short_dist), long_dist, 0.0f);//long dist is in y instead of z becausethe the game pieces are oriented for that
			offset *= -1;
		}
	}

}
