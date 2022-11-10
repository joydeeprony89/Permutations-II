using System;
using System.Collections.Generic;

namespace Permutations_II
{
  class Program
  {
    static void Main(string[] args)
    {
      Solution s = new Solution();
      var answer = s.PermuteUnique(new int[] { 1, 2, 3 });
      foreach (var i in answer) Console.WriteLine(string.Join(",", i));
    }

    public class Solution
    {
      public IList<IList<int>> PermuteUnique(int[] nums)
      {
        var result = new List<IList<int>>();
        bool[] used = new bool[nums.Length];
        Array.Sort(nums);
        Helper(nums, result, new List<int>(), used);
        return result;
      }

      private void Helper(int[] nums, List<IList<int>> result, List<int> temp, bool[] used)
      {
        if (temp.Count == nums.Length)
        {
          result.Add(new List<int>(temp));
          return;
        }
        for (int i = 0; i < nums.Length; i++)
        {
          if (used[i]) continue;
          if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
          used[i] = true;
          temp.Add(nums[i]);
          Helper(nums, result, temp, used);
          used[i] = false;
          temp.RemoveAt(temp.Count - 1);
        }
      }
    }
  }
}
