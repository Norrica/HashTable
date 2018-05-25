using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;
using System.Collections.Generic;

namespace TestHashTable
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Добавление и поиск трёх элементов
        public void TestThreeElements()
        {
            var hashTest = new HashTable();
            var list = new List<string>();
            hashTest.CreateNewHashTable(3);
            hashTest.PutPair("первый элемент", "проверка");
            hashTest.PutPair(0, 1234);
            hashTest.PutPair("hello", list);

            var keys = new object[] { "первый элемент", 0, "hello" };
            var values = new object[] { "проверка", 1234, list };
            for (int i = 0; i < 3; i++)
            {
                var a = hashTest.GetValueByKey(keys[i]);
                var b = values[i];
                if (!(a).Equals(b)) throw new Exception();
            }
        }

        [TestMethod]
        //Добавление одного и того же ключа дважды с разными значениями сохраняет последнее добавленное значение
        public void TestTwoElementsWithSameKey()
        {
            var hashTest = new HashTable();
            hashTest.CreateNewHashTable(2);
            hashTest.PutPair("первый элемент", "проверка");
            hashTest.PutPair("первый элемент", "Ooops");
            var key = "первый элемент";
            var value = "Ooops";
            var a = hashTest.GetValueByKey(key);
            if (!(a).Equals(value)) throw new Exception();
        }

        [TestMethod]
        //Поиск одного элемента из тысячи
        public void TestOneElementAmongTenThousand()
        {
            var size = 10000;
            var table = new HashTable();
            table.CreateNewHashTable(size);
            for (var i = 0; i < size - 1; i++)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                Random rnd1 = new Random(DateTime.Now.Millisecond);
                var key = Math.Pow(i, 2);
                var element = rnd.Next(567, 123423) - rnd1.Next(56, 1234);
                table.PutPair(key, element);
            }
            table.PutPair(0, 12345);
            var a = table.GetValueByKey(0);
            var b = 12345;
            if (a != null)
            {
                if (!(a.Equals(b))) throw new Exception();
            }
        }

        [TestMethod]
        //Поиск тысячи недобавленныех ключей
        public void TestSearchingNotAddedElements()
        {
            var size = 10000;
            var table = new HashTable();
            table.CreateNewHashTable(size);
            for (var i = 0; i < size; i++)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                Random rnd1 = new Random(DateTime.Now.Millisecond);
                var key = Math.Pow(i, 2);
                var element = rnd.Next(567, 123423) - rnd1.Next(56, 1234);
                table.PutPair(key, element);
            }
            for (int i = size; i < size + 1000; i++)
            {
                if (!(table.GetValueByKey(i) == null))
                {
                    throw new Exception();
                }
            }
        }
    }
}
