using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {


	public float jumpForce = 10f;
	public Rigidbody2D rb; 
	public SpriteRenderer sr;
	public string currentColor;
	public string startColor;
	public GameObject endScore;
	public GameObject deathText;
	public GameObject deathGrey;
	public GameObject cameraID;
	public bool touched;
	public int curr_colour_idx;
	public int prev_colour_idx;
	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink; 
	public bool isDead = false; 
	public int currentScore;
	public Text scoreText;
	public Text scoreText2;
	public ParticleSystem explosion;

	void Start () 
	{
		
		curr_colour_idx = prev_colour_idx = 0;
		SetRandomColor();
		currentScore= 0;
		startColor = currentColor;
		//GetComponent<Rigidbody2D> ().enabled = false;
		//rb.enabled = false;
		//use rigidbody.isKinematic = false;
		//rb.SetActive(false);
		//player.SetActive(false);
		//rb.enabled = !rb.enabled;
		//GetComponent<RigidBody>().Sleep()
		rb.simulated = false;
	}
		
	// Update is called once per frame
	void Update () {
		scoreText.text= currentScore.ToString();
		scoreText2.text= currentScore.ToString();
		//if (isDead)
		//return; 

		if (gameObject.transform.position.y < -4f) ///IF ITS BELOW -4 DIE
		{
			gameObject.SetActive(false);
			Debug.Log ("GAME OVER");
			deathText.SetActive (true);
			endScore.SetActive (false);
			deathGrey.SetActive (true);
		}

		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			rb.simulated = true; 
			rb.velocity = Vector2.up * jumpForce;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "ColorChanger")
		{
			SetRandomColor();
			touched= false;
			Destroy(col.gameObject);
			return;
		}

		if (col.tag != currentColor )
		{
			//Death ();
			gameObject.SetActive(false);
			Debug.Log ("GAME OVER");
			deathText.SetActive (true);
			endScore.SetActive (false);
			deathGrey.SetActive (true);
			//NOW I HAVE TO LOAD DEATH MENU
			
		}
		else if ( col.tag == currentColor && !touched)
		{
			Debug.Log ("Hurray!");
			currentScore++;
			explosion.transform.position= new Vector3(explosion.transform.position.x,gameObject.transform.position.y, 0f); 
			explosion.Play();
			touched=  true;
			//I need to score then!!!!!! 
		}
	}

	void SetRandomColor() 
	{
		prev_colour_idx = curr_colour_idx;
		curr_colour_idx = Random.Range(0, 4);
		//Random.seed = 4;

		while (curr_colour_idx == prev_colour_idx)
			curr_colour_idx = Random.Range(0, 4);

		switch (curr_colour_idx)
		{
			case 0:
				currentColor = "Cyan";
				sr.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
		}

	}

	//public void Death()
	//{
	//	isDead = true;
	//	GetComponent<score>().OnDeath ();
	//	//Debug.Log ("DEAD");
	//}
}
