using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class UnpauseButtonTest_r24 {

	[Test]
	public void UnpauseButtonTest_r24SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator UnpauseButtonTest_r24WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool paused = true;
        int buttonSelected = 0;

        if (paused == false && buttonSelected == 1)
        {
            Assert.AreEqual(paused, false);
        }
        else
        {
            Assert.AreEqual(1, null);
        }
        yield return null;
    }
}
