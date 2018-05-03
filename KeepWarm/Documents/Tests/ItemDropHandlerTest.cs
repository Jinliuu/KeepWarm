using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ItemDropHandlerTest {

	[Test]
	public void ItemDropHandlerTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ItemDropHandlerTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        GameObject item1 = new GameObject();
        GameObject inventory = GameObject.Find("P1Inventory");
        int[] invList= new int[1];

        
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (mousePosition.x!=inventory.transform.position.x&& mousePosition.y != inventory.transform.position.y)
        {
            invList[0] = 0;
        }

       Assert.AreEqual(0, invList[0]);


        yield return null;
	}
}
