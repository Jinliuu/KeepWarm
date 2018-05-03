using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayersHaveSameControl_r19 {

	[Test]
	public void PlayersHaveSameControl_r19SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator PlayersHaveSameControl_r19WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        var pm1 = new Player_Move();
        var pm2 = new Player2_Move();
        if (pm1.playerJumpPower== pm2.playerJumpPower) {
            if (pm1.Health == pm2.Health) {
                if (pm1.playerSpeed == pm2.playerSpeed)
                {
                    Assert.AreEqual(1, 1);
                }
            }
        }
        else
        {
            Assert.AreEqual(1, null);
        }



        yield return null;
	}
}
