using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class P2ItemClickHandlerTest {

	[Test]
	public void P2ItemClickHandlerTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	

        [UnityTest]
    public IEnumerator ItemDragHandlerTestOnDragP2()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        GameObject item1 = new GameObject();

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition.x = 0;
        mousePosition.y = 0;


        item1.transform.position = new Vector3(mousePosition.x, mousePosition.y, item1.transform.position.z);

        var mouseCode = mousePosition.x + mousePosition.y;
        var itemCode = item1.transform.position.x + item1.transform.position.y;
        Assert.AreEqual(mouseCode, itemCode);


        yield return null;
    }

    [UnityTest]
    public IEnumerator ItemDragHandlerTestOnEndDragP2()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        GameObject item1 = new GameObject();

        Vector3 NewLocal = new Vector3(0, 0, 0);



        item1.transform.localPosition = new Vector3(NewLocal.x, NewLocal.y, NewLocal.z);


        Assert.AreEqual(NewLocal, item1.transform.localPosition);


        yield return null;
    }
}
