using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	private Camera cam;
	
	private float verticalInput;
	private float horizontalInput;
	private float mouseWheelInput;
	[SerializeField]
	private float speed = 20;
	private float zoom;
	[SerializeField]
	private float zoomSpeed = 15;
	[SerializeField]
	private float zoomLerpSpeed = 10;

	void Start()
	{
		cam = Camera.main;
		zoom = cam.orthographicSize;
	}
	
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");
		mouseWheelInput = Input.GetAxis("Mouse ScrollWheel");
		
		transform.Translate(Vector2.up * verticalInput * speed * Time.deltaTime);
		transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
		
		zoom = zoom - (mouseWheelInput * zoomSpeed);
		zoom = Mathf.Clamp(zoom, 3f, 7f);
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * zoomLerpSpeed);
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CenterCamera();
		}
    }
	
	void CenterCamera()
	{
		//Method to Default Camera on Center of Selected Mouse
		Debug.Log("Camera Centered on Selected Mouse");
		
		//translate to mouse
		//default zoom "size" to 5
	}
}
