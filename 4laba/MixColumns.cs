namespace _4laba
{
    partial class AEScrypt
    {
        public static AEScrypt MixColumnsMethod(AEScrypt matrix)
        {
            string[,] result = matrix.Matrix;
            string[] temporaryArray = new string[4];
            string[,] temporaryResult = new string[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string tempResult = "";
                    for (int y = 0; y < 4; y++)
                    {
                        if (MixColumns[i, y] == "03") temporaryArray[y] = Limitation03(result[y, j]);
                        else temporaryArray[y] = Convert.ToString(Convert.ToInt32(MixColumns[i, y], 16) * Convert.ToInt32(result[y, j], 16), 2);
                        temporaryArray[y] = TotalLimitation(temporaryArray[y]);
                    }
                    for (int y = 0; y < 8; y++)
                    {
                        int countSymbols = new char[] { temporaryArray[0][y], temporaryArray[1][y], temporaryArray[2][y], temporaryArray[3][y] }.Count(x => x == '1');
                        tempResult += countSymbols % 2 != 0 ? "1" : "0";
                    }
                    temporaryResult[i, j] = Convert.ToString(Convert.ToInt32(tempResult, 2), 16).ToUpper();
                }
            }
            return new AEScrypt(TwoNum(temporaryResult));
        }
    }
}
