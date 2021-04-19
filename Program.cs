using System;
using System.Collections.Generic;
using System.Linq;

namespace BA3E
{
	class Program
	{

		public static List<string> Rastav(string s)
		{ List<string> lista = new List<string>();
			string[] niz = s.Split("\n");
			for (int i = 0; i < niz.Length; i++)
				lista.Add(niz[i]);
			return lista;

			
		}
		public static string Prefix(string s)
		{
			return s.Substring(0, s.Length - 1);
		}
		public static string Sufix(string s)
		{
			return s.Substring(1, s.Length - 1);
		}
		public static SortedDictionary<string, List<string>> deBruijn(List<string> lista)
		{
			SortedDictionary<string, List<string>> sor = new SortedDictionary<string, List<string>>();
			int pat = lista.Count;
			for (int i = 0; i < pat; i++)
			{
				if (sor.ContainsKey(Prefix(lista[i])))
					sor[Prefix(lista[i])].Add(Sufix(lista[i]));
				else
				{
					List<string> l1 = new List<string>();
					l1.Add(Sufix(lista[i]));
					sor.Add(Prefix(lista[i]), l1);
				}
			}
			return sor;
		}
		static void Main(string[] args)
			{  
				string k = "GAGG\nCAGG\nGGGG\nGGGA\nCAGG\nAGGG\nGGAG";
				List<string> l = Rastav(k);
			    SortedDictionary<string, List<string>> d = deBruijn(l);
			foreach (string key in d.Keys)
				d[key].Sort();
			foreach (string key in d.Keys)
			{
				string p = key + "->";
				foreach (string value in d[key])
				{
					p += value + ",";
				}
				Console.WriteLine(p);
			}
			Console.WriteLine("kraj");
			









			}
		}
	}

		
	