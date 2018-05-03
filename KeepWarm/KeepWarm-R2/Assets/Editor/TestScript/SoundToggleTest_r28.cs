using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SoundToggleTest_r28 {

	[Test]
	public void SoundToggleTest_r28SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator SoundToggleTest_r28WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool muted = false;
        int buttonSelected = 0;
        
        if (muted == false && buttonSelected==1)
        {
            Assert.AreEqual(muted, true);
        }
        else
        {
            Assert.AreEqual(1, null);
        }
        yield return null;
	}
}
