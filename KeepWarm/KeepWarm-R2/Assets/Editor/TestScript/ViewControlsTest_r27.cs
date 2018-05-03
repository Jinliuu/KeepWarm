using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ViewControlsTest_r27 {

	[Test]
	public void ViewControlsTest_r27SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ViewControlsTest_r27WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool ControlsToggle = false;
        GameObject controlPage=new GameObject();
        controlPage.GetComponent<Renderer>().enabled = false;
        
        if (ControlsToggle == true)
        {
            Assert.AreEqual(controlPage.GetComponent<Renderer>().enabled, true);
        }
        else
        {
            Assert.AreEqual(1, null);
        }

        yield return null;
	}
}
