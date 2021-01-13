﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target; //camera target
	public float distance = 8.0f; //distance from target
	public float height = 5.0f;   //height from target
	public float heightDamping = 2.0f; //hegiht damping

	public float lookAtHeight = 0.0f; //camera height

	public Rigidbody parentRigidbody; //Rigidbody 

	public float rotationSnapTime = 0.3F; //Rotation Time

	public float distanceSnapTime; //distacne snap time
	public float distanceMultiplier; 

	private Vector3 lookAtVector;  //look position

	private float usedDistance; 

	float wantedRotationAngle;
	float wantedHeight;

	float currentRotationAngle;
	float currentHeight;

	Quaternion currentRotation;
	Vector3 wantedPosition;

	private float yVelocity = 0.0F;
	private float zVelocity = 0.0F;

	void Start()
	{

		lookAtVector = new Vector3(0, lookAtHeight, 0);

	}

	void LateUpdate()
	{

		wantedHeight = target.position.y + height;
		currentHeight = transform.position.y;

		wantedRotationAngle = target.eulerAngles.y;
		currentRotationAngle = transform.eulerAngles.y;

		currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle, ref yVelocity, rotationSnapTime);

		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		wantedPosition = target.position;
		wantedPosition.y = currentHeight;

		usedDistance = Mathf.SmoothDampAngle(usedDistance, distance + (parentRigidbody.velocity.magnitude * distanceMultiplier), ref zVelocity, distanceSnapTime);

		wantedPosition += Quaternion.Euler(0, currentRotationAngle, 0) * new Vector3(0, 0, -usedDistance);

		transform.position = wantedPosition;

		transform.LookAt(target.position + lookAtVector);

	}
}
