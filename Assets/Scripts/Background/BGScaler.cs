using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {
	
	void Start () {
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width / Screen.height;

		if (gameObject.name == "Background") {
			transform.localScale = new Vector3 (width, height, 0);
		} else {
			transform.localScale = new Vector3 (width + 3, 5, 0);
		}
	}
}
