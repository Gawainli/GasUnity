using System;
using System.Collections;
using System.Collections.Generic;
using Haro.GAS;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GasGame
{
    public class TestEntity : MonoBehaviour
    {
        [ValueDropdown("GetAllTags")] public List<string> tags;

        private MutableTagCombine _mutableTagCombine = new MutableTagCombine();

        private IEnumerable GetAllTags()
        {
            return TagCollection.TagTexts;
        }

        private void Awake()
        {
        }

        private void Start()
        {
            var t1 = Tag.Create("A.a");
            var t2 = Tag.Create("A.a.b.c");

            Debug.Log($"t1: {t1} t2: {t2} t2 is sub of t1: {t2.Match(t1)}");
        }
    }
}