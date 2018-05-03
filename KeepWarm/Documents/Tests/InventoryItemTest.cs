using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class InventoryItemTest {

	[Test]
	public void InventoryItemTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator IventoryItemTest1() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        GameObject[] items;

        items = GameObject.FindGameObjectsWithTag("Item");




        Sprite itemSprite = Resources.Load("Assets/Assets/Dino/Gifs/Dino.png", typeof(Sprite)) as Sprite;
        string name = "test";


        yield return null;

        if (items != null)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Assert.AreEqual(items[i], itemSprite);



            }

        }
        else
        {
            Assert.AreEqual(1, 0);
        }



        yield return null;
    }
}
