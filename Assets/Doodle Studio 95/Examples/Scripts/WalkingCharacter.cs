using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoodleStudio95;

namespace DoodleStudio95Examples {
[RequireComponent(typeof(DoodleAnimator)), RequireComponent(typeof(SpriteRenderer))]
public class WalkingCharacter : MonoBehaviour {

	public float movementSpeedX = 14;
	public float movementSpeedY = 14;

	public bool touchControls = false;

	public DoodleAnimationFile animationIdle;
	public DoodleAnimationFile animationWalking;
    //additional code to set up a public variable for the hugging state
    public DoodleAnimationFile animationBeforeHug;
    public DoodleAnimationFile animationDuringHug;

	[Tooltip("If enabled, the character will move across the Z axis. Use this to make 2.5D games.")]
	public bool paperMarioMode = true;

	DoodleAnimator animator;
	Rigidbody rigidBody;
	SpriteRenderer spriteRenderer;
	int lastDirection = 1;

        Coroutine currentHug;
        Coroutine stopHug; 

        void Start () {
		animator = GetComponent<DoodleAnimator>();
		rigidBody = GetComponent<Rigidbody>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		animator.ChangeAnimation(animationIdle);
	}
	
	void Update () {

        //future me! The question mark followed by the colon is a way to write an if else statement without writing out the full statement. The guy who coded the plugin seemed to use it a lot. 

		// Get input
		float axisX = Input.GetAxis("Horizontal");
		float axisY = Input.GetAxis("Vertical");
		
		int directionX = axisX > 0 ? 1 : (axisX < 0 ? -1 : 0);
		int directionY = axisY > 0 ? 1 : (axisY < 0 ? -1 : 0);

		if (touchControls && Input.touchCount > 0) {
			var t = Input.GetTouch(0);
			var vp = Camera.main.ScreenToViewportPoint(t.position);
			vp -= new Vector3(0.5f,0.5f,0);
			vp = vp * 2;
			directionX = Mathf.Abs(vp.x) > 0.33f ? (vp.x > 0 ? 1 : -1) : 0;
			directionY = Mathf.Abs(vp.y) > 0.33f ? (vp.y > 0 ? 1 : -1) : 0;
		}

		if (Input.GetMouseButton(0)) {
			var vp = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			vp -= new Vector3(0.5f,0.5f,0);
			vp = vp * 2;
			directionX = Mathf.Abs(vp.x) > 0.33f ? (vp.x > 0 ? 1 : -1) : 0;
			directionY = Mathf.Abs(vp.y) > 0.33f ? (vp.y > 0 ? 1 : -1) : 0;
		}

            // Set animation
            if (Input.GetButtonDown("Hugging"))
            {
                if (Globals.isHugging == true)
                {
                    if (currentHug == null)
                    {
                        StartCoroutine(Hug());
                    }
                }
            }
            else if (Globals.isHugging == false)
            {
                if (currentHug != null)
                {
                    StopCoroutine(Hug());
                    currentHug = null;
                }

                var anim = (directionX == 0 && directionY == 0) ? animationIdle : animationWalking;
                if (animator.File != anim)
                {
                    animator.ChangeAnimation(anim);
                }
            }

            // Move
            float d = Mathf.Min(1f/60f, Time.deltaTime); // Avoid moving a lot when there's a framerate drop
		float velocityX = movementSpeedX * directionX * d;
		float velocityY = movementSpeedY * directionY * d;
		Vector3 velocity = new Vector3(
			velocityX,
			paperMarioMode ? 0 : velocityY,
			paperMarioMode ? velocityY : 0
		);
		if (rigidBody != null && !rigidBody.isKinematic) {
			const float extraVelocity = 20;
			var v = rigidBody.velocity;
			v.x = velocity.x * extraVelocity;
			if (paperMarioMode)
				v.z = velocity.z * extraVelocity;
			else
				v.y = velocity.y * extraVelocity;
			rigidBody.velocity = v;
		} else {
			transform.Translate(velocity, Space.World);
		}

		// Flip to look right or left
		if (directionX != 0)
			lastDirection = directionX;
		spriteRenderer.flipX = lastDirection < 0;



            // Set animation
            //if (currentHug == null)
            //{
            //    if (Input.GetButtonDown("Hugging"))
            //    {
            //        Debug.Log("Coroutine Started!");
            //        currentHug = StartCoroutine(Hug());
            //    }
            //    //else if (Globals.isHugging == false)
            //    //{
            //    //    StopCoroutine(Hug());
            //    //}
            //    else
            //    {
            //        var anim2 = (directionX == 0 && directionY == 0) ? animationIdle : animationWalking;
            //        if (animator.File != anim2)
            //        {
            //            animator.ChangeAnimation(anim2);
            //        }
            //    }
            //}
            //else
            //{
            //    directionX = directionY = 0;
            //}

            //if (Input.GetButtonUp("Hugging"))
            //{
            //    currentHug = StartCoroutine(StopHug());
            //}
            


        }//end of update function

        IEnumerator Hug()
        {
                Debug.Log("Hugging is set in globals");
                //change the animation to the before hug anim
                animator.ChangeAnimation(animationBeforeHug);
                animator.SetFrame(0);
                yield return animator.PlayAndPauseAt();
                animator.ChangeAnimation(animationDuringHug);
                animator.SetFrame(0);
                animator.Play();
        }

        //IEnumerator StopHug()
        //{
        //    if (Globals.isHugging == false)
        //    {
        //        Debug.Log("Hugging is no longer set");
        //        animator.ChangeAnimation(animationIdle);
        //        //animator.SetFrame(0);
        //        //animator.Play();
        //        currentHug = null;
        //        yield return null;
        //    }
        //}

    }//end of class
}//end of namespace
