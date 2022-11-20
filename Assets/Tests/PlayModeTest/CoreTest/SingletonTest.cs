using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class SingletonTest
{
    [UnityTest]
    public IEnumerator SetSingletonTest()
    {
        var go = new GameObject();
        var obj = go.AddComponent<TestSingleton>();
        yield return null;
        Assert.AreEqual(obj, TestSingleton.s_Instance);
        GameObject.Destroy(go);
    }

    [UnityTest]
    public IEnumerator SetTwoSingletonWithDifferentGOTest()
    {
        var go = new GameObject();
        var obj = go.AddComponent<TestSingleton>();
        var go2 = new GameObject();
        var obj2 = go2.AddComponent<TestSingleton>();
        yield return null;
        Assert.AreEqual(obj, TestSingleton.s_Instance);
        Assert.AreNotEqual(obj2, TestSingleton.s_Instance);
        GameObject.Destroy(go);
        GameObject.Destroy(go2);
    }

    [UnityTest]
    public IEnumerator SetTwoSingletonWithSameGOTest()
    {
        var go = new GameObject();
        var obj = go.AddComponent<TestSingleton>();
        var obj2 = go.AddComponent<TestSingleton>();
        yield return null;
        Assert.AreEqual(obj, TestSingleton.s_Instance);
        Assert.AreNotEqual(obj2, TestSingleton.s_Instance);
        GameObject.Destroy(go);
    }
}

class TestSingleton : Singleton<TestSingleton>
{
    public override void Awake()
    {
        base.Awake();
    }
}
