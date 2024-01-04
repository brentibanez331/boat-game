﻿using Ditzelgames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaterFloat))]
public class WaterBoat : MonoBehaviour
{
    //visible Properties
    public Transform Motor;
    public float SteerPower = 200f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;

    //used Components
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;
    protected ParticleSystem ParticleSystem;
    protected Camera Camera;

    //internal Properties
    protected Vector3 CamVel;

    [SerializeField]
    GameObject PickupButton;

    bool collidedFloatingObj;
    GameObject FloatingObj;

    public MainMenu Menu;

    [SerializeField]
    ScoreManager scoreManager;
    [SerializeField]

    public void Awake()
    {
        PickupButton.SetActive(false);
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
        Camera = Camera.main;
    }

    public void FixedUpdate()
    {
        float dirX = Input.acceleration.x;
        float dirZ = Input.acceleration.z;

        print(dirZ);

        if (Menu.gameIsPaused)
        {
            SteerPower = 0;
            Power = 0;
        }
        else
        {
            SteerPower = 150f;
            Power = 5;
        }

        //default direction
        var forceDirection = transform.forward;
        var steer = 0;

        //steer direction [-1,0,1]
        if (dirX < -0.1)
            steer = 1;
        if (dirX > 0.1)
            steer = -1;
        if (dirX >= -0.1 && dirX <= 0.1)
            steer = 0;


        //Rotational Force
        Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);

        //compute vectors
        var forward = Vector3.Scale(new Vector3(1,0,1), transform.forward);
        var targetVel = Vector3.zero;

        //forward/backward poewr
        if (Input.GetKey(KeyCode.W))
        {
            print(forward * MaxSpeed);
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed, Power);
        }
        if (Input.GetKey(KeyCode.S))
        {
            print(-forward * MaxSpeed);
            PhysicsHelper.ApplyForceToReachVelocity(Rigidbody, -forward * MaxSpeed, Power);
        }

        //Motor Animation // Particle system
        Motor.SetPositionAndRotation(Motor.position, transform.rotation * StartRotation * Quaternion.Euler(0, 30f * steer, 0));
        if (ParticleSystem != null)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                ParticleSystem.Play();
            else
                ParticleSystem.Pause();
        }

        //moving forward
        var movingForward = Vector3.Cross(transform.forward, Rigidbody.velocity).y < 0;

        //move in direction
        Rigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(Rigidbody.velocity, (movingForward ? 1f : 0f) * transform.forward, Vector3.up) * Drag, Vector3.up) * Rigidbody.velocity;
    }

    public void DestroyObject()
    {
        if (collidedFloatingObj)
        {
            scoreManager.AddScore();
            FloatingObj.GetComponent<WaterFloat>().enabled = false;
            FloatingObj.GetComponent<Rigidbody>().drag = 0;
            FloatingObj.GetComponent<Rigidbody>().useGravity = true;
            PickupButton.SetActive(false);
            Destroy(FloatingObj, 3.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goods")
        {
            collidedFloatingObj = true;
            FloatingObj = other.gameObject;
            PickupButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Goods")
        {
            collidedFloatingObj = false;
            FloatingObj = null;
            PickupButton.SetActive(false);
        }
    }
}