using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class Spawn_r17_Test {

	[Test]
	public void Spawn_r17_TestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator Spawn_r17_TestPLayer1() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        Vector3[] PlayerSpawnPoints = new Vector3[3];
        PlayerSpawnPoints[0] = new Vector3(0.0f, 0.0f, 0.0f);
        PlayerSpawnPoints[1] = new Vector3(1f, 1f, 1f);
        PlayerSpawnPoints[2] = new Vector3(2f, 2f, 2f);
        

        int numberOfSpawns = PlayerSpawnPoints.Length;
        GameObject player1 = GameObject.FindWithTag("P1");
        for (int i = 0; i < numberOfSpawns; i++) {
            if (player1.transform.position== PlayerSpawnPoints[i])
            {
                Assert.AreEqual(0, 0);
            }
            else
            {
                Assert.AreEqual(null, 1);
            }
        }
		yield return null;
	}

    [UnityTest]
    public IEnumerator Spawn_r17_TestPLayer2()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        Vector3[] PlayerSpawnPoints = new Vector3[3];
        PlayerSpawnPoints[0] = new Vector3(0.0f, 0.0f, 0.0f);
        PlayerSpawnPoints[1] = new Vector3(1f, 1f, 1f);
        PlayerSpawnPoints[2] = new Vector3(2f, 2f, 2f);
        int numberOfSpawns = PlayerSpawnPoints.Length;
        GameObject player2 = GameObject.FindWithTag("P2");
        for (int i = 0; i < numberOfSpawns; i++)
        {
            if (player2.transform.position == PlayerSpawnPoints[i])
            {
                Assert.AreEqual(0, 0);
            }
            else
            {
                Assert.AreEqual(null, 1);
            }
        }
        yield return null;
    }
}
