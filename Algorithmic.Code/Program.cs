using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithmic.Code
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine((int)'a');            
            Console.WriteLine((int)'z');            
            Console.WriteLine((int)'z' - (int)'a');

            Console.WriteLine((int)'A');
            Console.WriteLine((int)'z');
            Console.WriteLine((int)'z' - (int)'A');

            Console.ReadLine();

        }

        //bài test Contemi
        public string[] Filter(string[] args)
        {
            var result = new List<string>();
            if (args.Length == 0 || args == null) return result.ToArray();

            var positions = new Dictionary<string, List<int>>();

            for (int i = 0; i < args.Length; i++)
            {
                var curString = args[i];
                var lenStr = 3;
                do
                {
                    for (int j = 0; j < curString.Length; j++)
                    {
                        if (j + lenStr > curString.Length) break;
                        var subString = curString.Substring(j, lenStr);
                        if (subString.Length == lenStr)
                        {
                            List<int> appears;
                            if (positions.ContainsKey(subString))
                            {
                                appears = positions[subString];
                            }
                            else
                            {
                                appears = new List<int>();
                            }
                            appears.Add(i);
                            positions[subString] = appears;
                        }
                    }
                    lenStr++;
                } while (lenStr <= 9 && lenStr <= curString.Length / 2);
            }


            var existing = new List<int>();
            foreach (var pair in positions)
            {
                if (pair.Value.Count >= 2)
                {
                    foreach (var idx in pair.Value)
                    {
                        if (!existing.Contains(idx))
                        {
                            result.Add(args[idx]);
                            existing.Add(idx);
                        }
                    }
                }
            }

            return result.ToArray();
        }
    
        //get danh  sách các chuỗi là do 2 chuỗi khác  ghép lại
        static public string[] GetLists(string[] args)
        {
            args = new List<string> { "al", "albums", "aver", "bar", "barely", "be", "befoul", "bums", "by", "cat", "con", "convex", "ely", "foul", "here", "hereby", "jig", "jigsaw", "or", "saw", "speedy", "tail", "tailor", "vex", "we", "weaver", "Lee", "LeeLee" }.ToArray();
            if (args == null || args.Length == 0) return null;

            int len = args.Length;

            string[,] mappings = new string[len, len];
            for (int i = 0; i < len * len; i++)
            {
                int row = i / len;
                int col = i % len;
                string str = $"{args[row]}{args[col]}";
                if (row != col && str.Length == 6)
                {
                    mappings[row, col] = $"{args[row]}{args[col]}";
                }
            }

            var bigStr = string.Join("|", args);
            var rs = new List<string>();
            for (int i = 0; i < len * len; i++)
            {
                int row = i / len;
                int col = i % len;
                if (row != col && !string.IsNullOrEmpty(mappings[row, col]) && 
                    bigStr.IndexOf(mappings[row, col]) != -1 &&
                    !rs.Contains(mappings[row, col]))
                {
                    rs.Add(mappings[row, col]);
                }
            }

            foreach(var s in rs)
            {
                Console.WriteLine(s);
            }
            return null;
        }

        //chec a string as Anagram
        public static int makeAnagram(string a, string b)
        {
            int maxLen = a.Length > b.Length ? a.Length : b.Length;
            for (int i = maxLen - 1; i >= 0; i--)
            {
                string _a = "", _b = "";
                if (i < a.Length) _a = a.Substring(i, 1);
                if (i < b.Length) _b = b.Substring(i, 1);

                if (_a != "" && _b != "" && _a == _b)
                {
                    a = a.Remove(i, 1);
                    b = b.Remove(i, 1);
                }
                else
                {
                    if (_a != "" && b.IndexOf(_a) != -1)
                    {
                        a = a.Remove(i, 1);
                        b = b.Remove(b.IndexOf(_a), 1);
                    }

                    if (_b != "" && a.IndexOf(_b) != -1)
                    {
                        b = b.Remove(i, 1);
                        a = a.Remove(a.IndexOf(_b), 1);
                    }
                }
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine("");
            }

            return a.Length + b.Length;
        }

        //Làm thế nào để tìm số còn thiếu trong một mảng số nguyên cho trước từ 1 đến 100
        public int[] FindMissingNumber(int[] arr, int n)
        {
            int[] arrNumbers = new int[n + 1];
            int numOfZero = n + 1;

            for (int i = 0; i < arr.Length; i++)
            {
                if(arrNumbers[arr[i]] == 0)
                {
                    arrNumbers[arr[i]] = arr[i];
                    numOfZero--;
                }
            }

            int[] rs = new int[numOfZero - 1];
            for (int i = 1, j = 0; i < n + 1; i++)
            {
                if (arrNumbers[i] == 0)
                {
                    rs[j] = i;
                    j++;
                }
            }

            //O(2n)
            return rs;
        }

        //Làm sao bạn có thể tìm số bị trùng lắp một mảng số nguyên cho trước?
        public int[] FindDuplicatedNumber(int[] arr)
        {
            int n = arr.Length;

            var table = new Hashtable();

            for (int i = 0; i < n; i++)
            {
                if (table.ContainsKey(arr[i]))
                {
                    var count = int.Parse(table[arr[i]].ToString()) + 1;
                    table[arr[i]] = count;
                }
                else
                {
                    table.Add(arr[i], 1);
                }
            }

            var duplocates = new List<int>();
            foreach(DictionaryEntry entry in table)
            {
                var count = int.Parse(entry.Value.ToString());
                if (count > 1)
                {
                    duplocates.Add(int.Parse(entry.Key.ToString()));
                }
            }

            //O(2n)
            return duplocates.ToArray();
        }

        //Làm thế nào để bạn có thể tìm số lớn nhất và nhỏ nhất trong một mảng chưa được sắp xếp?
        public int[] FindMaxMin(int[] arr)
        {
            int n = arr.Length;


            int max = arr[0];
            int min = arr[0];

            for (int i = 0; i < n; i++)
            {
                max = arr[i] > max ? arr[i] : max;
                min = arr[i] < min ? arr[i] : min;
            }

            //O(n)
            return new int[] { max, min };
        }

        //Làm thế nào để tìm tất cả các cặp số trong một mảng số nguyên có tổng bằng với một số cho trước
        public int[] FindNumberWithSum(int[] arr, int sum)
        {
            int n = arr.Length;
            var table = new Hashtable();

            var rs =  new List<int>();

            for (int i = 0; i < n; i++)
            {
                int target = sum - arr[i];
                if (table.ContainsKey(arr[i]) && table[arr[i]] == null)
                { 
                    table[arr[i]] = target;
                    rs.Add(target);
                    rs.Add(arr[i]);
                }
                else if (!table.ContainsKey(target))
                {
                    table.Add(target, null);
                }
            }

            //O(n)
            return rs.ToArray();
        }

        //làm thế nào để loại bỏ các phần tử trùng lắp (duplicates) trong một mảng cho trước
        public int[] RemoveDuplicatedNumber(int[] arr)
        {
            int n = arr.Length;
            var table = new HashSet<int>();
            var rs = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if(!table.Contains(arr[i]))
                {
                    table.Add(arr[i]);
                    rs.Add(arr[i]);
                }
            }

            //O(n)
            return rs.ToArray();
        }

        //Quick Sort
        public int[] QuickSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int index = Partition(arr, left, right);

                QuickSort(arr, left, index - 1);
                QuickSort(arr, index + 1, right);
            }
            return arr;
        }

        public int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            while(true)
            {
                while (left <= right && arr[left] < pivot) left++;
                while (left <= right && arr[right] > pivot) right--;
                if (left >= right) break;

                Swap(ref arr[left], ref arr[right]);
                left++;
                right--;
            }
            return left;
        }

        public void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        //Làm thế nào để in các ký tự trùng lắp trong một chuỗi
        public string ShowDuplicatedString(string str)
        {
            var table = new Hashtable();

            foreach(var c in str)
            {
                if (!table.ContainsKey(c))
                {
                    table.Add(c, 1);
                }
                else
                {
                    table[c] = int.Parse(table[c].ToString()) + 1;
                }
            }

            var result = new StringBuilder();

            foreach(DictionaryEntry entry in table)
            {
                if (int.Parse(entry.Value.ToString()) > 1)
                {
                    result.Append(entry.Key);
                }
            }

            //O(2n)
            return result.ToString();
        }

        //Làm thế nào để kiểm tra xem một chuỗi có phải là đảo của một chuỗi khác? 
        public bool CheckReverseString(string str, string str2)
        {
            if (str.Length != str2.Length) return false;

            for(int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                if (str[i] != str2[j]) 
                    return false;
            }

            //O(n)
            return true;
        }

        //Trình bày cách in ký tự không bị lặp lại đầu tiên(ví dụ swiss thì w là ký tự không bị lặp lại đầu tiên trong từ) trong một chuỗi?
        public string CheckNoneFirstReverseString(string str)
        {
            int[] arr = new int[58];
            for (int i = 0; i < str.Length; i++)
            {
                int pos = (int)str[i] - (int)'A' + 1; 

                arr[pos - 1] = arr[pos - 1] + 1;
            }

            for (int i = 0; i < str.Length; i++)
            {
                int pos = (int)str[i] - (int)'A' + 1;
                if(arr[pos - 1] == 1)
                    return str[i].ToString();
            }

            //O(2n)
            return "";
        }

        //Làm thế nào để đảo ngược một chuỗi cho trước sử dụng đệ quy?
        public string ReverseStringRecursively(string str)
        {
            if (str == "") return "";
            else
                return str[str.Length - 1] + ReverseStringRecursively(str.Substring(0, str.Length - 1));
        }

        //Làm thế nào để tìm tất cả các hoán vị của một chuỗi 
        public string[] GetAllPermutations(string str)
        {
            //ToDo
            var rs  = new List<string>();
            
            return rs.ToArray();
        }

        //Làm thế nào bạn có thể đảo các từ của một câu mà không dùng bất kỳ thư viện có sẵn nào?
        public string GetReverseWords(string str)
        {
            var rs = string.Empty;

            int start = 0;
            for(int i=0; i<str.Length; i++)
            {
                if (str[i] == ' ' || i == str.Length - 1)
                {
                    var aWord = str.Substring(start, i - start + 1);
                    rs = aWord + rs;
                    start = i + 1;                
                }
            }

            return rs;
        }

        //Làm thế nào để kiểm tra nếu một chuỗi là một rotation(xem ví dụ trong link về giải pháp để hiểu ý nghĩa của rotation) của chuỗi còn lại?
        public bool CheckStringRotation(string str, string str2)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                str = str.Substring(1) + str[0].ToString();
                if (str == str2) return true;
            }

            return false;
        }

        //Làm thế nào bạn có thể kiểm tra nếu một chuỗi cho trước là xâu đối xứng, tức có thể đọc xuôi ngược gì cũng giống nhau (palindrome)?
        public bool CheckStringPalindrome(string str)
        {
            if (str.Length % 2 != 0) return false;

            int left = 0, right = str.Length - 1;
            while(left < right)
            {
                if(str[left] != str[right]) return false;
                left++; right--;
            }

            return true;
        }

    }
}
