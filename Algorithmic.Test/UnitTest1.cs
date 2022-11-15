using System;
using System.Linq;
using Xunit;

namespace Algorithmic.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("qazwsxedcxyzrfvtgb, zaqxswxyzrdevfr, qweasabcdzxcvbabcn, poiABCumnbvcxkjhg, njibhuvggy, qpwoeirutylaksjd, lmbABvxaABgjkl", "qazwsxedcxyzrfvtgb, zaqxswxyzrdevfr, qweasabcdzxcvbabcn")]
        public void AlgorithmicReturnCorrectList(string input, string expected)
        {
            //Arrange
            var inputs = input.Split(",").Select(x => x.Trim()).ToArray();
            var expectedStrings = expected.Split(",").Select(x => x.Trim()).ToArray();

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.Filter(inputs);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedStrings.Length, result.Length);

            foreach(var str in expectedStrings)
            {
                Assert.Contains(result.ToList(), x => x == str);
            }
        }

        [Theory]
        [InlineData("100,10,55,75,10,18,94,5,9,19,7,98,54,36,14,15,2,26,89,9,22,88,14,37,26,75,61,27,27,72,28,89,21,50,15,19,98,85,53,23,34,87,57,34,34,80,73,61,93,37,94,29,74,31,43,54,45,60,66,66,100,91,20,45,85,85,16,20,70,7,90,11,32,64,20,46,57,93,66,41,70,63,48,49,59,48,35,2,38,65,67,14,43,91,51,7,71,83,31,49", "1,3,4,6,8,12,13,17,24,25,30,33,39,40,42,44,47,52,56,58,62,68,69,76,77,78,79,81,82,84,86,92,95,96,97,99")]
        public void FindMissingNumbersReturnCorrectList(string input, string expected)
        {
            //Arrange
            var inputs = input.Split(",").Select(x => int.Parse(x.Trim())).ToArray();
            var expectedStrings = expected.Split(",").Select(x => int.Parse(x.Trim())).ToArray();

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.FindMissingNumber(inputs, 100);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedStrings.Length, result.Length);

            for(int i = 0; i < expectedStrings.Length; i++)
            {
                Assert.Contains(result.ToList(), x => x == expectedStrings[i]);
            }

            for (int i = 0; i < result.Length; i++)
            {
                Assert.Contains(expectedStrings.ToList(), x => x == result[i]);
            }
        }


        [Theory]
        [InlineData("1,2,3,4,5,6,7,8,9,100,4,18,1,4,15,16,2,18", "1,18,3,16,4,15")]
        public void FindDuplicatedNumbersReturnCorrectList(string input, string expected)
        {
            //Arrange
            var inputs = input.Split(",").Select(x => int.Parse(x.Trim())).ToArray();
            var expectedStrings = expected.Split(",").Select(x => int.Parse(x.Trim())).ToArray();

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.FindNumberWithSum(inputs, 19);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedStrings.Length, result.Length);

            for (int i = 0; i < result.Length; i+=2)
            {
                Assert.Equal(19, result[i] + result[i + 1]);
            }
        }


        [Theory]
        [InlineData("2,3,4,5,6,4,6,7,8,9,5,3,3,4,5,7,5,3,23,4,5,6,6,23,43,5,65,67,4,4,67", "2,3,4,5,6,7,8,9,23,43,65,67")]
        public void CanRemoveDuplicatedNumbers(string input, string expected)
        {
            //Arrange
            var inputs = input.Split(",").Select(x => int.Parse(x.Trim())).ToArray();
            var expectedStrings = expected.Split(",").Select(x => int.Parse(x.Trim())).ToArray();

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.RemoveDuplicatedNumber(inputs);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedStrings.Length, result.Length);

            for (int i = 0; i < result.Length; i += 2)
            {
                Assert.Equal(expectedStrings[i], result[i]);
            }
        }


        [Theory]
        [InlineData("20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,11", "2,3,4,5,6,7,8,9,10,11,11,12,13,14,15,16,17,18,19,20")]
        public void QuickSortShouldCorrect(string input, string expected)
        {
            //Arrange
            var inputs = input.Split(",").Select(x => int.Parse(x.Trim())).ToArray();
            var expectedStrings = expected.Split(",").Select(x => int.Parse(x.Trim())).ToArray();

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.QuickSort(inputs, 0, inputs.Length - 1);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(expectedStrings.Length, result.Length);

            for (int i = 0; i < expectedStrings.Length; i++)
            {
                Assert.Equal(expectedStrings[i], result[i]);
            }
        }

        [Theory]
        [InlineData("complainhowerverstartmorver", "omaervt")]
        public void ShowDuplicatedTextCorrectly(string input, string expected)
        {
            //Arrange
            
            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.ShowDuplicatedString(input);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            foreach (var c in expected)
            {
                Assert.Contains(c.ToString(), result);
            }

            foreach (var c in result)
            {
                Assert.Contains(c.ToString(), expected);
            }
        }

        [Theory]
        [InlineData("abcdefghijk||kjihgfedcba", "True")]
        [InlineData("abcdefghijk||kjihgfedcbb", "False")]
        public void CheckRevertStringShould(string input, string expected)
        {
            //Arrange
            var strs = input.Split("||");

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.CheckReverseString(strs[0], strs[1]);

            //Assert
            var expectedBool = bool.Parse(expected);
            Assert.Equal(expectedBool, result);
        }


        [Theory]
        [InlineData("swiss", "w")]
        public void CheckFirstNonDuplicateTextShould(string input, string expected)
        {
            //Arrange
            
            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.CheckNoneFirstReverseString(input);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abcdefgh", "hgfedcba")]
        public void ReverseStringRecursivelyShould(string input, string expected)
        {
            //Arrange

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.ReverseStringRecursively(input);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Nguyen  Ngoc Tam Dan   Phuc   Thanh", "Thanh  Phuc   Dan Tam Ngoc  Nguyen ")]
        public void GetRevereWordsShould(string input, string expected)
        {
            //Arrange

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.GetReverseWords(input);

            //Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("abcdefghijk,efghijkabcd","True")]
        [InlineData("abcdefghijkghijs,sabcdefghijkghij", "True")]
        [InlineData("abcdefghijkghijs,tabcdefghijkghij", "False")]
        public void CheckStringRotationShould(string input, string expected)
        {
            //Arrange
            var inputs = input.Split(",").Select(x => x.Trim()).ToArray();
            var expectedBool = bool.Parse(expected);

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.CheckStringRotation(inputs[0], inputs[1]);

            //Assert
            Assert.Equal(expectedBool, result);
        }

        [Theory]
        [InlineData("ThanhhnahT", "True")]
        [InlineData("abcdefghhgfedcba", "True")]
        [InlineData("abcdefghhgfkdcba", "False")]
        public void CheckStringPalindromeShould(string input, string expected)
        {
            //Arrange
            var expectedBool = bool.Parse(expected);

            //Action
            var program = new Algorithmic.Code.Program();
            var result = program.CheckStringPalindrome(input);

            //Assert
            Assert.Equal(expectedBool, result);
        }
    }
}
