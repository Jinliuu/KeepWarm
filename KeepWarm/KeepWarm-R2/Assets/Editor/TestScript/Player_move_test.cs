using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class Player_move_test {

    [Test]
    public void PlayerMoveincloud_Test()
    {
        //Arrange
        var movement = new Player_Move();
        movement.test1(true);
        var newplayerspeed = 0.5f;
        //Assert
        Assert.AreEqual(newplayerspeed, movement.playerSpeed);
    }
    [Test]
    public void TakeDamge_test()
    {
        Player_Move movement = new GameObject().AddComponent<Player_Move>();

        movement.TakeDamage1(10);
        Debug.Log("The player health is: " + movement.Health);

        Assert.AreEqual(movement.Health, 90);
    }
    [Test]
    public void TakeDamgeHealthIs0_test()
    {
        Player_Move movement = new GameObject().AddComponent<Player_Move>();

        movement.TakeDamage1(190);
        Debug.Log("The player health is: " + movement.Health);

        Assert.AreEqual(movement.Health, 0);
    }

    [Test]
    public void Jump_test()
    {
        Player_Move movement = new GameObject().AddComponent<Player_Move>();
        movement.Jump();
        Assert.IsFalse(movement.canClimb);
        Assert.IsFalse(movement.inCloud);

    }
    [Test]
    public void FlipPlayer_test()
    {
        Player_Move movement = new GameObject().AddComponent<Player_Move>();
        movement.FlipPlayer();
        Vector2 testvector = new Vector2();
        Debug.Log("The player health is: " + movement.localScale.x);
        //Vector2 testVector = gameObject.transform.localScale;
        Assert.IsFalse(movement.canClimb);
        Assert.IsTrue(movement.facingRight);
        Assert.AreEqual(movement.localScale.x, -1);

    }


}


