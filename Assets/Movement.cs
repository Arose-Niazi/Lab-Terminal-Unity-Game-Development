using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
	[SerializeField] public float speed = 10;
	[SerializeField] public GameObject damageEffect;
	[SerializeField] public Text[] scoresFields;
	[SerializeField] public GameObject endGamePanel;
	
	private Rigidbody _rigidbody;
	private int _currentScore;
	
	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}


	private void Update()
	{
		if (transform.position.y < 0)
		{
			Time.timeScale = 0;
			endGamePanel.SetActive(true);
		}
	}

	void FixedUpdate()
	{
		float movementHorizontal = Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (movementHorizontal, 0.0f, movementVertical);
		_rigidbody.AddForce (movement * speed);
	}

	private void OnTriggerExit(Collider other)
	{
		_currentScore++;
		foreach (var t in scoresFields)
		{
			t.text = "Score: " + _currentScore;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (!other.gameObject.CompareTag("Obstacles"))
			return;
		_currentScore -= 0;
		if (_currentScore < 0)
			_currentScore = 0;

		foreach (var t in scoresFields)
		{
			t.text = "Score: " + _currentScore;
		}

		Destroy(Instantiate(damageEffect, transform.position, Quaternion.identity), 3f);

	}

	
}