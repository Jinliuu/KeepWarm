using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PauseButtonTest_r23 {

	[Test]
	public void PauseButtonTest_r23SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator PauseButtonTest_r23WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool paused = false;
        int buttonSelected = 0;

        if (paused == true && buttonSelected == 1)
        {
            Assert.AreEqual(paused, true);
        }
        else
        {
            Assert.AreEqual(1, null);
        }
        yield return null;
    }
}
