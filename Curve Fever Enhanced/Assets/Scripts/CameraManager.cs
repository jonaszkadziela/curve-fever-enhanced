using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public float widthToBeSeen;

	void Start()
	{
		widthToBeSeen = Settings.BattlefieldWidth;
		Camera.main.orthographicSize = widthToBeSeen * 1.02f;
	}
}
