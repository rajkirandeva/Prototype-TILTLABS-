using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    public Rigidbody rb_hips;

    public bool canRotate = false;

    public GameObject spine;
    public HingeJoint[] spineJoints;
    public GameObject hip;
    public HingeJoint[] hipJoints;

    public Rigidbody rb_rfoot;
    public Rigidbody rb_lfoot;

    public Rigidbody rb_rLeg;
    public Rigidbody rb_lLeg;

    public bool isJump = false;


    JointSpring ArmJoint;
    JointSpring legsJoint1, legsJoint2;

    public float legsTargetPos;

    //public float tuckStateVelocity;
    //private float noramlStateVelocity;

    public int totalTucks;

    public GameObject waterEffect;

    public Vector3 direction;

    public float tiltValue;
    public bool canTilt = false;

    public bool freezeRotation = false;

    public Player mplayerData;
    private float velocity;

    public bool isPerfectDive = false;


	private void Awake()
	{
        instance = this;
	}


	// Start is called before the first frame update
	void Start()
    {

        
		spineJoints = spine.GetComponents<HingeJoint>();
        hipJoints = hip.GetComponents<HingeJoint>();




    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canRotate)
        {
            rb_hips.transform.Rotate(Vector3.right * Time.fixedDeltaTime * mplayerData.rotationSpeed);
            ArmJoint = spineJoints[1].spring;
            ArmJoint.targetPosition = 60;
            spineJoints[1].spring = ArmJoint;
            spineJoints[2].spring = ArmJoint;
            legsTargetPos = 90;
            rb_rLeg.constraints = RigidbodyConstraints.FreezeRotationX;
            rb_lLeg.constraints = RigidbodyConstraints.FreezeRotationX;
            rb_hips.AddForce(Vector3.down * mplayerData.tuckVelocity, ForceMode.Impulse);
        }
        else
        {
            if (isJump)
            {
                ArmJoint = spineJoints[1].spring;
                ArmJoint.targetPosition = 150;
                spineJoints[1].spring = ArmJoint;
                spineJoints[2].spring = ArmJoint;
                rb_hips.AddForce(Vector3.down * velocity, ForceMode.Impulse);
            }

            rb_rLeg.constraints = RigidbodyConstraints.None;
            rb_lLeg.constraints = RigidbodyConstraints.None;
        }

        direction = rb_hips.transform.InverseTransformDirection(rb_hips.velocity);

        legsJoint1 = hipJoints[0].spring;
        legsJoint2 = hipJoints[1].spring;
        legsJoint1.targetPosition = Mathf.Lerp(legsJoint1.targetPosition, legsTargetPos, Time.deltaTime * 100f);
        legsJoint2.targetPosition = Mathf.Lerp(legsJoint2.targetPosition, legsTargetPos, Time.deltaTime * 100f);
        hipJoints[0].spring = legsJoint1;
        hipJoints[1].spring = legsJoint2;

        if (canTilt)
        {
            tiltValue = Mathf.Lerp(-6, 6, Mathf.PingPong(Time.time / 2, 1));

            JointSpring hipSpringJoint = hipJoints[2].spring;
            hipSpringJoint.targetPosition = tiltValue;
            hipJoints[2].spring = hipSpringJoint;

        }

		if (!freezeRotation)
		{
            rb_hips.constraints = RigidbodyConstraints.FreezePosition;
            rb_hips.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
		else
		{
            rb_hips.constraints = RigidbodyConstraints.None;
            rb_hips.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }


    public void OnStart()
	{
		if (!isJump)
		{
            ArmJoint = spineJoints[1].spring;
            ArmJoint.targetPosition = 150;
            spineJoints[1].spring = ArmJoint;
            spineJoints[2].spring = ArmJoint;
            canTilt = true;
            freezeRotation = false;
            hipJoints[2].connectedMassScale = .5f;
        }
		else
		{
            canRotate = true;
		}

    }

    public void ReleaseAndJump()
	{
		if (!isJump)
		{
            hipJoints[2].useLimits = true;
            rb_hips.AddForce((transform.up * mplayerData.jumpForce + transform.forward * 150), ForceMode.Impulse);
            //rb_hips.AddForce(transform.forward * 10000f * Time.fixedDeltaTime, ForceMode.Impulse);
            isJump = true;
            StartCoroutine("JumpStretch");
            canTilt = false;
            freezeRotation = true;
            hipJoints[2].connectedMassScale = 1f;
        }
		else
		{
            canRotate = false;
            legsTargetPos = 10;
            
		}
    }


    IEnumerator JumpStretch()
	{
        yield return new WaitForSeconds(1f);
        legsTargetPos = 60;
        yield return new WaitForSeconds(1f);
        velocity = mplayerData.velocity;
        yield return new WaitForSeconds(2f);
        legsTargetPos = 10;
	}
}
