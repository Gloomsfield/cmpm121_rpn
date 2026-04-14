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
	}
}

