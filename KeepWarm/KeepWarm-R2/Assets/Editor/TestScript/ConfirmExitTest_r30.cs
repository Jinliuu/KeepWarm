using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ConfirmExitTest_r30 {

	[Test]
	public void ConfirmExitTest_r30SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ConfirmExitTest_r30WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool exitKeyPressed=false;
        bool ConfirmMessageVisible=false;
        if (exitKeyPressed == true)
        {
            Assert.AreEqual(ConfirmMessageVisible, true);
        }
        else
        {
            Assert.AreEqual(1, null);
        }
        yield return null;
	}
}
