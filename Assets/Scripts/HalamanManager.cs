using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
	public bool isEscapeToExit;

    void Update() {
        if (Input.GetKeyUp (KeyCode.Escape)) {
    		if (isEscapeToExit) {
        		Application.Quit ();
    		} 
    		else {
        		Menu ();
    		}
		}
    }

    public void Mulai(){
    	SceneManager.LoadScene("PilihArea");
    }

    public void MulaiArea0(){
    	SceneManager.LoadScene("Area0");
    }

    public void Panduan(){
    	SceneManager.LoadScene("Panduan");
    }

    public void Menu(){
    	SceneManager.LoadScene("Menu");
    }

    public void Keluar(){
    	Application.Quit ();
    }
}
