using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TitleToDesktopTest_r25 {

	[Test]
	public void TitleToDesktopTest_r25SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator TitleToDesktopTest_r25WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool exitKeyPressed = false;
        bool AtTitleMenu = false;
        if (exitKeyPressed == true)
        {
            Assert.AreEqual(AtTitleMenu, true);
        }
        else
        {
            Assert.AreEqual(1, null);
        }
        yield return null;
    }
}
