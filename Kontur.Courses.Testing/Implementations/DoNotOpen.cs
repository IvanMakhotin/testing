﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Kontur.Courses.Testing.Implementations
{
	#region Не подглядывать
	public class WordsStatistics1 : IWordsStatistics
	{
		private List<string> words = new List<string>();
		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			words.Add(word);
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return words.GroupBy(w => w.ToLower())
				.Select(g => Tuple.Create(g.Count(), g.First()))
				.OrderByDescending(t => t.Item1).ThenBy(t => t.Item2);
		}
	}

	public class WordsStatistics2 : IWordsStatistics
	{
		private static IDictionary<string, int> stats = new Dictionary<string, int>();

		public WordsStatistics2()
		{
			stats.Clear();
		}

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			int count;
			stats[word.ToLower()] = stats.TryGetValue(word.ToLower(), out count) ? count + 1 : 1;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key).Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}

	public class WordsStatistics3 : IWordsStatistics
	{
		private IDictionary<string, int> stats = new Dictionary<string, int>();

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 11) word = word.Substring(0, 10);
			int count;
			stats[word.ToLower()] = stats.TryGetValue(word.ToLower(), out count) ? count + 1 : 1;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key).Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}

	public class WordsStatistics4 : IWordsStatistics
	{
		private IDictionary<string, int> stats = new Dictionary<string, int>();

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			int count;
			stats[word.ToLower()] = stats.TryGetValue(word.ToLower(), out count) ? count + 1 : 1;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key).Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}

	public class WordsStatistics5 : IWordsStatistics
	{
		private IDictionary<string, int> stats = new Dictionary<string, int>();

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			if (!stats.ContainsKey(word))
				stats[word.ToLower()] = 0;
			stats[word]++;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key).Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}
	public class WordsStatistics6 : IWordsStatistics
	{
		private IDictionary<string, int> stats = new Dictionary<string, int>();

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			int count;
			stats[word.ToLower()] = stats.TryGetValue(word.ToLower(), out count) ? count + 1 : 1;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Value)
				.ThenBy(kv => kv.Key)
				.ToDictionary(kv => kv.Key, kv => kv.Value)
				.Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}
	public class WordsStatistics7 : IWordsStatistics
	{
		private IDictionary<string, int> stats = new Dictionary<string, int>();

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			int count;
			stats[word.ToLower()] = stats.TryGetValue(word.ToLower(), out count) ? count + 1 : 1;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Key).ThenBy(kv => kv.Key).Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}

	public class WordsStatistics8 : IWordsStatistics
	{
		private int[] stats = new int[12347];
		private string[] words = new string[12347];

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			var index = Math.Abs(word.ToLower().GetHashCode()) % 12347;
			stats[index]++;
			words[index] = word.ToLower();
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.Zip(words, Tuple.Create)
				.Where(t => t.Item1 > 0)
				.OrderByDescending(t => t.Item1)
				.ThenBy(t => t.Item2);
		}
	}

	public class WordsStatistics9 : IWordsStatistics
	{
		private List<Tuple<int, string>> stats = new List<Tuple<int, string>>();

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			var tuple = stats.FirstOrDefault(s => s.Item2 == word.ToLower());
			if (tuple != null)
				stats.Remove(tuple);
			else
				tuple = Tuple.Create(0, word.ToLower());
			stats.Add(Tuple.Create(tuple.Item1 + 1, tuple.Item2));
			stats.Sort();
			stats.Reverse();
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats;
		}
	}

	public class WordsStatistics10 : IWordsStatistics
	{
		private List<string> words = new List<string>();

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			words.Add(word.ToLower());
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return words
				.GroupBy(w => w)
				.OrderByDescending(g => g.Count())
				.Select(g => Tuple.Create(g.Count(), g.Key));
		}
	}


	public class WordsStatistics11 : IWordsStatistics
	{
		private IDictionary<string, int> stats = new Dictionary<string, int>();

		private string ToLower(string s)
		{
			return new string(s.Select(c => "QWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".Contains(c) ? char.ToLower(c) : c).ToArray());
		}

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			word = ToLower(word);
			int count;
			stats[word] = stats.TryGetValue(word, out count) ? count + 1 : 1;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Value).Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}

	public class WordsStatistics12 : IWordsStatistics
	{
		private IDictionary<string, int> stats = new Dictionary<string, int>();

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			int count;
			stats[word.ToLower()] = stats.TryGetValue(word.ToLower(), out count) ? count + 1 : 1;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Value).ThenByDescending(kv => kv.Key).Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}
	public class WordsStatistics13 : IWordsStatistics
	{
		private List<Tuple<int, string>> stats = new List<Tuple<int, string>>();

		public void AddWord(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			var tuple = stats.FirstOrDefault(s => s.Item2 == word.ToLower());
			if (tuple != null)
				stats.Remove(tuple);
			else
				tuple = Tuple.Create(0, word.ToLower());
			stats.Add(Tuple.Create(tuple.Item1 + 1, tuple.Item2));
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(t => t.Item1).ThenBy(t => t.Item2);
		}
	}
	
	public class WordsStatistics14 : IWordsStatistics
	{
		private IDictionary<string, int> stats = new Dictionary<string, int>();

		public void AddWord(string word)
		{
			if (word == "") return;
			if (word.Length > 10) word = word.Substring(0, 10);
			int count;
			stats[word.ToLower()] = stats.TryGetValue(word.ToLower(), out count) ? count + 1 : 1;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Value)
				.ThenBy(kv => kv.Key).Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}

	public class WordsStatistics15 : IWordsStatistics
	{
		private IDictionary<string, int> stats = new Dictionary<string, int>();

		public void AddWord(string word)
		{
			if (word == null) return;
			if (word.Length > 10) word = word.Substring(0, 10);
			int count;
			stats[word.ToLower()] = stats.TryGetValue(word.ToLower(), out count) ? count + 1 : 1;
		}

		public IEnumerable<Tuple<int, string>> GetStatistics()
		{
			return stats.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key).Select(kv => Tuple.Create(kv.Value, kv.Key));
		}
	}

	#endregion
}
