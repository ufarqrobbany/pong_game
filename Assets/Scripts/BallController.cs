using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	// Bola
	public int force;
	Rigidbody2D rigid;
	Vector2 arah;

	// Score
	int scoreP1;
	int scoreP2;
	int scoreMenang;
	Text scoreUIP1;
	Text scoreUIP2;

	// Menang
	GameObject panelSelesai;
    Text txPemenang;


    // Audio
    AudioSource audios;
    public AudioClip hitSound;

    void Start() {
    	// Bola
    	rigid = GetComponent<Rigidbody2D>();
		arah = new Vector2(2,0).normalized;
    	rigid.AddForce(arah * force);

    	// Score
        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find ("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find ("Score2").GetComponent<Text>();
        scoreMenang = 10;

        // Menang
        panelSelesai = GameObject.Find ("PanelSelesai");
		panelSelesai.SetActive (false);

		// Audio
		audios = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D coll) {
    	// Audio
    	audios.PlayOneShot(hitSound);

    	if (coll.gameObject.name == "TepiKanan") {
    		// Bola
    		ResetBall();
    		arah = new Vector2(2,0).normalized;
    		rigid.AddForce(arah * force);

    		// Score
    		TambahScoreP1();

    		// Menang
    		MenangP1();   		
    	}

    	if (coll.gameObject.name == "TepiKiri") {
    		// Bola
    		ResetBall();
    		arah = new Vector2(-2,0).normalized;
    		rigid.AddForce(arah * force);

    		// Score
    		TambahScoreP2();

    		// Menang
    		MenangP2();
    	}

    	if (coll.gameObject.name == "Pemukul1" || coll.gameObject.name == "Pemukul2") {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);    
            rigid.AddForce(arah * force * 2);
        }
    }

    void ResetBall() {
    	transform.localPosition = new Vector2 (0,0);
    	rigid.velocity =  new Vector2 (0,0);
    }

    void TampilkanScore() {
  		Debug.Log ("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
 		scoreUIP1.text = scoreP1 + "";
  		scoreUIP2.text = scoreP2 + "";
	}

	void TambahScoreP1() {
		scoreP1 += 1;
    	TampilkanScore();
	}

	void TambahScoreP2() {
		scoreP2 += 1;
    	TampilkanScore();
	}

	void MenangP1() {
		if (scoreP1 == scoreMenang) {
    		panelSelesai.SetActive (true);
    		txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
    		txPemenang.text = "Player Biru Menang! Player Merah Kalah!";
    		Destroy (gameObject);
    		return;
		} 
	}

	void MenangP2() {
		if (scoreP2 == scoreMenang) {
    		panelSelesai.SetActive (true);
    		txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
    		txPemenang.text = "Player Merah Menang! Player Biru Kalah!";
    		Destroy (gameObject);
    		return;
		} 
	}
}
