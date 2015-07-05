using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody>();
		setCountText(0);
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			setCountText(count + 1);
		}
	}

	void setCountText(int count) {
		this.count = count;
		countText.text = "Count : " + count.ToString();
		if (count >= 10) {
			winText.text = "You Win!";
		}
	}
}
