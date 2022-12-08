namespace AdventOfCode2022Library
{
    public class TreeGrid : IMyParsable<TreeGrid>
    {
        Tree[,] trees = new Tree[0, 0]; 
        public static TreeGrid Parse(string s)
        {
            Tree[,] trees = new Tree[s.Split(';').Length, s.Split(';')[0].Length];
            int i = 0;
            foreach(string row in s.Split(";"))
            {
                for (int j = 0; j < row.Length; j++)
                {
                    trees[i, j] = new Tree(int.Parse(row.Substring(j,1)));
                }
                i++;
            }
            return new TreeGrid()
            {
                trees = trees
            };
        }

        public int BiggestScore()
        {
            int max = 0;
            for (int i = 0; i < trees.GetLength(0); i++)
            {
                for (int j = 0; j < trees.GetLength(1); j++)
                {
                    max = Math.Max(max, trees[i, j].ScenicScore);
                }
            }
            return max;
        }

        public void CheckVisibilty()
        {
            foreach ((int a, int b) in new List<(int i, int j)> { (0, 1), (1, 0) })
            {
                for (int i = 0; i < trees.GetLength(a); i++)
                {
                    int maxHeightLeft = -1;
                    int maxHeightRight = -1;
                    for (int j = 0; j < trees.GetLength(b); j++)
                    {
                        int ii = i * b + j * a;
                        int jj = j * b + i * a;
                        if (trees[ii, jj].height > maxHeightLeft)
                        {
                            maxHeightLeft = trees[ii, jj].height;
                            trees[ii, jj].IsVisible = true;
                        }

                        int scenicScore = 0;
                        for (int k = j - 1; k >= 0; k--)
                        {
                            int iii = i * b + k * a;
                            int jjj = k * b + i * a;
                            scenicScore++;
                            if (trees[iii, jjj].height >= trees[ii, jj].height)
                            {
                                break;
                            }
                        }
                        trees[ii, jj].ScenicScore *= scenicScore;
                        scenicScore = 0;
                        for (int k = j + 1; k < trees.GetLength(b); k++)
                        {
                            int iii = i * b + k * a;
                            int jjj = k * b + i * a;
                            scenicScore++;
                            if (trees[iii, jjj].height >= trees[ii, jj].height)
                            {
                                break;
                            }
                        }
                        trees[ii, jj].ScenicScore *= scenicScore;

                        ii = trees.GetLength(a) - ii - 1;
                        jj = trees.GetLength(b) - jj - 1;
                        if (trees[ii, jj].height > maxHeightRight)
                        {
                            maxHeightRight = trees[ii, jj].height;
                            trees[ii, jj].IsVisible = true;
                        }
                    }
                }
            }
        }

        public int CountVisible()
        {
            int count = 0;
            for (int i = 0; i < trees.GetLength(0); i++)
            {
                for (int j = 0; j < trees.GetLength(1); j++)
                {
                    if (trees[i,j].IsVisible)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
