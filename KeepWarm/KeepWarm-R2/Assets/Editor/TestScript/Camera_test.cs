using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class Camera_test {

	[Test]
	public void Camera_init_test() {
        Camera_System camera = new GameObject().AddComponent<Camera_System>();
        camera.player = GameObject.FindGameObjectWithTag("P1");
      
       
        Assert.AreEqual(camera.x, -2.7f);
    }

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator Camera_testWithEnumeratorPasses() {

        //Camera_System camera = new GameObject().AddComponent<Camera_System>();
        GameObject player = GameObject.FindGameObjectWithTag("P1");
        float desiredx = player.transform.position.x;
        float desiredy = player.transform.position.y;
        float desiredz = player.transform.position.z;

        yield return null;

        var c= GameObject.FindGameObjectWithTag("MainCamera");

        Camera_System p = c.GetComponent<Camera_System>();

        float actualx = p.transform.position.x;
        float actualy = p.transform.position.y;
        float actualz = p.transform.position.z;

        Debug.Log("The player position is: " + desiredx );
        Debug.Log("The player position is: " +  desiredy);
        Debug.Log("The player position is: " + desiredz);

        Debug.Log("The expected position is: " + actualx);
        Debug.Log("The expected position is: " + actualy);
        Debug.Log("The expected position is: " + actualz);
        Assert.AreEqual(new Vector3(actualx, actualy, actualz), new Vector3(desiredx, desiredy, desiredz));
    }
}
