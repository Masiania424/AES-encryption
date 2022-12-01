namespace _4laba
{
    partial class AEScrypt
    {
        public static AEScrypt ByteSubstitutionMethod(AEScrypt matrix1, AEScrypt matrix2)
        {
            string[,] result = new string[4, 4];
            string numTotal1, numTotal2, temp;
            for (int i = 0; i < matrix1.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.Matrix.GetLength(1); j++)
                {
                    (string num1, string num2) = (matrix1.Matrix[i, j][0].ToString(), matrix1.Matrix[i, j][1].ToString());
                    numTotal1 = HexToBinary(num1, num2);

                    (string num3, string num4) = (matrix2.Matrix[i, j][0].ToString(), matrix2.Matrix[i, j][1].ToString());
                    numTotal2 = HexToBinary(num3, num4);

                    temp = EightsNum(Convert.ToString(Convert.ToInt32(numTotal1, 2) ^ Convert.ToInt32(numTotal2, 2), 2));
                    Console.WriteLine($"{numTotal1} XOR {numTotal2} = " + Convert.ToString(Convert.ToInt32(temp[..4], 2), 16).ToUpper() + Convert.ToString(Convert.ToInt32(temp[4..], 2), 16).ToUpper() + " ");
                    result[i, (j - i + 4) % 4] = ByteSubstitution[Convert.ToInt32(temp[..4], 2), Convert.ToInt32(temp[4..], 2)];
                }
                Console.WriteLine();
            }
            PrintMatrix(result);
            Console.WriteLine();
            return new AEScrypt(TwoNum(result));
        }
    }
}
