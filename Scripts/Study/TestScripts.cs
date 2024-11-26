using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : StudySingleton<TestScripts>
{
    private void Start()
    {
    }

    public void Message()
    {
        print("Message");
    }

}
