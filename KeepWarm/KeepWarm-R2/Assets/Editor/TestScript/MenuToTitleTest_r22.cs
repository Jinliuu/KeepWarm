using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MenuToTitleTest_r22 {

	[Test]
	public void MenuToTitleTest_r22SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator MenuToTitleTest_r22WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool exitKeyPressed = false;
        bool AtTitleMenu = false;
        bool inGame = true;
        if (exitKeyPressed == true &&inGame==true)
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
