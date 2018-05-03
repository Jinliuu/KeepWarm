using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class AfterTurnActionTest_r18 {

	[Test]
	public void AfterTurnActionTest_r18SimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator AfterTurnActionTest_r18P2() 
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            var cs1 = new Camera_System();

            while (cs1.pvalue == 1.0f)
            {
                if (InputEnable.P2IsInputEnabled == true)
                {

                    Assert.AreEqual(1, 1);
            }
            else
            {
                Assert.AreEqual(1, null);
            }
                


                yield return null;
            }
        }

    [UnityTest]
    public IEnumerator AfterTurnActionTest_r18P1()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        var cs1 = new Camera_System();

        while (cs1.pvalue == 1.0f)
        {
            if (InputEnable.P1IsInputEnabled == true)
            {

                Assert.AreEqual(1, 1);
            }
            else if(InputEnable.P1IsInputEnabled == false)
            {
                Assert.AreEqual(1, null);
            }


            yield return null;
        }
    }
}
