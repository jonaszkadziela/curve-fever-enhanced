using UnityEngine;

public class Head : MonoBehaviour
{
	public float movementSpeed = 3f;
	public float turnSpeed = 250f;
	public string inputAxis = "Horizontal1";

	private Player player;
	private float horizontal;

	void Start()
	{
		player = GetComponentInParent<Player>();
	}

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
		if (col.tag == "Hazard" && !player.isImmune)
		{
			if (GameManager.PlayersAlive > 2)
			{
				GameManager.PlayersAlive--;
			}
			else
			{
				GameManager.Instance.GameOver();
			}
			Destroy(gameObject);
		}
	}
}
