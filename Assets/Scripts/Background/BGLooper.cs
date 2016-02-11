using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public float speed;

	private Vector2 offset = Vector2.zero;
	private Material mat;

	void Start () {
		mat = GetComponent<Renderer> ().material;
		offset = mat.GetTextureOffset ("_MainTex");
	}

	void Update () {
		offset.x += speed * Time.deltaTime * Time.timeScale;
		mat.SetTextureOffset ("_MainTex", offset);
	}
}
