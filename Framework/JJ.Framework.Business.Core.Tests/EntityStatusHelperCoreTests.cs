using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Business.Legacy;

namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class EntityStatusHelperCoreTests
{
    private class ViewModel
    {
        public int Key { get; set; }
        public string? Name { get; set; }
    }

    private class E
    {
        public int ID { get; set; }
        public string? Name { get; set; }
    }

    [TestMethod]
    public void GetListIsDirty_SameLists_ReturnsFalse()
    {
        var list1 = new List<ViewModel> { new() { Key = 1, Name = "A" }, new() { Key = 2, Name = "B" } };
        var list2 = new List<E> { new() { ID = 1, Name = "A" }, new() { ID = 2, Name = "B" } };

        bool result = EntityStatusHelper.GetListIsDirty(list1, vm => vm.Key, list2, e => e.ID);

        IsFalse(result);
    }

    [TestMethod]
    public void GetListIsDirty_DifferentCount_ReturnsTrue()
    {
        var list1 = new List<ViewModel> { new() { Key = 1 } };
        var list2 = new List<E> { new() { ID = 1 }, new() { ID = 2 } };

        IsTrue(EntityStatusHelper.GetListIsDirty(list1, vm => vm.Key, list2, e => e.ID));
    }

    [TestMethod]
    public void GetListIsDirty_DifferentOrder_BehavesAccordingToFlag()
    {
        var list1 = new List<ViewModel> { new() { Key = 1 }, new() { Key = 2 } };
        var list2 = new List<E> { new() { ID = 2 }, new() { ID = 1 } };

        // Order matters by default -> dirty
        IsTrue(EntityStatusHelper.GetListIsDirty(list1, vm => vm.Key, list2, e => e.ID, ingoreOrder: false));

        // Ignore order -> not dirty
        IsFalse(EntityStatusHelper.GetListIsDirty(list1, vm => vm.Key, list2, e => e.ID, ingoreOrder: true));
    }

    [TestMethod]
    public void GetListIsDirty_ElementChanged_ReturnsTrue()
    {
        var list1 = new List<ViewModel> { new() { Key = 1 }, new() { Key = 2 } };
        var list2 = new List<E> { new() { ID = 1 }, new() { ID = 3 } };

        IsTrue(EntityStatusHelper.GetListIsDirty(list1, vm => vm.Key, list2, e => e.ID));
    }

    [TestMethod]
    public void GetListIsDirty_NullArguments_ThrowNullException()
    {
        var list = new List<ViewModel> { new() { Key = 1 } };
        var listE = new List<E> { new() { ID = 1 } };

        // list1 null
        Throws(() => EntityStatusHelper.GetListIsDirty<ViewModel, E>(null!, vm => vm.Key, listE, e => e.ID), "list1", "null");

        // getKey1 null
        Throws(() => EntityStatusHelper.GetListIsDirty<ViewModel, E>(list, null!, listE, e => e.ID), "getKey1", "null");

        // list2 null
        Throws(() => EntityStatusHelper.GetListIsDirty<ViewModel, E>(list, vm => vm.Key, null!, e => e.ID), "list2", "null");

        // getKey2 null
        Throws(() => EntityStatusHelper.GetListIsDirty<ViewModel, E>(list, vm => vm.Key, listE, null!), "getKey2", "null");
    }
}
