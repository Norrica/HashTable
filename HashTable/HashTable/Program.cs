using System;
using System.Collections.Generic;

namespace Program
{
	public class HashTable
	{
		public List<int> hashList;
		public List<List<MyData>> hashTable;

		public class MyData
		{
			public object Key { get; set; }
			public object Value { get; set; }
		}

		/// <summary>
		/// Поиск индекса хэш-кода
		/// </summary>
		public int FindIndexOfHash(int hashCode)
		{
			return hashList.IndexOf(hashCode);
		}

		/// <summary>
		/// Создание новой хэш-таблицы
		/// </summary>
		/// <param name="size"></param>размер хэш-таблицы
		public void CreateNewHashTable(int size)
		{
			hashTable = new List<List<MyData>>(size);
			hashList = new List<int>(size);
			for (int i = 0; i < size; i++)
			{
				hashTable.Add(new List<MyData>());
			}
		}

		/// <summary>
		/// Получение хэш-кода ключа
		/// </summary>
		public int GetHashCode(object key)
		{
			return key.GetHashCode();
		}

		/// <summary>
		/// Добавление новой пары в хэш-таблицу
		/// </summary>
		public void PutPair(object key, object value)
		{
			var hashCode = GetHashCode(key);
			var hashIndex = FindIndexOfHash(hashCode);
			var keyValue = new MyData { Key = key, Value = value };
			if (hashIndex == -1 && hashTable.Count > hashList.Count)
			{
				hashList.Add(hashCode);
				hashIndex = FindIndexOfHash(hashCode);
				hashTable[hashIndex].Add(keyValue);
				return;
			}
			foreach (var pair in hashTable[hashIndex])
			{
				if (pair.Key.Equals(key))
					pair.Value = value;
			}
		}

		/// <summary>
		/// Получение значения по ключу
		/// </summary>
		public object GetValueByKey(object key)
		{
			var index = FindIndexOfHash(GetHashCode(key));
			if (index == -1)
				return null;
			foreach (var pair in hashTable[index])
			{
				if (pair.Key.Equals(key))
					return pair.Value;
			}
			return null;
		}

		public static void Main()
		{
		}
	}
}
