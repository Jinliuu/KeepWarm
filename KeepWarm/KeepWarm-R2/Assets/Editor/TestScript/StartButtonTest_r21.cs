﻿using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class StartButtonTest_r21 {

	[Test]
	public void StartButtonTest_r21SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator StartButtonTest_r21WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool startButtonPressed = false;
        bool InGame = false;
        
        if (startButtonPressed == true)
        {
            Assert.AreEqual(InGame, true);
        }
        else
        {
            Assert.AreEqual(1, null);
        }
    
        yield return null;
    }
}