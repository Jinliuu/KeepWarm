using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TwoPlayerStart_r20 {

	[Test]
	public void TwoPlayerStart_r20SimplePasses() {
		// Use the Assert class to test conditions.
	}

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    private int p1Selected=0;
    private int p2Selected = 0;
    private int MenuSelected {
        get { return (this.p1Selected+this.p2Selected); }
        set { this.p1Selected = value;
            this.p2Selected = value;
        }
        
}


	[UnityTest]
	public IEnumerator TwoPlayerStart_r20WithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        



        if (MenuSelected<2)
        {
            Assert.AreEqual(InputEnable.P1IsInputEnabled, false);
        }
        else if (MenuSelected>1)
        {
            Assert.AreEqual(InputEnable.P1IsInputEnabled, true);
        }

        else
        {
            Assert.AreEqual(1,null);
        }



            yield return null;
	}
}
