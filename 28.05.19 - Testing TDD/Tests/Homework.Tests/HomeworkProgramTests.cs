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
        public void ItemsCount_ReturnZero_IfThereIsNoItems()
        {
            var storeItemsCount = _store.ItemsCount();
            Assert.Equal(0,storeItemsCount);

        }
    }
}
