namespace EDDY202401.Models
{
    public class DigitsViewModel
    {
        public int count { get; set; }
        public int[] data { get; set; }
        public List<int> list => data.ToList();
        public string text => string.Join(", ", list);
    }
}
