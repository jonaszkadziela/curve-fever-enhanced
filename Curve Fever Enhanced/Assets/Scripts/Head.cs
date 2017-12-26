using UnityEngine;

public class Head : MonoBehaviour
{
	public float movementSpeed = 3f;
	public float turnSpeed = 250f;
	public string inputAxis = "Horizontal";
	private float horizontal;

	void Update()
	{
		horizontal = Input.GetAxisRaw(inputAxis);
	}

	void FixedUpdate()
	{
		transform.Translate(Vector2.up * movementSpeed * Time.fixedDeltaTime, Space.Self);
		transform.Rotate(Vector3.forward * -horizontal * turnSpeed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Hazard")
		{
			Destroy(gameObject);
			GameManager.Instance.GameOver();
		}
	}
}
