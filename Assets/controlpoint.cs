using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlpoint : MonoBehaviour
{
    float xroat = 0f, yroat = 0f;
    Vector3 initialPosition;
    Vector3 ballPosition;
    Quaternion initialRotation;
    public Rigidbody ball;
    public float rotatespeed = 5f;
    public LineRenderer Line;
    public float stopDrag = 0.5f;
    public float minVelocityMagnitude = 0.1f;
    public float shootpower = 30f;
    public int YDie = -1;
    private bool isBallMoving = false;
    private Vector3 mousePressPosition;

    private int coups = 0;

    // Exposez la propriété coups publiquement
    public int Coups
    {
        get { return coups; }
    }

    public AudioSource ballOutOfBoundsSound;  // Ajout de la variable AudioSource

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        ballPosition = ball.position;
    }

    void Update()
    {
        transform.position = ball.position;

        if (isBallMoving)
        {
            if (ball.velocity.magnitude < minVelocityMagnitude)
            {
                Debug.Log("Ball has stopped moving!");
                isBallMoving = false;
                ballPosition = ball.position;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePressPosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                xroat += Input.GetAxis("Mouse X") * rotatespeed;
                yroat += Input.GetAxis("Mouse Y") * rotatespeed;
                yroat = Mathf.Clamp(yroat, initialPosition.y - 15f, initialPosition.y + 15f);
                transform.rotation = Quaternion.Euler(yroat, xroat, 0f);
                Line.gameObject.SetActive(true);
                Line.SetPosition(0, transform.position);
                Line.SetPosition(1, transform.position + transform.forward * 4f);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Vector3 mouseReleasePosition = Input.mousePosition;
                Vector3 dragVector = mouseReleasePosition - mousePressPosition;
                float pullStrength = dragVector.magnitude;

                Vector3 forceDirection = transform.forward;

                ball.AddForce(forceDirection * pullStrength * shootpower);
                Line.gameObject.SetActive(false);
                ball.drag = stopDrag;
                ball.angularDrag = stopDrag;
                isBallMoving = true;

                coups++;
                Debug.Log("Nombre de coups : " + coups);
            }
        }

        if (transform.position.y < YDie)
        {
            transform.position = ballPosition;
            ball.position = ballPosition;
            ball.velocity = Vector3.zero;
            isBallMoving = false;

            coups = 0;
            Debug.Log("Nombre de coups réinitialisé.");

            // Ajout de la ligne pour jouer le son
            ballOutOfBoundsSound.Play();
        }
    }
}
