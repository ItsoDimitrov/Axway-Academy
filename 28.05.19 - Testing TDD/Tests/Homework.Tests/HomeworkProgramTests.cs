using System;
using System.Collections;
using System.Collections.Generic;
using HomeworkProgram;
using Xunit;

namespace Homework.Tests
{ 
    public class HomeworkProgramTests
    {
        private Store _store;
        public HomeworkProgramTests()
        {
            _store = new Store(new List<string>());
        }
       

        [Fact]
        public void ItemsCount_ShouldReturnZero_IfThereIsNoItems()
        {
            var storeItemsCount = _store.ItemsCount();
            var expected = 0;
            Assert.Equal(expected,storeItemsCount);

        }
        [Fact]
        public void AddItem_ShouldAddItem_IfGivenDataTypeIsCorrect()
        {
            _store.AddItem("Ak47");
            _store.AddItem("M4A4");
            var storeItemsCount = _store.ItemsCount();
            var expected = 2;
            Assert.Equal(expected,storeItemsCount);

        }
    }
}
