using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ChooseNumofPlayersTest_r26 {

	[Test]
	public void ChooseNumofPlayersTest_r26SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ChooseNumofPlayersTest_r26WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool AtMenu = false;
        GameObject OnePLayerModeSelect = new GameObject();
        OnePLayerModeSelect.GetComponent<Renderer>().enabled = false;

        GameObject TwoPLayerModeSelect = new GameObject();
        TwoPLayerModeSelect.GetComponent<Renderer>().enabled = false;

        if (AtMenu == true && OnePLayerModeSelect.GetComponent<Renderer>().enabled == true && TwoPLayerModeSelect.GetComponent<Renderer>().enabled == true)
        {
            Assert.AreEqual(1, 1);
        }
        else
        {
            Assert.AreEqual(1,null);
        }
        yield return null;
	}
}
