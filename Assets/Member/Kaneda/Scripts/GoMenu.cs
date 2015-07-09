using UnityEngine;
using System.Collections;

public class GoMenu : MonoBehaviour {

	public string loadlevelName;

	public void LoadScene(){
		Application.LoadLevel(loadlevelName);
	}
}
