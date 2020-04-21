using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour
{
	public Transform light = null;
	public MeshRenderer earthRenderer = null;
	public MeshRenderer atmosphereRenderer = null;

	float MIN_DIST = 200;
	float MAX_DIST = 2000;

	float dist = 400;
	Quaternion cameraRotation;
	Vector2 targetOffCenter = Vector2.zero;
	Vector2 offCenter = Vector2.zero;

	// Use this for initialization
	void Start()
	{
		cameraRotation = Quaternion.LookRotation(-transform.position.normalized, Vector3.up);
	}

	// Update is called once per frame
	void Update()
	{
		float wheelDelta = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(dist +  "// " + wheelDelta);
		if (wheelDelta > 0)
		{
			dist *= 0.87f;
		}
		else if (wheelDelta < 0)
		{
			dist *= 1.15f;
		}

		if (dist < MIN_DIST)
		{
			dist = MIN_DIST;
		}
		else if (dist > MAX_DIST)
		{
			dist = MAX_DIST;

        }


        float xMove = Input.GetAxis("Mouse X");
		float yMove = Input.GetAxis("Mouse Y");


		transform.rotation = cameraRotation;

		transform.position = (cameraRotation * (-Vector3.forward * dist));


	    transform.position += new Vector3(transform.right.x * offCenter.x + transform.up.x * offCenter.y,
									        transform.right.y * offCenter.x + transform.up.y * offCenter.y,
	 										transform.right.z * offCenter.x + transform.up.z * offCenter.y);

		//Vector3 lightDir = Quaternion.Inverse(light.rotation) * Vector3.forward;
		//earthRenderer.material.SetVector("_LightDir", lightDir);
		//atmosphereRenderer.material.SetVector("_LightDir", lightDir);
	}
}
