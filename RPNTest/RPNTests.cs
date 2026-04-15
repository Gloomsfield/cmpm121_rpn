using Xunit;
using RPNEvaluator;

namespace RPNEvaluator.Tests {
	public class RPNEvaluatorTests {
		[Fact]
		public void TestOnePlusOne() {
			var result = RPNEvaluator.Evaluate("1 1 +", null);

			Assert.Equal(2, result);
		}

		[Theory]
		[InlineData("5 5 +", 10)]
		[InlineData("5 5 -", 0)]
		[InlineData("10 5 -", 5)]
		[InlineData("20 40 /", 0)]
		[InlineData("100 100 - 100 10 * +", 1000)]
		[InlineData("1001 1000 / 1000 1001 / +", 1)]
		public void TestFormulaNoVariables(string formula, int expected) {
			var result = RPNEvaluator.Evaluate(formula, null);

			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("5.0 5.0 +", 10)]
		[InlineData("5.0 5.0 -", 0)]
		[InlineData("10.5 5.25 -", 5.25)]
		[InlineData("20.0 40.0 /", 0.5)]
		[InlineData("100.0 100.0 - 100.0 10.0 * +", 1000.0)]
		[InlineData("1001.0 1000.0 / 1000.0 1001.0 / +", 2.0)]
		public void TestFormulaNoVariablesFloatInt(string formula, float expected) {
			var result = RPNEvaluator.Evaluatef(formula, new Dictionary<string, int>());

			Assert.Equal(expected, result, 4);
		}

		[Theory]
		[InlineData("5.0 5.0 +", 10)]
		[InlineData("5.0 5.0 -", 0)]
		[InlineData("10.5 5.25 -", 5.25)]
		[InlineData("20.0 40.0 /", 0.5)]
		[InlineData("100.0 100.0 - 100.0 10.0 * +", 1000.0)]
		[InlineData("1001.0 1000.0 / 1000.0 1001.0 / +", 2.0)]
		public void TestFormulaNoVariablesFloatFloat(string formula, float expected) {
			var result = RPNEvaluator.Evaluatef(formula, new Dictionary<string, float>());

			Assert.Equal(expected, result, 4);
		}

		[Theory]
		[InlineData("test-1 test-2 + 5 *", new string[] {"test-1", "test-2"}, new int[] {1, 4}, 2, 25)]
		[InlineData("5 6 9 + foo - -", new string[] {"foo", "bar"}, new int[] {1, 2}, 2, -9)]
		[InlineData("bar bar + foo +", new string[] {"foo", "bar", "baz"}, new int[] {0, -5, 999}, 3, -10)]
		public void TestFormulaIntInt(string formula, string[] keys, int[] values, int length, float expected) {
			Dictionary<string, int> variables = new Dictionary<string, int>();

			for(int i = 0; i < length; i++) {
				variables.Add(keys[i], values[i]);
			}

			var result = RPNEvaluator.Evaluate(formula, variables);

			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("test-1 test-2 + 5.0 *", new string[] {"test-1", "test-2"}, new float[] {1, 4}, 2, 25.0F)]
		[InlineData("5.0 6.0 9.0 + foo - -", new string[] {"foo", "bar"}, new float[] {1, 2}, 2, -9)]
		[InlineData("bar bar + foo +", new string[] {"foo", "bar", "baz"}, new float[] {0, -5, 999}, 3, -10.0F)]
		public void TestFormulaFloatInt(string formula, string[] keys, float[] values, int length, float expected) {
			Dictionary<string, float> variables = new Dictionary<string, float>();

			for(int i = 0; i < length; i++) {
				variables.Add(keys[i], values[i]);
			}

			var result = RPNEvaluator.Evaluatef(formula, variables);

			Assert.Equal(expected, result, 4);
		}
		[Theory]
		[InlineData("test-1 test-2 + 5.0 *", new string[] {"test-1", "test-2"}, new float[] {1.0F, 4.0F}, 2, 25.0F)]
		[InlineData("5.0 6.0 9.0 + foo - -", new string[] {"foo", "bar"}, new float[] {1.0F, 2.0F}, 2, -9.0F)]
		[InlineData("bar bar + foo +", new string[] {"foo", "bar", "baz"}, new float[] {0.0F, -5.0F, 999.0F}, 3, -10.0F)]
		public void TestFormulaFloatFloat(string formula, string[] keys, float[] values, int length, float expected) {
			Dictionary<string, float> variables = new Dictionary<string, float>();

			for(int i = 0; i < length; i++) {
				variables.Add(keys[i], values[i]);
			}

			var result = RPNEvaluator.Evaluatef(formula, variables);

			Assert.Equal(expected, result, 4);
		}
	}
}

