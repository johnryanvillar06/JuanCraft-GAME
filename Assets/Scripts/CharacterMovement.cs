using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public VariableJoystick variableJoystick;
    public Animator animator;
    public Transform interactor;
    private PickUp pickup;
    float csharp ;

    Vector2 movement;
    float dirx, diry, horizontalvalue, verticalvalue, interactorhorizontal, interactorvertical;
    bool Rightmove, Leftmove, Upmove, Downmove;

    void Start() {
        rb.GetComponent<Rigidbody2D>();
        pickup = gameObject.GetComponent<PickUp>();
        pickup.Direction = new Vector2(0, -1);
  
    }

    void FixedUpdate()
    {
        //Input Controller
        horizontalvalue = variableJoystick.Horizontal + Input.GetAxisRaw("Horizontal");
        verticalvalue = variableJoystick.Vertical + Input.GetAxisRaw("Vertical");

        movement.x = horizontalvalue;
        movement.y = verticalvalue;

        if (horizontalvalue == 1 || horizontalvalue == -1 || verticalvalue == 1 || verticalvalue == -1)
        {
            animator.SetFloat("LastHorizontal", horizontalvalue);
            animator.SetFloat("LastVertical", verticalvalue);
            SoundManager.getInstance()?.playSound("walk");
        }else
        {
            SoundManager.getInstance()?.stopSound("walk");
        }

        if (movement.sqrMagnitude > .1f) 
        {
            pickup.Direction = movement.normalized;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Mobile Controller 
        if (Rightmove)
        {
            transform.position = (rb.position + new Vector2(moveSpeed, 0) * Time.deltaTime);
            movement.x = 1;
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", 0);
            pickup.Direction = movement.normalized;
            interactorhorizontal = 1;
            interactorvertical = 0 ;
            SoundManager.getInstance()?.playSound("walk");
        }
        if (Leftmove)
        {
            transform.position = (rb.position + new Vector2(-moveSpeed, 0) * Time.deltaTime);
            movement.x = -1;
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", 0);
            pickup.Direction = movement.normalized;
            interactorhorizontal = -1;
            interactorvertical = 0;
            SoundManager.getInstance()?.playSound("walk");
        }
        if (Upmove)
        {
            transform.position = (rb.position + new Vector2(0, moveSpeed) * Time.deltaTime);
            movement.y = 1;
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetFloat("LastVertical", movement.y);
            animator.SetFloat("LastHorizontal", 0);
            pickup.Direction = movement.normalized;  
            interactorvertical = 1;
            interactorhorizontal = 0;
            SoundManager.getInstance()?.playSound("walk");
        }
        if (Downmove)
        {
            transform.position = (rb.position + new Vector2(0, -moveSpeed) * Time.deltaTime);
            movement.y = -1;
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetFloat("LastVertical", movement.y);
            animator.SetFloat("LastHorizontal", 0);
            pickup.Direction = movement.normalized;
            interactorvertical = -1;
            interactorhorizontal = 0;
            SoundManager.getInstance()?.playSound("walk");
        }

        

        IntractorInputController();
        IntractormobileController();

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
 

    public void IntractorInputController() {

        if (horizontalvalue > 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 90);
            interactor.localPosition = new Vector3(1, 0, 0);
        }
        else if (horizontalvalue < 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, -90);
            interactor.localPosition = new Vector3(-1, 0, 0);

        }
        else if (verticalvalue > 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 180);
            interactor.localPosition = new Vector3(0, 1, 0);

        }
        else if (verticalvalue < 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 0);
            interactor.localPosition = new Vector3(0, -1, 0);
        }
    }
    public void IntractormobileController() 
    {
        if (interactorhorizontal > 0)
        {
           
            interactor.localRotation = Quaternion.Euler(0, 0, 90);
            interactor.localPosition = new Vector3(1, 0, 0);

        }
        else if (interactorhorizontal < 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, -90);
            interactor.localPosition = new Vector3(-1, 0, 0);
        }
        else if (interactorvertical > 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 180);
            interactor.localPosition = new Vector3(0, 1, 0);
        }
        else if (interactorvertical < 0)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 0);
            interactor.localPosition = new Vector3(0, -1, 0);
        }
    }

    public void OnRightbtnCliked()
    {
        Rightmove = true;
    }
    public void ReleaseRightbtnCliked()
    {
        Rightmove = false;
    }
    public void OnLeftbtnCliked()
    {
        Leftmove = true;
    }
    public void ReleaseLeftbtnCliked()
    {
        Leftmove = false;
    }
    public void OnUpbtnCliked()
    {
        Upmove = true;
    }
    public void ReleaseUpbtnCliked()
    {
        Upmove = false;
    }
    public void OnDownbtnCliked()
    {
        Downmove = true;
    }
    public void ReleseDownbtnCliked()
    {
        Downmove = false;
    }

}
