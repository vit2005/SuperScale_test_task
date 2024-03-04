using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStorage
{
    void Save(DataEntity database);
    DataEntity Load();
}
