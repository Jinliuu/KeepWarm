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
        

        Sprite items = GameObject.Find("DinoSprites_doux").GetComponent<SpriteRenderer>().sprite;
        //GameObject.Find("Insert GameObject name here").GetComponent<SpriteRenderer>().sprite
       // Debug.Log(items);


        //Sprite itemSprite = Resources.Load<Sprite>("Assets/Assets/Dino/gifs/Dino");
       

        yield return null;

        if (items != null)
        {
          
                Assert.AreNotEqual(null, items);

         }

        
       

        yield return null;
    }

    [UnityTest]
    public IEnumerator IventoryItemTest2()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        Sprite items = GameObject.Find("DinoSprites_doux").GetComponent<SpriteRenderer>().sprite;
        Sprite items2 = GameObject.Find("DinoSprites_tard").GetComponent<SpriteRenderer>().sprite;
        //GameObject.Find("Insert GameObject name here").GetComponent<SpriteRenderer>().sprite



        //Sprite itemSprite = Resources.Load("Assets/Assets/Dino/gifs/Dino_Y.gif", typeof(Sprite)) as Sprite;
        
        yield return null;

        if (items != null)
        {

            Assert.AreNotEqual(items, items2);

        }



        yield return null;
    }
}
