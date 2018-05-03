using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ArrowHeadTest {

	[Test]
	public void ArrowHeadTestSimplePasses() {
		// Use the Assert class to test conditions.
	
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ArrowHeadTestWithEnumeratorPasses() {




		var Camera = GameObject.FindGameObjectWithTag("MainCamera");
		Camera_System c = Camera.GetComponent<Camera_System> ();

		c.player = GameObject.FindGameObjectWithTag("P1");


		var CameraFollower = Camera.GetComponent<Camera_System>().player;

		float desiredx = limit3digits (CameraFollower.transform.position.x);
		float desiredy = limit3digits (CameraFollower.transform.position.y+1.5f);
		float desiredz = limit3digits (CameraFollower.transform.position.z);




		yield return null;
		var Arrow = GameObject.FindGameObjectWithTag ("Arrowhead");

		ArrowHead arrow = Arrow.GetComponent<ArrowHead> ();

		float actualx = limit3digits (Arrow.transform.position.x);
		float actualy = limit3digits (Arrow.transform.position.y);
		float actualz = limit3digits (Arrow.transform.position.z);


		Debug.Log("The player position is: "+CameraFollower.transform.position.y);

		Debug.Log ("The arrow position is: "+ actualy);

		Debug.Log ("The expected position is: " + desiredy);


		Assert.AreEqual( new Vector3 (limit3digits (desiredx),limit3digits (desiredy), limit3digits (desiredz)), new Vector3(limit3digits (actualx),limit3digits (actualy),limit3digits (actualz)));
		// Use the Assert class to test conditions.
		// Use the Assert class to test conditions.
		// yield to skip a frame

	}

	public float limit3digits (float a)
	{	
		int b = (int)(a * 100);
		a = (float)b / 100;
		return a;

	
	}
}
