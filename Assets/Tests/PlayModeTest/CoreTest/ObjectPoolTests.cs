using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class ObjectPoolTests
{
    [UnityTest]
    public IEnumerator ObjectPoolTest()
    {
        var go = new GameObject();
        go.SetActive(false);
        
        var goDefault = new GameObject();
        goDefault.AddComponent<TestPool>().IsSame = true;


        var goDifferent = new GameObject();
        goDifferent.AddComponent<TestPool>();

        var pool = go.AddComponent<ObjectPool>();
        pool._objects = new ObjectArray[1] { new ObjectArray { _count = 10, _objectType = ObjectType.Default, _prefab = goDefault } };
        yield return null;

        go.SetActive(true);

        var goCopy = ObjectPool.s_Instance.GetObject(ObjectType.Default);

        Assert.AreEqual(goDefault.GetComponent<TestPool>().IsSame, goCopy.GetComponent<TestPool>().IsSame);
        Assert.AreNotEqual(goDifferent.GetComponent<TestPool>().IsSame, goCopy.GetComponent<TestPool>().IsSame);
    }

}

class TestPool : MonoBehaviour
{
    public bool IsSame = false;
}
