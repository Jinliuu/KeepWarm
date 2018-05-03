using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ExitMenuTest_r29 {

	[Test]
	public void ExitMenuTest_r29SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ExitMenuTest_r29WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool exitKeyPressed = false;
        bool AtMenu = false;
        if (exitKeyPressed == true)
        {
            Assert.AreEqual(AtMenu, true);
        }
        else
        {
            Assert.AreEqual(1, null);
        }
        yield return null;
	}
}
