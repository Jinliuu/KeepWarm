using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class WeatherDanger_test {

	[Test]
	public void WeatherDanger_testSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator WeatherDanger_testP1() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool p1Danger = false;
        GameObject p1 = GameObject.FindGameObjectWithTag("P1");
        
        GameObject weather = new GameObject();
        if (p1.transform.position.x <= weather.transform.position.x)
        {
            Assert.AreEqual(p1Danger, true);
        }
        else
        {
            Assert.AreEqual(1, null);
        }
        yield return null;
	}

    [UnityTest]
    public IEnumerator WeatherDanger_testP2()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        bool p2Danger = false;
        
        GameObject p2 = GameObject.FindGameObjectWithTag("P2");
        GameObject weather = new GameObject();
        if (p2.transform.position.x <= weather.transform.position.x)
        {
            Assert.AreEqual(p2Danger, true);
        }
        else
        {
            Assert.AreEqual(1, null);
        }
        yield return null;
    }
}
