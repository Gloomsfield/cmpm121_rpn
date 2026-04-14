using System;
using System.Collections;
using System.Collections.Generic;

namespace RPNEvaluator {
	public class RPNEvaluator {
		private static Dictionary<string, Func<int, int, int>> operations_int = new Dictionary<string, Func<int, int, int>>() {
			["+"] = (a, b) => { return b + a; },
			["-"] = (a, b) => { return b - a; },
			["*"] = (a, b) => { return b * a; },
			["/"] = (a, b) => { return b / a; },
			["%"] = (a, b) => { return b % a; },
		};

		private static Dictionary<string, Func<float, float, float>> operations_float = new Dictionary<string, Func<float, float, float>>() {
			["+"] = (a, b) => { return b + a; },
			["-"] = (a, b) => { return b - a; },
			["*"] = (a, b) => { return b * a; },
			["/"] = (a, b) => { return b / a; },
			["%"] = (a, b) => { return b % a; },
		};
	
		public static int Evaluate(string input, Dictionary<string, int> variables) {
			string[] tokens = input.Split(' ');
	
			Stack<int> res = new Stack<int>();
	
			foreach(string token in tokens) {
				if(operations_int.TryGetValue(token, out Func<int, int, int> f)) {
					res.Push(f(res.Pop(), res.Pop()));
					continue;
				}
	
				if(int.TryParse(token, out int v_1)) {
					res.Push(v_1);
					continue;
				}
	
				if(variables.TryGetValue(token, out int v_2)) {
					res.Push(v_2);
				}
			}
	
			return res.Pop();
		}
	
		public static float Evaluatef(string input, Dictionary<string, float> variables) {
			string[] tokens = input.Split(' ');
	
			Stack<float> res = new Stack<float>();
	
			foreach(string token in tokens) {
				if(operations_float.TryGetValue(token, out Func<float, float, float> f)) {
					res.Push(f(res.Pop(), res.Pop()));
					continue;
				}
	
				if(float.TryParse(token, out float v_1)) {
					res.Push(v_1);
					continue;
				}
	
				if(variables.TryGetValue(token, out float v_2)) {
					res.Push(v_2);
				}
			}
	
			return res.Pop();
		}

		public static float Evaluatef(string input, Dictionary<string, int> variables) {
			string[] tokens = input.Split(' ');
	
			Stack<float> res = new Stack<float>();
	
			foreach(string token in tokens) {
				if(operations_float.TryGetValue(token, out Func<float, float, float> f)) {
					res.Push(f(res.Pop(), res.Pop()));
					continue;
				}
	
				if(float.TryParse(token, out float v_1)) {
					res.Push(v_1);
					continue;
				}
	
				if(variables.TryGetValue(token, out int v_2)) {
					res.Push(v_2);
				}
			}
	
			return res.Pop();
		}
	}
}

