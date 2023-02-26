using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{

	public List<GameObject> objsOnBelt;

	public float speed = 0;
	public float speedX = 0;
	public float speedY = 0;

	Rigidbody2D rb;

	void Start()
	{
		objsOnBelt = new List<GameObject>();
		GetComponent<TableSlot>().onPlaced += (Item item) =>
		{

			item.transform.position = new Vector2(item.transform.position.x, transform.position.y);
			item.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		};
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (objsOnBelt.Count != 0)
		{
			for (int i = 0; i < objsOnBelt.Count; i++)
			{
				rb = objsOnBelt[i].GetComponent<Rigidbody2D>();
				rb.velocity = new Vector2(speedX, speedY) * speed * Time.deltaTime;
			}
		}
	}

	


	void OnTriggerEnter2D(Collider2D box)
	{
		if (box.gameObject.tag == "Box")
		{
			objsOnBelt.Add(box.gameObject);
			box.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
			box.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
		}
	}
	void OnTriggerExit2D(Collider2D box)
	{
		if (box.gameObject.tag == "Box")
		{
			objsOnBelt.Remove(box.gameObject);
		}
	}
}
	