


int MaxOperations(int[] nums, int k) 
{
    int left = 0;
    int right = nums.Length - 1;
    int maxOperations = 0;
    
    Array.Sort(nums);

    while(left < right)
    {
        int sum = nums[left] + nums[right];
        
        if(sum == k)
        {
            maxOperations++;
            left++;
            right--;
        }
        else if(sum < k)
        {
            left++;
        }
        else
        {
            right--;
        }
    }

    return maxOperations;
}
