using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class P1InventoryTest {

	[Test]
	public void P1InventoryTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator P1InventoryaddTest() {

		IInventoryItem TestItem = GameObject.FindGameObjectWithTag ("TestItem").GetComponent<IInventoryItem>();
		var Player1 = GameObject.FindGameObjectWithTag("P1");
		P1Inventory I = GameObject.FindGameObjectWithTag ("P1Inventory").GetComponent<P1Inventory> ();
		yield return null;
		I.AddItem (TestItem);
		var mlist = I.mItems;
		Debug.Log ("The Item in list is " + mlist[0].Name);
		Assert.AreEqual (mlist [0], TestItem);
	}
	[UnityTest]
	public IEnumerator P1Inventoryremove() {
		IInventoryItem TestItem1 = GameObject.FindGameObjectWithTag ("TestItem").GetComponent<IInventoryItem>();
		IInventoryItem TestItem2 = GameObject.FindGameObjectWithTag ("TestItem").GetComponent<IInventoryItem>();
		IInventoryItem TestItem3 = GameObject.FindGameObjectWithTag ("TestItem").GetComponent<IInventoryItem>();
		Debug.Log (TestItem1.Name);
		var Player1 = GameObject.FindGameObjectWithTag("P1");
		P1Inventory I = GameObject.FindGameObjectWithTag ("P1Inventory").GetComponent<P1Inventory> ();
		I.AddItem (TestItem1); //this function has been tested on the previous function
		I.RemoveItem (TestItem1);
        bool ifnull = true;
        if(I.mItems.Contains(TestItem1))
        {
            ifnull = false;
         
        }
       

        yield return null;
		Assert.AreEqual (ifnull, true);

	}
}
