namespace AdventOfCode2022Library
{
    public class Tree
    {
        public int height;
        public int ScenicScore;
        public bool IsVisible;
        public Tree(int height)
        {
            this.height = height;
            IsVisible = false;
            ScenicScore = 1;
        }
    }
}
