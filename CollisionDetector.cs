using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{

	public CollisionBool CollisionBool;
	public AudioClip Celebration;
	void MyMethod()
	{
		if (CollisionBool.ballCollision == true)
			if (transform.position.x > 20)
				if (transform.position.z > 20)
				{
					{
						AudioSource.PlayClipAtPoint(Celebration, transform.position);
					}
				}
	}
}
